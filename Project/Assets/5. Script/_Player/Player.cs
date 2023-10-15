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
    public PlayerController PController { get { return playerController; } }

    Customizing customizing;

    public RuntimeAnimatorController[] PlayerJob;

    private void Awake()
    {

        //if (null == instance) instance = this;
        if (null == anim) anim = GetComponent<Animator>();
        if (null == nav) nav = GetComponent<NavMeshAgent>();
        if (null == rigid) rigid = GetComponent<Rigidbody>();
        if (null == weaponManager) weaponManager = WeaponManager.GetInstance;
        if (null == playerController) playerController = GetComponent<PlayerController>();
        if (null == customizing) customizing = GetComponent<Customizing>();
        playerStat = PlayerStat.GetInstance;
        playerStat.InitStat(UnitCode.ARCHER);
        PlayerSetting();
        SPEED = 3f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            anim.runtimeAnimatorController = PlayerJob[0];
            playerStat.InitStat(UnitCode.WARRIOR);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            anim.runtimeAnimatorController = PlayerJob[1];
            playerStat.InitStat(UnitCode.MAGE);
        }

        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            anim.runtimeAnimatorController = PlayerJob[2];
            playerStat.InitStat(UnitCode.ARCHER);
        }
    }

    private void PlayerSetting()
    {
        customizing.InitPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
