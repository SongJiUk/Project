using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : Singleton<CameraManager>
{
    Player player;


    Vector2 mousePosition;
    Vector3 angles = Vector3.zero;
    bool isRightBtnClick = false;
    float smoothSpeed;
    float UpHeight = 10f;
    float DownHeight = 330f;
    private void Start()
    {
        angles.x = 340f;
        smoothSpeed = 3f;
    }

   
    private void LateUpdate()
    {
        
        if (player == null)
        {
            if (null == player) player = Player.GetInstance;
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
        }

        if(Input.GetMouseButtonDown(1))
        {
            isRightBtnClick = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            isRightBtnClick = false;
        }


        // 카메라와 캐릭터 사이에 있는 물체 투명화


        Vector3 distance = player.transform.position - Camera.main.transform.position;
        RaycastHit[] hit = Physics.RaycastAll(Camera.main.transform.position, distance,Mathf.Infinity);

        for(int i=0; i <hit.Length; i++)
        {
            if(hit[i].transform.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                var a = hit[i].transform.GetComponent<MeshRenderer>().materials[0];
                Color color = a.color;
                
                if(color.a > 0.3f)
                {
                    color.a -= Time.deltaTime;
                    a.color = color;
                }
                

            }
            
        }


        //transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 10f);;
        transform.position = player.transform.position;

        angles = transform.localEulerAngles;
        if (isRightBtnClick)
        {

            Mouse mouse = Mouse.current;
            if (mouse != null)
            {
                Vector2 dir = mousePosition - mouse.position.ReadValue();
                dir.Normalize();
                angles.y -= dir.x * smoothSpeed;
                angles.x += dir.y * (smoothSpeed / smoothSpeed);
                
                


                //if (angles.y < LeftWidth && angles.y > 320f) angles.y = LeftWidth;
                //else if (angles.y > RightWidth && angles.y < 40f) angles.y = RightWidth;

                if (angles.x < DownHeight && angles.x > DownHeight - 2f && dir.y < 0)
                {
                    angles.x = DownHeight;
                }
                else if (angles.x > UpHeight && angles.x < UpHeight + 2f && dir.y > 0)
                {
                    angles.x = UpHeight;
                }


                transform.localEulerAngles = angles;

                mousePosition = mouse.position.ReadValue();

            }
        }




    }
   
}
