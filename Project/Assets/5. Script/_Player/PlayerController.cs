using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    Player player;
    WeaponManager weaponManager;
   
    AnimationState stateMachine;


    public GameObject TargetMarker;
    public LayerMask collidingLayer = ~0;

    #region 플레이어 콤보공격, 스킬 관련
    private int comboCount = 0;
    private float comboTimer = 0f;
    private float comboDelay;
    bool isAttack = false;
    bool isAttacking = false;
    bool isDash = false;
    bool isCombing = false;
    bool SkillStarted = false;
    bool isUseSkill = false;

    bool isCastSkillPress = false;
    [SerializeField] GameObject[] Mage_LongDistanceAttackObj;
    [SerializeField] GameObject[] Archer_LongDistanceAttackOb;

    [SerializeField] GameObject[] Archer_Bow_Skill;
    [SerializeField] GameObject[] Archer_Bow_Cast;
    [SerializeField] GameObject[] Archer_CrossBow_Skill;
    [SerializeField] GameObject[] Archer_CrossBow_Cast;

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



    private void Start()
    {
        if (null == player) player = Player.GetInstance;
        if (null == weaponManager) weaponManager = WeaponManager.GetInstance;

        if (null != player.playerStat)
        {
            comboDelay = player.playerStat.ComboDelay;
        }
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
        if(weaponManager.ISEQUIP)
        {
            if(weaponManager.Weapondata.playerjob == PlayerJobs.Warrior)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressQ");
                }
            }

            else if(weaponManager.Weapondata.playerjob == PlayerJobs.Mage)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressQ");
                }
            }
            else if(weaponManager.Weapondata.playerjob == PlayerJobs.Archer)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressQ");
                }

                /*
         * Bow
         * 
        StartCoroutine(Attack(1)); 
        PrefabsCast[3].GetComponent<ParticleSystem>().Play();
        if (PrefabsCast[3].GetComponent<AudioSource>())
        {
            soundComponentCast = PrefabsCast[3].GetComponent<AudioSource>();
            clip = soundComponentCast.clip;
            soundComponentCast.PlayOneShot(clip);
        }

        if (EffectNumber == 1)
        {
            anim.SetTrigger("AoE");
       //////////// 0.3초?////////////
            yield return new WaitForSeconds(castingTime[EffectNumber]);
            parentObject = Prefabs[EffectNumber].transform.parent;
            Prefabs[EffectNumber].transform.parent = null;
            Prefabs[EffectNumber].GetComponent<ParticleSystem>().Play();
            StartCoroutine(cameraShaker.Shake(0.4f, 7, 0.6f, 0));
            yield return new WaitForSeconds(castingTime[EffectNumber]);
        }


        CrossBow
        aimTimer = 2;
            if (activeTarger)
            {
                if (fireCountdown <= 0f)
                {
                    if (rotateState == false)
                    {
                        StartCoroutine(RotateToTarget(fireRate, target.position));
                        //enable turn animation if the turn deviation to the target is more than 20 degrees
                        var lookPos = target.position - transform.position;
                        lookPos.y = 0;
                        var rotation = Quaternion.LookRotation(lookPos);
                        var angle = Quaternion.Angle(transform.rotation, rotation);
                        if (angle > 20)
                        {
                            //turn animation
                            anim.SetFloat("InputX", 0.3f);
                        }
                    }             
                    StartCoroutine(cameraShaker.Shake(0.4f, 3, 0.3f, 0.9f));
                    fireCountdown = 0;
                    fireCountdown += fireRate;
                }
                PrefabsCast[9].GetComponent<ParticleSystem>().Play();
                PrefabsCast[10].GetComponent<ParticleSystem>().Play();
                if (PrefabsCast[10].GetComponent<AudioSource>())
                {
                    soundComponentCast = PrefabsCast[10].GetComponent<AudioSource>();
                    clip = soundComponentCast.clip;
                    soundComponentCast.PlayOneShot(clip);
                }
                StartCoroutine(Attack(6));
            }

        if (EffectNumber == 6)
            {
                anim.SetTrigger("MaskAttack2");
                secondLayerWeight = Mathf.Lerp(secondLayerWeight, 1f, Time.deltaTime * 60);
                yield return new WaitForSeconds(castingTime[EffectNumber]);
                parentObject = Prefabs[EffectNumber].transform.parent;
                Prefabs[EffectNumber].transform.parent = null;
                Prefabs[EffectNumber].transform.position = target.position;
                Prefabs[EffectNumber].GetComponent<ParticleSystem>().Play();
                if (Prefabs[EffectNumber].GetComponent<AudioSource>())
                {
                    soundComponent = Prefabs[EffectNumber].GetComponent<AudioSource>();
                    clip = soundComponent.clip;
                    soundComponent.PlayOneShot(clip);
                }
                StartCoroutine(cameraShaker.Shake(0.3f, 8, 1.1f, 0.2f));
                yield return new WaitForSeconds(1.5f);
            }
        */
            }

        }

        
    }
    public void OnPressEBtn(InputAction.CallbackContext context)
    {
        if (weaponManager.ISEQUIP)
        {
            if (weaponManager.Weapondata.playerjob == PlayerJobs.Warrior)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressE");
                }
            }

            else if (weaponManager.Weapondata.playerjob == PlayerJobs.Mage)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressE");
                }
            }
            else if (weaponManager.Weapondata.playerjob == PlayerJobs.Archer)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressE");
                }
            }


         
        }
        /*
        * Bow
        if (EffectNumber == 2)
                   {
                       PrefabsCast[4].GetComponent<ParticleSystem>().Play();
                       soundComponentCast = PrefabsCast[4].GetComponent<AudioSource>();
                       clip = soundComponentCast.clip;
                       soundComponentCast.PlayOneShot(clip);
                   } 
        *
        *
        *CrossBow
        *if (EffectNumber == 7)
                    {
                        anim.SetTrigger("UpAttack2");
                        StartCoroutine(cameraShaker.Shake(0.4f, 8, 0.4f, 0.2f));
                        PrefabsCast[11].GetComponent<ParticleSystem>().Play();
                        if (PrefabsCast[11].GetComponent<AudioSource>())
                        {
                            soundComponentCast = PrefabsCast[11].GetComponent<AudioSource>();
                            clip = soundComponentCast.clip;
                            soundComponentCast.PlayOneShot(clip);
                        }
                        PrefabsCast[12].GetComponent<ParticleSystem>().Play();
                        yield return new WaitForSeconds(castingTime[EffectNumber]);
                        StartCoroutine(cameraShaker.Shake(0.3f, 7, 0.4f, 0));
                        parentObject = Prefabs[7].transform.parent;
                        Prefabs[7].transform.position = hit.point;
                        Prefabs[7].transform.rotation = Quaternion.LookRotation(forwardCamera);
                        Prefabs[7].transform.parent = null;
                        Prefabs[7].GetComponent<ParticleSystem>().Play();
                        if (Prefabs[7].GetComponent<AudioSource>())
                        {
                            soundComponent = Prefabs[7].GetComponent<AudioSource>();
                            clip = soundComponent.clip;
                            soundComponent.PlayOneShot(clip);
                        }
                    }
        */

    }

    public void OnPressRBtn(InputAction.CallbackContext context)
    {
        if (weaponManager.ISEQUIP)
        {



            if (context.performed && !SkillStarted)
            {
                isUseSkill = true;
                SkillStarted = true;
                player.ANIM.SetTrigger("PressR");
                //player.ANIM.applyRootMotion = true;
               // player.NAV.ResetPath();
            }

            //캐스트 스킬들 ( 수정 해야됨)
            if (context.performed)
            {
                if (context.interaction is HoldInteraction)
                {
                    StartCoroutine(CastSkill());
                    isCastSkillPress = true;
                    player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                }
            }

            if (context.canceled)
            {

                StopCoroutine(CastSkill());
                TargetMarker.SetActive(false);
                isCastSkillPress = false;
                SkillStarted = false;
                isUseSkill = false;
                player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
            }
        }
        /*
       * Bow
       *  if (EffectNumber == 3)
                  {
                      anim.SetTrigger("UpAttack");
                      if (PrefabsCast[5].GetComponent<AudioSource>())
                      {
                          soundComponentCast = PrefabsCast[5].GetComponent<AudioSource>();
                          clip = soundComponentCast.clip;
                          soundComponentCast.PlayOneShot(clip);
                      }
                      StartCoroutine(cameraShaker.Shake(0.4f, 9, 0.4f, 0.2f));
                      for (int i = 5; i <= 6; i++)
                      {
                          PrefabsCast[i].GetComponent<ParticleSystem>().Play();
                      }
                      yield return new WaitForSeconds(castingTime[EffectNumber]);
                      StartCoroutine(cameraShaker.Shake(0.5f, 7, 1.4f, 0));
                      parentObject = Prefabs[3].transform.parent;
                      Prefabs[3].transform.position = hit.point;
                      Prefabs[3].transform.rotation = Quaternion.LookRotation(forwardCamera);
                      Prefabs[3].transform.parent = null;
                      Prefabs[3].GetComponent<ParticleSystem>().Play();
                      if (PrefabsCast[3].GetComponent<AudioSource>())
                      {
                          soundComponent = Prefabs[3].GetComponent<AudioSource>();
                          clip = soundComponent.clip;
                          soundComponent.PlayOneShot(clip);
                      }
                  }

      CrossBow
                            if (EffectNumber == 8)
                    {
                        if (PrefabsCast[13].GetComponent<AudioSource>())
                        {
                            soundComponentCast = PrefabsCast[13].GetComponent<AudioSource>();
                            clip = soundComponentCast.clip;
                            soundComponentCast.PlayOneShot(clip);
                        }
                        PrefabsCast[13].GetComponent<ParticleSystem>().Play();
                        yield return new WaitForSeconds(castingTime[EffectNumber]);
                    }
       */

    }

    public void OnPressFBtn(InputAction.CallbackContext context)
    {
        if (weaponManager.ISEQUIP)
        {
            if (context.performed && !SkillStarted)
            {
                isUseSkill = true;
                SkillStarted = true;
                player.ANIM.SetTrigger("PressF");
                //player.ANIM.applyRootMotion = true;
                //player.NAV.ResetPath();
               
            }

            
            //캐스트 스킬들 ( 수정 해야됨)
            if (context.performed)
            {
                if (context.interaction is HoldInteraction)
                {
                    StartCoroutine(CastSkill());
                    isCastSkillPress = true;
                    player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                }
            }

            if (context.canceled)
            {

                StopCoroutine(CastSkill());
                TargetMarker.SetActive(false);
                isCastSkillPress = false;
                SkillStarted = false;
                isUseSkill = false;
                player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
            }
        }

       
    }

    IEnumerator CastSkill()
    {
        TargetMarker.SetActive(true);
        while (true)
        {
            yield return null;
            var forwardCamera = Camera.main.transform.forward;
            forwardCamera.y = 0.0f;
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position + new Vector3(0, 2, 0), Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, collidingLayer))
            {
                TargetMarker.transform.position = hit.point;
                TargetMarker.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal) * Quaternion.LookRotation(forwardCamera);
            }
            else
            {
                //aim.enabled = true;
                TargetMarker.SetActive(false);
            }

            if(Input.GetMouseButtonDown(0) && isCastSkillPress)
            {
                Debug.Log("눌렀어!!!");
                player.ANIM.SetTrigger("SkillClick");
                TargetMarker.SetActive(false);
                isUseSkill = false;
                SkillStarted = false;
                break;
            }
        }
    }
    public void EndSkill()
    {
        //player.ANIM.applyRootMotion = false;
       // player.RIGID.velocity = Vector3.zero;
        SkillStarted = false;
        isUseSkill = false;
    }

    public void EndCastSkill()
    {
        isCastSkillPress = false;
        SkillStarted = false;
        player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
    }
  
    #endregion


    #region Combo Attack

    public void OnLeftClickOn(InputAction.CallbackContext context)
    {
        
        if (context.canceled && !isAttack && !isCastSkillPress)
        {
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
        comboCount = 0;
        player.ANIM.SetInteger("ComboCount", comboCount);
    }

    public void StartAttack()
    {
        isAttacking = true;

    }

    public void EndAttack()
    {
        isAttacking = false;
        comboTimer = 0f;
    }

    public void LongDistanceAttack()
    {
        if(weaponManager.Weapondata.equipmentType == EquipmentType.Staff)
        {
            var StaffObj = Instantiate(Mage_LongDistanceAttackObj[0]);
            StaffObj.transform.position = transform.position + Vector3.up;
        }
        else if(weaponManager.Weapondata.equipmentType == EquipmentType.Orb)
        {
            var StaffObj = Instantiate(Mage_LongDistanceAttackObj[1]);
            StaffObj.transform.position = transform.position + Vector3.up;

        }
        
    }

    #endregion

    #region Dash
    public void OnDash(InputAction.CallbackContext context)
    {
        if(!isJump && !isUseSkill && !isAttacking && !isUseSkill)
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
            player.ANIM.SetInteger("ComboCount", comboCount);
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
