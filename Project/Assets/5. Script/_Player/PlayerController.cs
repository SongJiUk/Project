using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    Player player;
    Vector3 MoveDirection = Vector3.zero;
   
    AnimationState stateMachine;
    private int comboCount = 0;
    private float comboTimer = 0f;
    public float comboDelay = 1f; // 콤보 딜레이 시간 조절
    public bool isGrounded = false;
    float groundDistanceThreshold = 0.1f;
    RaycastHit hit;
    bool isAttack = false;
    bool hasStarted = false;
    bool isUseSkill = false;
    bool isDash = false;
    bool isJump = false;
    bool isCombing = false;

    private void Awake()
    {
        if (null == player) player = Player.GetInstance;
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input != null)
        {
            Vector3 cameraRotation = CameraManager.GetInstance.transform.eulerAngles;
            float yRotation = cameraRotation.y * Mathf.Deg2Rad;
            Vector3 forwardDirection = new Vector3(Mathf.Sin(yRotation), 0, Mathf.Cos(yRotation));

            Vector3 inputDirection = (forwardDirection * input.y + CameraManager.GetInstance.transform.right * input.x).normalized;
            MoveDirection = inputDirection;

        }
    }

    #region 스킬
    public void OnPressQBtn(InputAction.CallbackContext context)
    {

        if (context.performed && !hasStarted)
        {
            isUseSkill = true;
            hasStarted = true;
            player.ANIM.SetTrigger("PressQ");
            player.ANIM.applyRootMotion = true;
            player.NAV.ResetPath();
        }
    }
    public void OnPressEBtn(InputAction.CallbackContext context)
    {

        if (context.performed && !hasStarted)
        {
            isUseSkill = true;
            hasStarted = true;
            player.ANIM.SetTrigger("PressE");
            player.ANIM.applyRootMotion = true;
            player.NAV.ResetPath();
        }

    }

    public void OnPressRBtn(InputAction.CallbackContext context)
    {

        if (context.performed && !hasStarted)
        {
            isUseSkill = true;
            hasStarted = true;
            player.ANIM.SetTrigger("PressR");
            player.ANIM.applyRootMotion = true;
            player.NAV.ResetPath();
        }

    }

    public void OnPressFBtn(InputAction.CallbackContext context)
    {

        if (context.performed && !hasStarted)
        {
            isUseSkill = true;
            hasStarted = true;
            player.ANIM.SetTrigger("PressF");
            player.ANIM.applyRootMotion = true;
            player.NAV.ResetPath();
        }
    }
    public void EndSkill()
    {
        player.ANIM.applyRootMotion = true;
        hasStarted = false;
        isUseSkill = false;
    }
    #endregion


    #region 콤보 공격

    public void OnLeftClickOn(InputAction.CallbackContext context)
    {

        if (context.performed && !isAttack)
        {
            isAttack = true;
        }
    }

    public void ComboPossible()
    {
        isCombing = false;
    }
    #endregion

    #region 대쉬
    public void OnDash(InputAction.CallbackContext context)
    {
        if(!isJump)
        {
            if (context.performed && !isDash)
            {
                player.ANIM.SetTrigger("Dash");
                player.ANIM.applyRootMotion = true;
                isDash = true;

            }
        }
        
    }
    public void EndDash()
    {
        player.ANIM.applyRootMotion = true;
        isDash = false;
    }
    #endregion

    #region 점프
    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGround())
        {
            if (context.performed)
            {
                player.ANIM.SetTrigger("JumpStart");
                player.NAV.enabled = false;
                player.RIGID.velocity = new Vector3(player.RIGID.velocity.x, 8f, player.RIGID.velocity.z);

            }
        }
       
    }

    public void StartJump()
    {
        isJump = true;
    }
    public void EndJump()
    {
        isJump = false;
        player.NAV.enabled = true;
    }

    public bool isGround()
    {
        float playerHeight = player.transform.position.y;
        float groundHeight = hit.point.y;
        float maxHeightDifference = 0.1f; // 플레이어의 최대 점프 가능 높이 차이
        if (playerHeight - groundHeight <= maxHeightDifference + playerHeight)
        {
            return true;
        }
        return false;
    }
    #endregion

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
        Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f, LayerMask.GetMask("Object"));


        if (isAttack && !isCombing)
        {
            isCombing = true;
            isAttack = false;
            comboCount++;
            comboTimer = comboDelay;

            player.ANIM.SetInteger("ComboCount", comboCount);
            player.ANIM.SetTrigger("Attack");
        }

        if (comboTimer > 0f)
        {
            comboTimer -= Time.deltaTime;
        }
        else
        {
            isCombing = false;
            
            comboCount = 0;
            player.ANIM.SetInteger("ComboCount", 0);
        }

        if (!isUseSkill || !isAttack)
        {
            transform.Translate(MoveDirection.normalized * Time.deltaTime * player.SPEED, Space.World);

            float horizontalInput = MoveDirection.x;
            float verticalInput = MoveDirection.z;
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            if (movement != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }

            float MoveAnim = MoveDirection == Vector3.zero ? 0f : 1f;
            player.ANIM.SetFloat("Velocity", MoveAnim, 0.5f, Time.deltaTime * 5f);
        }


        if(isJump)
        {
            if(!isGround()) player.ANIM.SetTrigger("JumpEnd");
            
        }

        
    }



}
