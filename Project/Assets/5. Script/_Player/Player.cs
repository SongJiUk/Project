using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    private int level;
    public int LEVEL { get { return level; } }

    private float exp;
    public float EXP { get { return exp; } }

    private float hp;
    public float HP { get { return hp; } }

    private float speed;
    public float SPEED { get { return speed; } set { speed = value; } }

    Animator anim;
    NavMeshAgent nav;
    bool isClickLeftMouse;
    bool hasStarted = false;
    bool isUseSkill = false;
    Vector3 MoveDirection = Vector3.zero;
    
    private void Awake()
    {
        //if (null == instance) instance = this;
        SPEED = 3f;

        if (null == anim) anim = GetComponent<Animator>();
        if (null == nav) nav = GetComponent<NavMeshAgent>();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input != null)
        {
            MoveDirection = new Vector3(input.x, 0f, input.y);
           
        }
    }

   
    public void OnPressQBtn(InputAction.CallbackContext context)
    {

        if (context.performed && !hasStarted)
        {
            isUseSkill = true;
            hasStarted = true;
            anim.SetTrigger("PressQ");
            anim.applyRootMotion = true;
            nav.ResetPath();
        }
    }

    public void OnPressEBtn(InputAction.CallbackContext context)
    {
        Debug.Log("PressE");
        anim.SetTrigger("PressE");
    }

    public void OnPressRBtn(InputAction.CallbackContext context)
    {
        Debug.Log("PressR");
        anim.SetTrigger("PressR");
    }

    public void OnPressFBtn(InputAction.CallbackContext context)
    {
        Debug.Log("PressF");
        anim.SetTrigger("PressF");
    }

    public void OnLeftClickOn(InputAction.CallbackContext context)
    {

        if(context.performed && !isClickLeftMouse)
        {
            anim.SetTrigger("Attack");
            isClickLeftMouse = true;
        }

        if(context.canceled)
        {
            isClickLeftMouse = false;
        }
    }
  

    public void OnRightClick(InputAction.CallbackContext context)
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out RaycastHit hit))
        //{
        //    nav.SetDestination(hit.point);
        //}
    }

    private void FixedUpdate()
    {
        if(!isUseSkill)
        {
            transform.Translate(MoveDirection.normalized * Time.deltaTime * SPEED, Space.World);

            float horizontalInput = MoveDirection.x;
            float verticalInput = MoveDirection.z;
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            if (movement != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }

            float MoveAnim = MoveDirection == Vector3.zero ? 0f : 1f;
            anim.SetFloat("Velocity", MoveAnim, 0.5f, Time.deltaTime);
        }
       
    }

    public void EndChargeAttack()
    {
        anim.applyRootMotion = false;
        hasStarted = false;
        isUseSkill = false;
    }

}
