using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


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
    #region 플레이어 스탯 정보
    public PlayerStat playerStat;

    #endregion
    Animator anim;
    public Animator ANIM { get { return anim; } private set {  } }
    NavMeshAgent nav;
    public NavMeshAgent NAV { get { return nav; } private set { } }
    Rigidbody rigid;
    public Rigidbody RIGID { get { return rigid; } private set { } }

    WeaponManager weaponManager;
    PlayerController playerController;
    public CapsuleCollider Capsulecollider;
    public PlayerController PController { get { return playerController; } }

    Customizing customizing;

    public RuntimeAnimatorController[] PlayerJob;

    private void Awake()
    {
        if (null == anim) anim = GetComponent<Animator>();
        if (null == nav) nav = GetComponent<NavMeshAgent>();
        if (null == rigid) rigid = GetComponent<Rigidbody>();
        if (null == weaponManager) weaponManager = WeaponManager.GetInstance;
        if (null == playerController) playerController = GetComponent<PlayerController>();
        if (null == customizing) customizing = GetComponent<Customizing>();
        if (null == Capsulecollider) Capsulecollider = GetComponent<CapsuleCollider>();
        playerStat = PlayerStat.GetInstance;
        playerStat.InitStat(DataManager.GetInstance.GET_UnitCodes(DataManager.GetInstance.SLOT_NUM));

        var weapon = weaponManager.FindIndexs(DataManager.GetInstance.GET_WEAPONCODE(DataManager.GetInstance.SLOT_NUM));
        if (weapon != null)
        {
            if (UIManager.GetInstance.weaponManger == null)
            {
                UIManager.GetInstance.ErrorForNull_Reset();
                if (weapon.Type == Types.OneHandMace) UIManager.GetInstance.weaponManger.ChangeWeapon(weapon, weapon, true);
                else UIManager.GetInstance.weaponManger.ChangeWeapon(weapon, null, true);
            }
            else
            {
                if (weapon.Type == Types.OneHandMace) UIManager.GetInstance.weaponManger.ChangeWeapon(weapon, weapon, true);
                else UIManager.GetInstance.weaponManger.ChangeWeapon(weapon, null, true);
            }
        }
            


        PlayerSetting();
        SPEED = 10f;
    }

    public void ChangeMap()
    {

    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    anim.runtimeAnimatorController = PlayerJob[0];
        //    playerStat.InitStat(UnitCode.WARRIOR);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha8))
        //{
        //    anim.runtimeAnimatorController = PlayerJob[1];
        //    playerStat.InitStat(UnitCode.MAGE);
        //}

        //if(Input.GetKeyDown(KeyCode.Alpha7))
        //{
        //    anim.runtimeAnimatorController = PlayerJob[2];
        //    playerStat.InitStat(UnitCode.ARCHER);
        //}

     
    }

    private void PlayerSetting()
    {
        customizing.InitPlayer(DataManager.GetInstance.SLOT_NUM);
        customizing.InitEquipMentItem(DataManager.GetInstance.SLOT_NUM);

        //애니메이션 변경
        var unitcode = DataManager.GetInstance.GET_UnitCodes(DataManager.GetInstance.SLOT_NUM);
        ANIM.runtimeAnimatorController = PlayerJob[(int)unitcode];
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public bool CheckGold(int _price)
    {
        int nowGold = DataManager.GetInstance.GET_PLAYER_GOLD(DataManager.GetInstance.SLOT_NUM);

        if (nowGold >= _price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #region 사운드 관련

    public void AttackSound(string _key)
    {
        AudioManager.GetInstance.PlaySound_PlayerAttack(_key);
    }
    #endregion
}
