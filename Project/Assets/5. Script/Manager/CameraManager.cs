using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    Player player;


    Vector2 mousePosition;
    Vector3 angles = Vector3.zero;
    bool isRightBtnClick = false;
    float smoothSpeed;


    float LeftWidth = 330f;
    float RightWidth = 30f;
    float UpHeigth = 10f;
    float DownHeight = 350f;
    private void Start()
    {
        if (null == player) player = Player.GetInstance;
        smoothSpeed = 0.3f;
    }

  
    private void LateUpdate()
    {
        float MouseYScroll = Input.mouseScrollDelta.y;



        //Debug.Log(Mathf.Clamp(MouseYScroll, 1f, 1f));

        if(Input.GetMouseButtonDown(1))
        {
            isRightBtnClick = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            isRightBtnClick = false;
        }

        transform.position = player.transform.position;     

        angles = transform.localEulerAngles;
        if (isRightBtnClick)
        {

            Mouse mouse = Mouse.current;
            if (mouse != null)
            {
                Vector2 dir = mousePosition - mouse.position.ReadValue();
                dir.Normalize();
                angles.y += dir.x * smoothSpeed;
                angles.x += dir.y * smoothSpeed;


                if (angles.y < LeftWidth && angles.y > 320f) angles.y = LeftWidth;
                else if (angles.y > RightWidth && angles.y < 40f) angles.y = RightWidth;

                if (angles.x < DownHeight && angles.x > 349f) angles.x = DownHeight;
                else if (angles.x > UpHeigth && angles.x < 11f) angles.x = UpHeigth;

                transform.localEulerAngles = angles;

                mousePosition = mouse.position.ReadValue();

            }
        }


    }
   
}
