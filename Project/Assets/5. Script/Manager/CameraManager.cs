    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CameraManager : Singleton<CameraManager>
{
    #region 오른쪽 마우스 눌러야 카메라 이동
    //Player player;
    //Vector2 mousePosition;
    //Vector3 angles = Vector3.zero;
    //bool isRightBtnClick = false;
    //float smoothSpeed;
    //float UpHeight = 10f;
    //float DownHeight = 330f;
    //private void Start()
    //{
    //    angles.x = 340f;
    //    smoothSpeed = 3f;
    //}


    //private void LateUpdate()
    //{

    //    if (player == null)
    //    {
    //        if (null == player) player = Player.GetInstance;
    //        transform.position = player.transform.position;
    //        transform.rotation = player.transform.rotation;
    //    }

    //    if(Input.GetMouseButtonDown(1))
    //    {
    //        isRightBtnClick = true;
    //    }

    //    if(Input.GetMouseButtonUp(1))
    //    {
    //        isRightBtnClick = false;
    //    }


    //    // 카메라와 캐릭터 사이에 있는 물체 투명화


    //    Vector3 distance = player.transform.position - Camera.main.transform.position;
    //    RaycastHit[] hit = Physics.RaycastAll(Camera.main.transform.position, distance,Mathf.Infinity);

    //    for(int i=0; i <hit.Length; i++)
    //    {
    //        if(hit[i].transform.gameObject.layer == LayerMask.NameToLayer("Wall"))
    //        {
    //            var a = hit[i].transform.GetComponent<MeshRenderer>().materials[0];
    //            Color color = a.color;

    //            if(color.a > 0.3f)
    //            {
    //                color.a -= Time.deltaTime;
    //                a.color = color;
    //            }


    //        }

    //    }


    //    //transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 10f);;
    //    transform.position = player.transform.position;

    //    angles = transform.localEulerAngles;
    //    if (isRightBtnClick)
    //    {

    //        Mouse mouse = Mouse.current;
    //        if (mouse != null)
    //        {
    //            Vector2 dir = mousePosition - mouse.position.ReadValue();
    //            dir.Normalize();
    //            angles.y -= dir.x * smoothSpeed;
    //            angles.x += dir.y * (smoothSpeed / smoothSpeed);




    //            //if (angles.y < LeftWidth && angles.y > 320f) angles.y = LeftWidth;
    //            //else if (angles.y > RightWidth && angles.y < 40f) angles.y = RightWidth;

    //            if (angles.x < DownHeight && angles.x > DownHeight - 2f && dir.y < 0)
    //            {
    //                angles.x = DownHeight;
    //            }
    //            else if (angles.x > UpHeight && angles.x < UpHeight + 2f && dir.y > 0)
    //            {
    //                angles.x = UpHeight;
    //            }


    //            transform.localEulerAngles = angles;

    //            mousePosition = mouse.position.ReadValue();

    //        }
    //    }
    //camera holder
    #endregion

    #region 오른쪽 마우스 클릭 안하고 카메라 이동
    Transform player;
    public Vector3 cameraPos = new Vector3(0, 0, 0);
    public float currDistance = 3.0f; // 카메라랑 캐릭터 거리
    public float xRotate = 250.0f;
    public float yRotate = 120.0f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float prevDistance;
    private float x = 0.0f;
    private float y = 0.0f;

    private bool OnOff = true;
    bool isUiOff = false;
    public bool ISUIOFF { get { return isUiOff; } set { isUiOff = value; } }

    Quaternion saveRotation;
    Vector3 savePosition;
    bool isPossibleJoom = false;
    //For camera colliding
    RaycastHit hit;
    public LayerMask collidingLayers = ~0; //Target marker can only collide with scene layer
    private float distanceHit;

    private void Awake()
    {
        if(null == player) player = Player.GetInstance.transform;
    }
    void Start()
    {
        isUiOff = true;
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (SceneManager.GetActiveScene().name.Equals("5_Dungeon"))
        {
            currDistance = 1f;
            isPossibleJoom = false;
        }
        else
        {
            currDistance = 2f;
            isPossibleJoom = true;
        }
    }

    //Alt클릭에 마우스 보이고 움직일수있게 추가

    public bool getOnOff()
    {
        return isUiOff;
    }

    RaycastHit[] hits;
    void LateUpdate()
    {

        //투명화한 물체들 되돌려주는 코드
        if (hits != null)
        {
            for (int i = 0; i < hits.Length; i++)
            {
               if(hits[i].collider != null)
                {
                    MeshRenderer mesh = hits[i].transform.GetComponent<MeshRenderer>();

                    if (mesh != null)
                    {
                        Material mat = mesh.materials[0];
                        Color color = mat.color;

                        color.a = 1f;
                        mat.color = color;
                    }
                }
            }
        }


        // 카메라와 캐릭터 사이에 있는 물체 투명화
        Vector3 dir = (player.transform.position - Camera.main.transform.position).normalized;
        float distance = Vector3.Distance(Camera.main.transform.position, player.transform.position);
        hits = Physics.RaycastAll(Camera.main.transform.position, dir, distance);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.gameObject.layer == LayerMask.NameToLayer("Object"))
            {
                
                var mat = hits[i].transform.GetComponent<MeshRenderer>().materials[0];

                Color color = mat.color;

                color.a = 0.1f;
                mat.color = color;


            }

        }


        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            OnOff = !OnOff;
        }


        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        float velocity = 0f;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if(isPossibleJoom)
            {
                currDistance = Mathf.SmoothDamp(currDistance,
           currDistance - scrollValue * 2f, ref velocity, Time.deltaTime);

                currDistance = Mathf.Clamp(currDistance, 2, 5);
            }
           
        }

        // (currDistance - 2) / 3.5f - constant for far camera position
        //var targetPos = player.position + new Vector3(0, (distanceHit - 2) / 3f + cameraPos[1], 0);
        var targetPos = player.position;


        if (player)
        {
            var pos = Input.mousePosition;
            float dpiScale = 1;
            if (Screen.dpi < 1) dpiScale = 1;
            if (Screen.dpi < 200) dpiScale = 1;
            else dpiScale = Screen.dpi / 200f;
            if (pos.x < 380 * dpiScale && Screen.height - pos.y < 250 * dpiScale) return;

            if(isUiOff && UIManager.GetInstance.isOnPopupCount == 0)
            {
                x += (float)(Input.GetAxis("Mouse X") * xRotate * 0.01);
                y -= (float)(Input.GetAxis("Mouse Y") * yRotate * 0.01);
            }
           
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0, 0, -currDistance) + targetPos;

            
            if (isUiOff && UIManager.GetInstance.isOnPopupCount == 0)
            {
                Cursor.visible = false;
                //마우스 잠구는거
                Cursor.lockState = CursorLockMode.Locked;
                saveRotation = rotation;
                savePosition = position;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                rotation = Quaternion.Euler(0, 0, 0);
                rotation = saveRotation;

            }


            if (Physics.Raycast(targetPos, position - targetPos, out hit, (position - targetPos).magnitude, collidingLayers))
            {
                transform.position = position;
                //transform.position = Vector3.Lerp(transform.position, hit.point, Time.deltaTime * 40f);
                //Min(4) distance from ground for camera target point
                //distanceHit = Mathf.Clamp(Vector3.Distance(targetPos, hit.point), 2, 5);
                distanceHit = currDistance;

            }
            else
            {
                //position
                //transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 40f);
                transform.position = position;
                distanceHit = currDistance;

            }
            transform.rotation = rotation;
        }


        if (prevDistance != currDistance)
        {
            prevDistance = currDistance;
            var rot = Quaternion.Euler(y, x, 0);

            var po = rot * new Vector3(0, 0, -currDistance) + targetPos;
            transform.rotation = rot;
            transform.position = po;
        }



        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
            {
                angle += 360;
            }
            if (angle > 360)
            {
                angle -= 360;
            }
            return Mathf.Clamp(angle, min, max);
        }

        #endregion
    }
}