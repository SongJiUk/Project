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

    [SerializeField] Animator anim;
    [SerializeField] NavMeshAgent nav;
    bool isClickLeftMouse;
    Vector3 MoveDirection = Vector3.zero;
    bool hasStarted = false;
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

    public void Check()
    {
        Debug.Log("wefsfsdfaf");
    }

    public void OnPressQBtn(InputAction.CallbackContext context)
    {

        if (context.performed && !hasStarted)
        {
            Debug.Log("aa");
            hasStarted = true;
            anim.SetTrigger("PressQ");
            anim.applyRootMotion = true;
            nav.ResetPath();
        }
    }

    public void OnPressWBtn(InputAction.CallbackContext context)
    {
        Debug.Log("PressW");
        anim.SetTrigger("PressW");
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            nav.SetDestination(hit.point);
        }
    }


    private void FixedUpdate()
    {
        CheckPlaterVelocity();

        //키보드
        //transform.position += MoveDirection.normalized * Time.deltaTime * 3f;
    }

    public void CheckPlaterVelocity()
    {

        float MoveAnim = nav.remainingDistance < nav.stoppingDistance ? 0f : 1f;
        anim.SetFloat("Velocity", MoveAnim, 0.2f, Time.deltaTime);
    }

    public void EndChargeAttack()
    {
        anim.applyRootMotion = false;
        hasStarted = false;
    }

}
