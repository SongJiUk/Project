using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    private int level;
    public int LEVEL { get { return level; } }

    private float exp;
    public float EXP { get { return exp; } }

    private float hp;
    public float HP { get { return hp; } }

    [SerializeField] Animator anim;
    bool isClickLeftMouse;
    Vector3 MoveDirection = Vector3.zero;

    private void Awake()
    {
        //if (null == instance) instance = this;
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if(input != null)
        {
            MoveDirection = new Vector3(input.x, 0f, input.y);
            float MoveAnim = MoveDirection == Vector3.zero ? 0f : 1f;
            
            anim.SetFloat("Velocity", MoveAnim);
        }
    }

    public void OnLeftClickOn(InputAction.CallbackContext context)
    {
        
        if(!isClickLeftMouse)
        {
            anim.SetTrigger("Attack");
            Debug.Log("11111");
            isClickLeftMouse = true;

            Invoke("ClickOver", 0.3f);
        }
    }
    public void ClickOver()
    {
        isClickLeftMouse = false;
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        
        //Vector2 input = context.ReadValue<Vector2>();
        //MoveDirection = new Vector3(input.x, 0f, input.y);
        //Debug.Log(MoveDirection);

    }

    
    private void FixedUpdate()
    {
        transform.position += MoveDirection.normalized * Time.deltaTime * 3f;
    }

}
