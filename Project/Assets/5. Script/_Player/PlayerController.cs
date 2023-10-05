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


    public GameObject TargetMarker_Front;
    public GameObject TargetMarker_PreCast;
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
    Coroutine myCoroutine;
    RaycastHit Markerhit;
    public bool isGuided = false;
    [SerializeField] GameObject[] Archer_FirePos;
    private bool rotateState = false;
    public float fireRate = 0.1f;
    bool isRealeseHold = false;
    #endregion

    #region 플레이어 점프 관련
    RaycastHit Jumphit;
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
        
    }

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
            if(player.playerStat.unitCode == UnitCode.WARRIOR)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressQ");
                }
            }

            else if(player.playerStat.unitCode == UnitCode.MAGE)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressQ");
                }
            }
            else if(player.playerStat.unitCode == UnitCode.ARCHER)
            {

                if(weaponManager.Weapondata.equipmentType == EquipmentType.Bow)
                {
                    if (context.performed && !SkillStarted)
                    {
                        isUseSkill = true;
                        SkillStarted = true;
                        

                        StartCoroutine(InstantSkill(0));
                        Archer_Bow_Cast[0].GetComponent<ParticleSystem>().Play();
                        //if (Archer_Bow_Cast[0].GetComponent<AudioSource>())
                        //{
                        //    soundComponentCast = Archer_Bow_Cast[3].GetComponent<AudioSource>();
                        //    clip = soundComponentCast.clip;
                        //    soundComponentCast.PlayOneShot(clip);
                        //}


                    }
                }
                else if(weaponManager.Weapondata.equipmentType == EquipmentType.CrossBow)
                {
                    var Enemy = FindNearEnemy();

                    if (Enemy != null)
                    {
                        //가장 가까운적에게 5번 공격
                        if (context.performed && !SkillStarted)
                        {
                            isUseSkill = true;
                            SkillStarted = true;
                            //aimTimer = 2;
                            //if (activeTarger)
                            //{
                            //    if (fireCountdown <= 0f)
                            //    {
                            //        if (rotateState == false)
                            //        {
                            //            StartCoroutine(RotateToTarget(fireRate, target.position));
                            //            //enable turn animation if the turn deviation to the target is more than 20 degrees
                            //            var lookPos = target.position - transform.position;
                            //            lookPos.y = 0;
                            //            var rotation = Quaternion.LookRotation(lookPos);
                            //            var angle = Quaternion.Angle(transform.rotation, rotation);
                            //            if (angle > 20)
                            //            {
                            //                //turn animation
                            //                anim.SetFloat("InputX", 0.3f);
                            //            }
                            //        }
                            //        //StartCoroutine(cameraShaker.Shake(0.4f, 3, 0.3f, 0.9f));
                            //        fireCountdown = 0;
                            //        fireCountdown += fireRate;
                            //    }
                            Archer_CrossBow_Cast[0].GetComponent<ParticleSystem>().Play();
                            Archer_CrossBow_Cast[1].GetComponent<ParticleSystem>().Play();
                            //if (Archer_CrossBow_Cast[10].GetComponent<AudioSource>())
                            //{
                            //    soundComponentCast = Archer_CrossBow_Cast[10].GetComponent<AudioSource>();
                            //    clip = soundComponentCast.clip;
                            //    soundComponentCast.PlayOneShot(clip);
                            //}
                            StartCoroutine(InstantSkill(1));
                            player.ANIM.SetTrigger("PressQ");
                        }
                    }
                    else
                    {
                        //적이 없음을 알려줌
                    }
                    

                    
                    }

                }

        }

        
    }
    public void OnPressEBtn(InputAction.CallbackContext context)
    {
        if (weaponManager.ISEQUIP)
        {
            
            if (player.playerStat.unitCode == UnitCode.WARRIOR)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressE");
                }
            }

            else if (player.playerStat.unitCode == UnitCode.MAGE)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressE");
                }
            }
            else if (player.playerStat.unitCode == UnitCode.ARCHER)
            {
                if(weaponManager.Weapondata.equipmentType == EquipmentType.Bow)
                {
                    if (context.performed && !SkillStarted)
                    {
                        isUseSkill = true;
                        SkillStarted = true;
                        player.ANIM.SetTrigger("PressE");
                    }

                    //캐스트 스킬들 ( 수정 해야됨)
                    if (context.performed)
                    {
                        if (context.interaction is HoldInteraction)
                        {
                            myCoroutine = StartCoroutine(CastSkill(EffectCastType.Front, 1));
                            isCastSkillPress = true;
                            player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                        }
                    }

                    if (context.canceled)
                    {
                        isRealeseHold = true;
                        //StopCoroutine(myCoroutine);
                        TargetMarker_Front.SetActive(false);
                        TargetMarker_PreCast.SetActive(false);
                        isCastSkillPress = false;
                        SkillStarted = false;
                        isUseSkill = false;
                        player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                    }
                }
                else if (weaponManager.Weapondata.equipmentType == EquipmentType.CrossBow)
                {
                    //위로 쏴서 빙결 
                    if (context.performed && !SkillStarted)
                    {
                        isUseSkill = true;
                        SkillStarted = true;
                        player.ANIM.SetTrigger("PressE");
                        
                    }

                    //캐스트 스킬들 ( 수정 해야됨)
                    if (context.performed)
                    {
                        if (context.interaction is HoldInteraction)
                        {
                            myCoroutine = StartCoroutine(CastSkill(EffectCastType.PreCast, 4));
                            isCastSkillPress = true;
                            player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                        }
                        
                    }

                    if (context.canceled)
                    {
                        //StopCoroutine(myCoroutine);
                        isRealeseHold = true;
                        TargetMarker_Front.SetActive(false);
                        TargetMarker_PreCast.SetActive(false);
                        isCastSkillPress = false;
                        SkillStarted = false;
                        isUseSkill = false;
                        player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                    }


                    
                }
                
            }


         
        }
        

    }
   

    public void OnPressRBtn(InputAction.CallbackContext context)
    {
        if (weaponManager.ISEQUIP)
        {
            if (player.playerStat.unitCode == UnitCode.WARRIOR)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressR");
                }
            }
            else if (player.playerStat.unitCode == UnitCode.MAGE)
            {
                if (context.performed && !SkillStarted)
                {
                    isUseSkill = true;
                    SkillStarted = true;
                    player.ANIM.SetTrigger("PressR");
                }
            }
            else if (player.playerStat.unitCode == UnitCode.ARCHER)
            {
                if (weaponManager.Weapondata.equipmentType == EquipmentType.Bow)
                {
                    if (context.performed && !SkillStarted)
                    {
                        isUseSkill = true;
                        SkillStarted = true;
                        player.ANIM.SetTrigger("PressR");
                    }

                    if (context.performed)
                    {
                        if (context.interaction is HoldInteraction)
                        {
                            myCoroutine = StartCoroutine(CastSkill(EffectCastType.PreCast, 3));
                            isCastSkillPress = true;
                            player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                        }
                    }

                    if (context.canceled)
                    {
                        isRealeseHold = true;

                        TargetMarker_Front.SetActive(false);
                        TargetMarker_PreCast.SetActive(false);
                        isCastSkillPress = false;
                        SkillStarted = false;
                        isUseSkill = false;
                        player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                    }
                }
                else if (weaponManager.Weapondata.equipmentType == EquipmentType.CrossBow)
                {
                    //앞으로 용발
                    if (context.performed && !SkillStarted)
                    {
                        isUseSkill = true;
                        SkillStarted = true;
                        player.ANIM.SetTrigger("PressR");

                    }

                    //캐스트 스킬들 ( 수정 해야됨)
                    if (context.performed)
                    {
                        if (context.interaction is HoldInteraction)
                        {
                            myCoroutine = StartCoroutine(CastSkill(EffectCastType.Front, 3));
                            isCastSkillPress = true;
                            player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                        }



                    }

                    if (context.canceled)
                    {
                        isRealeseHold = true;
                        //StopCoroutine(myCorout
                        //ine);
                        TargetMarker_Front.SetActive(false);
                        TargetMarker_PreCast.SetActive(false);
                        isCastSkillPress = false;
                        SkillStarted = false;
                        isUseSkill = false;
                        player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
                    }


                        
                    }


            }
        }
      

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

                
                TargetMarker_PreCast.SetActive(false);
                isCastSkillPress = false;
                SkillStarted = false;
                isUseSkill = false;
                player.ANIM.SetBool("isCastSkillPress", isCastSkillPress);
            }
        }
    }

    public Enemy FindNearEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();



        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // 현재까지 가장 가까운 적보다 더 가까운 적을 찾았을 때 업데이트
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    public IEnumerator RotateToTarget(float rotatingTime, Vector3 targetPoint)
    {
        rotateState = true;
        float delay = rotatingTime;
        var lookPos = targetPoint - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        while (true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 20);
            delay -= Time.deltaTime;
            if (delay <= 0 || transform.rotation == rotation)
            {
                rotateState = false;
                yield break;
            }
            yield return null;
        }
    }


    IEnumerator InstantSkill(int _effectNum)
    {
        while(true)
        {
            if(_effectNum == 0)
            {
                player.ANIM.SetTrigger("PressQ");
                yield return new WaitForSeconds(0.3f);
                //parentObject = Prefabs[EffectNumber].transform.parent;
                //Archer_Bow_Skill[_num].transform.parent = null;
                Archer_Bow_Skill[_effectNum].GetComponent<ParticleSystem>().Play();
                //StartCoroutine(cameraShaker.Shake(0.4f, 7, 0.6f, 0));
                yield return new WaitForSeconds(0.3f);
            }
            else if(_effectNum == 1)
            {
                player.ANIM.SetTrigger("PressQ");
                //secondLayerWeight = Mathf.Lerp(secondLayerWeight, 1f, Time.deltaTime * 60);
                yield return new WaitForSeconds(1.2f);
                var Enemy = FindNearEnemy();
                Archer_CrossBow_Skill[0].transform.position = Enemy.transform.position;
                Archer_CrossBow_Skill[0].GetComponent<ParticleSystem>().Play();
                //if (Archer_CrossBow_Skill[0].GetComponent<AudioSource>())
                //{
                //    soundComponent = Prefabs[EffectNumber].GetComponent<AudioSource>();
                //    clip = soundComponent.clip;
                //    soundComponent.PlayOneShot(clip);
                //}
                //StartCoroutine(cameraShaker.Shake(0.3f, 8, 1.1f, 0.2f));
                yield return new WaitForSeconds(1.5f);
            }
            yield break;
        }
    }

    IEnumerator CastSkill(EffectCastType _markerNum = EffectCastType.None,
        int _effectNum = 999)
    {
        if (_markerNum == EffectCastType.Front) TargetMarker_Front.SetActive(true);
        else if (_markerNum == EffectCastType.PreCast) TargetMarker_PreCast.SetActive(true);

        var forwardCamera = Vector3.zero;
        while (true)
        {
            yield return null;

            if (_markerNum == EffectCastType.Front)
            {
                forwardCamera = Camera.main.transform.forward;
                forwardCamera.y = 0.0f;
                TargetMarker_Front.transform.rotation = Quaternion.LookRotation(forwardCamera);
                transform.rotation = Quaternion.LookRotation(forwardCamera);

            }
            else if(_markerNum == EffectCastType.PreCast)
            {
                forwardCamera = Camera.main.transform.forward;
                forwardCamera.y = 0.0f;
                transform.rotation = Quaternion.LookRotation(forwardCamera);
                Ray ray = new Ray(Camera.main.transform.position + new Vector3(0, 2, 0), Camera.main.transform.forward);
                if (Physics.Raycast(ray, out Markerhit, Mathf.Infinity, collidingLayer))
                {
                    TargetMarker_PreCast.transform.position = Markerhit.point;
                    TargetMarker_PreCast.transform.rotation = Quaternion.FromToRotation(Vector3.up, Markerhit.normal) * Quaternion.LookRotation(forwardCamera);
                }
                else
                {
                    TargetMarker_PreCast.SetActive(false);
                }
            }
            
            if (Input.GetMouseButtonDown(0) && isCastSkillPress)
            {
                player.ANIM.SetTrigger("SkillClick");
                TargetMarker_PreCast.SetActive(false);
                TargetMarker_Front.SetActive(false);
                //if (rotateState == false)
                //{
                //    StartCoroutine(RotateToTarget(0.5f, vecPos));
                //}
                isUseSkill = false;
                SkillStarted = false;

                if (_markerNum == EffectCastType.Front)
                {
                    if (_effectNum == 1)
                    {
                        Archer_Bow_Cast[1].GetComponent<ParticleSystem>().Play();
                        //    //soundComponentCast = PrefabsCast[4].GetComponent<AudioSource>();
                        //    //clip = soundComponentCast.clip;
                        //    //soundComponentCast.PlayOneShot(clip);
                    }
                    else if (_effectNum == 2)
                    {
                        Archer_Bow_Cast[2].GetComponent<ParticleSystem>().Play();
                    }
                    else if(_effectNum == 3)
                    {
                        
                            //if (Archer_CrossBow_Cast[4].GetComponent<AudioSource>())
                            //{
                            //    soundComponentCast = Archer_CrossBow_Cast[4].GetComponent<AudioSource>();
                            //    clip = soundComponentCast.clip;
                            //    soundComponentCast.PlayOneShot(clip);
                            //}
                            Archer_CrossBow_Cast[4].GetComponent<ParticleSystem>().Play();
                            yield return new WaitForSeconds(0.15f); //0.15s
                        
                    }

                    if (_effectNum == 1) //위에가 Bow 밑이 CrossBow /
                    {
                        Archer_Bow_Skill[1].transform.rotation = Quaternion.LookRotation(forwardCamera);
                        var effect = Archer_Bow_Skill[1].GetComponent<ParticleSystem>();
                        effect.Play();
                        //StartCoroutine(cameraShaker.Shake(0.5f, 7, 0.6f, 0.26f));
                        yield return new WaitForSeconds(1.3f);
                        Archer_Bow_Skill[1].transform.localPosition = new Vector3(0, 1, 0);
                        Archer_Bow_Skill[1].transform.localRotation = Quaternion.identity;
                        
                    }
                    else if(_effectNum == 3)
                    {
                        //StartCoroutine(cameraShaker.Shake(0.5f, 6, 1.3f, 0.0f));

                        foreach (var component in Archer_CrossBow_Skill[2].GetComponentsInChildren<FrontAttack>())
                        {
                            component.playMeshEffect = true;
                        }
                        yield return new WaitForSeconds(1f);
                        Archer_CrossBow_Skill[2].transform.localPosition = new Vector3(0, 0, 0);
                        Archer_CrossBow_Skill[2].transform.localRotation = Quaternion.identity;

                    }
                }
                else if(_markerNum == EffectCastType.PreCast)
                {
                    if (_effectNum == 3)
                    {

                        //if (PrefabsCast[5].GetComponent<AudioSource>())
                        //{
                        //    soundComponentCast = PrefabsCast[5].GetComponent<AudioSource>();
                        //    clip = soundComponentCast.clip;
                        //    soundComponentCast.PlayOneShot(clip);
                        //}
                        //StartCoroutine(cameraShaker.Shake(0.4f, 9, 0.4f, 0.2f));
                        for (int i = 2; i <= 3; i++)
                        {
                            Archer_Bow_Cast[i].GetComponent<ParticleSystem>().Play();
                        }
                        yield return new WaitForSeconds(0.8f);
                        //StartCoroutine(cameraShaker.Shake(0.5f, 7, 1.4f, 0));

                        Archer_Bow_Skill[2].transform.position = Markerhit.point;
                        Archer_Bow_Skill[2].transform.rotation = Quaternion.LookRotation(forwardCamera);
                        Archer_Bow_Skill[2].GetComponent<ParticleSystem>().Play();

                        //if (Archer_Bow_Cast[3].GetComponent<AudioSource>())
                        //{
                        //    soundComponent = Prefabs[3].GetComponent<AudioSource>();
                        //    clip = soundComponent.clip;
                        //    soundComponent.PlayOneShot(clip);
                        //}
                    }
                    else if(_effectNum == 4)
                    {
                        //StartCoroutine(cameraShaker.Shake(0.4f, 8, 0.4f, 0.2f));
                        Archer_CrossBow_Cast[2].GetComponent<ParticleSystem>().Play();
                        //if (Archer_CrossBow_Cast[2].GetComponent<AudioSource>())
                        //{
                        //    soundComponentCast = Archer_CrossBow_Cast[2].GetComponent<AudioSource>();
                        //    clip = soundComponentCast.clip;
                        //    soundComponentCast.PlayOneShot(clip);
                        //}
                        Archer_CrossBow_Cast[3].GetComponent<ParticleSystem>().Play();
                        yield return new WaitForSeconds(0.8f);
                        //StartCoroutine(cameraShaker.Shake(0.3f, 7, 0.4f, 0));

                        Archer_CrossBow_Skill[1].transform.position = Markerhit.point;
                        Archer_CrossBow_Skill[1].transform.rotation = Quaternion.LookRotation(forwardCamera);
                        Archer_CrossBow_Skill[1].transform.parent = null;
                        Archer_CrossBow_Skill[1].GetComponent<ParticleSystem>().Play();
                        //if (Archer_CrossBow_Skill[1].GetComponent<AudioSource>())
                        //{
                        //    soundComponent = Archer_CrossBow_Skill[1].GetComponent<AudioSource>();
                        //    clip = soundComponent.clip;
                        //    soundComponent.PlayOneShot(clip);
                        //}
                    }

                    if (_effectNum == 4)
                    {
                        yield return new WaitForSeconds(2f);
                        Archer_CrossBow_Skill[1].transform.localPosition = new Vector3(0, 1, 0);
                        Archer_CrossBow_Skill[1].transform.localRotation = Quaternion.identity;
                    }
                }


                yield break;
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

        if(player.playerStat.unitCode == UnitCode.MAGE)
        {
            if (weaponManager.Weapondata.equipmentType == EquipmentType.Staff)
            {
                var StaffObj = Instantiate(Mage_LongDistanceAttackObj[0]);
                StaffObj.transform.position = transform.position + Vector3.up;
            }
            else if (weaponManager.Weapondata.equipmentType == EquipmentType.Orb)
            {
                var OrbObj = Instantiate(Mage_LongDistanceAttackObj[1]);
                OrbObj.transform.position = transform.position + Vector3.up;
            }
        }
        else if(player.playerStat.unitCode == UnitCode.ARCHER)
        {
            var ArrowObj = Instantiate(Archer_LongDistanceAttackOb[0]);
            if (weaponManager.Weapondata.equipmentType == EquipmentType.Bow)
            {
                ArrowObj.transform.position = Archer_FirePos[0].transform.position;
                ArrowObj.transform.rotation = transform.rotation;
            }
            else if(weaponManager.Weapondata.equipmentType == EquipmentType.CrossBow)
            {
                ArrowObj.transform.position = Archer_FirePos[1].transform.position;
                ArrowObj.transform.rotation = transform.rotation;
            }
            
            
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
        Physics.Raycast(transform.position, Vector3.down, out Jumphit, Mathf.Infinity, LayerMask.GetMask("Object"));
        playerHeight = player.transform.position.y;
        groundHeight = Jumphit.point.y;

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
