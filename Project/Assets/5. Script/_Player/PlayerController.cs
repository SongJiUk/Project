using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    Player player;
    WeaponManager weaponManager;
   
    AnimationState stateMachine;


    

    #region 플레이어 콤보공격, 스킬 관련
    private int comboCount = 0;
    private float comboTimer = 0f;
    private float comboDelay = 1f;
    bool isAttack = false;
    bool isAttacking = false;
    bool isDash = false;
    bool isCombing = false;
    bool hasStarted = false;
    bool isUseSkill = false;
    #endregion

    #region 플레이어 점프 관련
    RaycastHit hit;
    float maxHeightDifference = 0.2f;
    float playerHeight;
    float groundHeight;
    bool isJump = false;
    bool isJumpKeyClick = false;
    bool isGround = false;
    #endregion

    #region 플레이어 이동(카메라 각도에 맞게)
    Vector3 MoveDirection = Vector3.zero;
    Vector2 input;
    Vector3 cameraRotation;
    float yRotation;
    Vector3 forwardDirection;
    Vector3 inputDirection;
    float InputX;
    float InputY;
    float MoveAnim;
    Vector3 movement;
    Quaternion targetRotation;
    #endregion

    private void Awake()
    {
        if (null == player) player = Player.GetInstance;
        if (null == weaponManager) weaponManager = WeaponManager.GetInstance;
        comboDelay = 1f;
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        if (input != null)
        {
            cameraRotation = CameraManager.GetInstance.transform.eulerAngles;
            yRotation = cameraRotation.y * Mathf.Deg2Rad;
            forwardDirection = new Vector3(Mathf.Sin(yRotation), 0, Mathf.Cos(yRotation));

            inputDirection = (forwardDirection * input.y + CameraManager.GetInstance.transform.right * input.x).normalized;
            MoveDirection = inputDirection;

        }
    }

    #region Skill
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
        player.ANIM.applyRootMotion = false;
        player.RIGID.velocity = Vector3.zero;
        hasStarted = false;
        isUseSkill = false;
    }
    #endregion


    #region Combo Attack

    public void OnLeftClickOn(InputAction.CallbackContext context)
    {
        
        if (context.canceled && !isAttack)
        {
            Debug.Log("클릭 !");
            isAttack = true;
        }
    }

    public void ComboPossible()
    {
        isCombing = false;
    }

    public void EndCombo()
    {
        isAttack = false;
    }

    public void StartAttack()
    {
        isAttacking = true;
        weaponManager.weapon.Trail.SetActive(true);
    }

    public void EndAttack()
    {
        isAttacking = false;
        weaponManager.weapon.Trail.SetActive(false);
    }
    #endregion

    #region Dash
    public void OnDash(InputAction.CallbackContext context)
    {
        if(!isJump && !isUseSkill && !isAttacking)
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
        player.ANIM.applyRootMotion = false;
        player.RIGID.velocity = Vector3.zero;
        isDash = false;
    }
    #endregion

    #region Jump
    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGround)
        {
            if (context.performed && !isJump && !isJumpKeyClick)
            {
                isJumpKeyClick = true;
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
        player.NAV.enabled = true;
        isJump = false;
        isJumpKeyClick = false;
    }

    #endregion

    #region 장비 장착 및 해제
    public void OnEquip(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            weaponManager.ISEQUIP = !weaponManager.ISEQUIP;
            player.ANIM.SetTrigger("PressX");
            player.ANIM.SetBool("IsEquip", weaponManager.ISEQUIP);
        }
    }


    #endregion
    public void OnRightClick(InputAction.CallbackContext context)
    {
       
    }

    private void FixedUpdate()
    {

        #region Jump Code
        Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Object"));
        playerHeight = player.transform.position.y;
        groundHeight = hit.point.y;

        if (playerHeight - groundHeight <= maxHeightDifference) isGround = true;
        else isGround = false;

        if (isJump)
            if (isGround)
            {
                player.ANIM.SetTrigger("JumpEnd");
                isJump = false;
            }

        #endregion

        #region Combo Attack
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
        #endregion

        if (!isUseSkill && !isAttacking)
        {
            transform.Translate(MoveDirection.normalized * Time.deltaTime * player.SPEED, Space.World);


            InputX = MoveDirection.x;
            InputY = MoveDirection.z;
            movement = new Vector3(InputX, 0f, InputY).normalized;

            if (movement != Vector3.zero)
            {
                targetRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }

            MoveAnim = MoveDirection == Vector3.zero ? 0f : 1f;
            //player.ANIM.SetFloat("Velocity", MoveAnim, 0.5f, Time.deltaTime * 5f);
            player.ANIM.SetFloat("Velocity", MoveAnim, 0.5f, Time.deltaTime * 5f);
            if (MoveAnim != player.ANIM.GetFloat("Velocity"))
            {
                
                //player.ANIM.SetFloat("Velocity", MoveAnim);
            }
        }


        
    }



}
