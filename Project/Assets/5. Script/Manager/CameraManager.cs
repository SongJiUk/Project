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
        if (null == player) player = Player.GetInstance;
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        angles.x = 340f;
        smoothSpeed = 2f;
    }


    private void LateUpdate()
    {

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
