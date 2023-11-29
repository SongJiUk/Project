using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Player))]
public class PlayerStat : Singleton<PlayerStat>
{

    public static float CriticalDamgeMul = 2f;

    static float Warrior_LevelUpDamage = 10f;
    static float Mage_LevelUpDamage = 5f;
    static float Archer_LevelUpDamage = 8f;

    static int Warrior_LevelUpHP = 30;
    static int Mage_LevelUpHP = 15;
    static int Archer_LevelUpHP = 10;

    static int Warrior_LevelUpMP = 10;
    static int Mage_LevelUpMP = 15;
    static int Archer_LevelUpMP = 30;

    static int W_DefaultHP = 100;
    static int M_DefaultHP = 50;
    static int A_DefaultHP = 75;

    static int W_DefaultMP = 50;
    static int M_DefaultMP = 100;
    static int A_DefaultMP = 70;

    static float W_DefaultDamage = 10f;
    static float M_DefaultDamage = 8f;
    static float A_DefaultDamage = 5f;

    static float W_DefaultSpeed = 2f; 
    static float M_DefaultSpeed = 3f; 
    static float A_DefaultSpeed = 4f;

    static float W_DefaultDefence = 3f;
    static float M_DefaultDefence = 1f;
    static float A_DefaultDefence = 1f;

    static float W_DefaultAvoidance = 1f;
    static float M_DefaultAvoidance = 2f;
    static float A_DefaultAvoidance = 3f;

    static float W_DefaultCriticalChance = 0f;
    static float M_DefaultCriticalChance = 20f;
    static float A_DefaultCriticalChance = 50f;


    public static float W_Skill1_Cooltime = 10f;
    public static float W_Skill2_Cooltime = 15f;
    public static float W_Skill3_Cooltime = 20f;

    public float W_Skill1_time;
    public float W_Skill2_time;
    public float W_Skill3_time;

    public static float M_Skill1_Cooltime = 5f;
    public static float M_Skill2_Cooltime = 10f;
    public static float M_Skill3_Cooltime = 20f;

    public float M_Skill1_time;
    public float M_Skill2_time;
    public float M_Skill3_time;

    public static float A_Skill1_Cooltime = 7f;
    public static float A_Skill2_Cooltime = 13f;
    public static float A_Skill3_Cooltime = 20f;

    public float A_Skill1_time;
    public float A_Skill2_time;
    public float A_Skill3_time;

    public bool isPossibleUseSkill1 = false;
    public bool isPossibleUseSkill2 = false;
    public bool isPossibleUseSkill3 = false;


    public UnitCode UnitCodes { get; set; }
    public int Level { get; set; }
    public int SlotNum { get; set; }

    public int MaxHp { get; set; }
    public int MaxMp { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float ComboDelay { get; set; }
    public float Defence { get; set; }
    public float Avoidance { get; set; } //회피율
    public float CriticalChance { get; set; }




    public float NowHp { get; set; }
    public float NowMp { get; set; }
    public float MaxExp { get; set; }
    public float NowExp { get; set; }
    float Hpvalue = 0;
    float Mpvalue = 0;
    float Expvalue = 0;

    public int WeaponDamage;
    public int EquipmentDefence;

    public EGender gender { get; set; }

    PlayerBarManager _playerBarManager;


    PlayerController playerController;

    static public float WARRIOR_SkillUpDamagePercent = 1.1f;
    static public float MAGE_SkillUpDamagePercent = 1.3f;
    static public float ARCHER_SkillUpDamagePercent= 1.3f;


    [SerializeField] GameObject LevelupEffect;
    [SerializeField] EquipmentUI equipmentUI;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void InitStat(UnitCode _UnitCodes)
    {
        int slotNum = DataManager.GetInstance.SLOT_NUM;
        Level = DataManager.GetInstance.GET_PLAYER_LEVEL(slotNum);
        UnitCodes = _UnitCodes;
        switch (UnitCodes)
        {
            case UnitCode.WARRIOR:
                ComboDelay = 1.5f;
                if(DataManager.GetInstance.GET_ISCREATE(DataManager.GetInstance.SLOT_NUM))
                {
                    MaxHp = W_DefaultHP;
                    MaxMp = W_DefaultMP;
                    Damage = W_DefaultDamage;
                    Speed = W_DefaultSpeed;
                    Defence = W_DefaultDefence;
                    Avoidance = W_DefaultAvoidance;
                    CriticalChance = W_DefaultCriticalChance;
                    NowHp = MaxHp;
                    NowMp = MaxMp;
                    NowExp = 0;
                    MaxExp = Level * DataManager.LevelUpEXP;
                    DataManager.GetInstance.SET_ISCREATE(DataManager.GetInstance.SLOT_NUM, false);
                }
                else
                {
                    MaxHp = DataManager.GetInstance.GET_PLAYER_MAXHP(slotNum);
                    MaxMp = DataManager.GetInstance.GET_PLAYER_MAXMP(slotNum);
                    Damage = DataManager.GetInstance.GET_PLAYER_DAMAGE(slotNum);
                    Speed = DataManager.GetInstance.GET_PLAYER_SPEED(slotNum);
                    Defence = DataManager.GetInstance.GET_PLAYER_DEFENCE(slotNum);
                    Avoidance = DataManager.GetInstance.GET_PLAYER_AVOIDANCE(slotNum);
                    CriticalChance = DataManager.GetInstance.GET_PLAYER_CRITICALCHANCE(SlotNum);
                    NowHp = DataManager.GetInstance.GET_PLAYER_NOWHP(slotNum);
                    NowMp = DataManager.GetInstance.GET_PLAYER_NOWMP(slotNum);
                    NowExp = DataManager.GetInstance.GET_PLAYER_EXP(slotNum);
                    MaxExp = Level * DataManager.LevelUpEXP;
                }
                break;

            case UnitCode.MAGE:
                ComboDelay = 2f;
                if (DataManager.GetInstance.GET_ISCREATE(DataManager.GetInstance.SLOT_NUM))
                {
                    MaxHp = M_DefaultHP;
                    MaxMp = M_DefaultMP;
                    Damage = M_DefaultDamage;
                    Speed = M_DefaultSpeed;
                    Defence = M_DefaultDefence;
                    Avoidance = M_DefaultAvoidance;
                    CriticalChance = M_DefaultCriticalChance;
                    NowHp = MaxHp;
                    NowMp = MaxMp;
                    NowExp = 0;
                    MaxExp = Level * DataManager.LevelUpEXP;
                    DataManager.GetInstance.SET_ISCREATE(DataManager.GetInstance.SLOT_NUM, false);
                }
                else
                {
                    MaxHp = DataManager.GetInstance.GET_PLAYER_MAXHP(slotNum);
                    MaxMp = DataManager.GetInstance.GET_PLAYER_MAXMP(slotNum);
                    Damage = DataManager.GetInstance.GET_PLAYER_DAMAGE(slotNum);
                    Speed = DataManager.GetInstance.GET_PLAYER_SPEED(slotNum);
                    Defence = DataManager.GetInstance.GET_PLAYER_DEFENCE(slotNum);
                    Avoidance = DataManager.GetInstance.GET_PLAYER_AVOIDANCE(slotNum);
                    CriticalChance = DataManager.GetInstance.GET_PLAYER_CRITICALCHANCE(SlotNum);
                    NowHp = DataManager.GetInstance.GET_PLAYER_NOWHP(slotNum);
                    NowMp = DataManager.GetInstance.GET_PLAYER_NOWMP(slotNum);
                    NowExp = DataManager.GetInstance.GET_PLAYER_EXP(slotNum);
                    MaxExp = Level * DataManager.LevelUpEXP;

                }
                break;

            case UnitCode.ARCHER:
                ComboDelay = 1f;
                if (DataManager.GetInstance.GET_ISCREATE(DataManager.GetInstance.SLOT_NUM))
                {
                    MaxHp = A_DefaultHP;
                    MaxMp = A_DefaultMP;
                    Damage = A_DefaultDamage;
                    Speed = A_DefaultSpeed;
                    Defence = A_DefaultDefence;
                    Avoidance = A_DefaultAvoidance;
                    CriticalChance = A_DefaultCriticalChance;
                    NowHp = MaxHp;
                    NowMp = MaxMp;
                    NowExp = 0;
                    MaxExp = Level * DataManager.LevelUpEXP;
                    DataManager.GetInstance.SET_ISCREATE(DataManager.GetInstance.SLOT_NUM, false);
                }
                else
                {
                    MaxHp = DataManager.GetInstance.GET_PLAYER_MAXHP(slotNum);
                    MaxMp = DataManager.GetInstance.GET_PLAYER_MAXMP(slotNum);
                    Damage = DataManager.GetInstance.GET_PLAYER_DAMAGE(slotNum);
                    Speed = DataManager.GetInstance.GET_PLAYER_SPEED(slotNum);
                    Defence = DataManager.GetInstance.GET_PLAYER_DEFENCE(slotNum);
                    Avoidance = DataManager.GetInstance.GET_PLAYER_AVOIDANCE(slotNum);
                    CriticalChance = DataManager.GetInstance.GET_PLAYER_CRITICALCHANCE(SlotNum);
                    NowHp = DataManager.GetInstance.GET_PLAYER_NOWHP(slotNum);
                    NowMp = DataManager.GetInstance.GET_PLAYER_NOWMP(slotNum);
                    NowExp = DataManager.GetInstance.GET_PLAYER_EXP(slotNum);
                    MaxExp = Level * DataManager.LevelUpEXP;
                }
                break;
        }
        ChangeEnum(DataManager.GetInstance.GET_GENDERNUM(DataManager.GetInstance.SLOT_NUM));
        _playerBarManager = PlayerBarManager.instance;
        _playerBarManager.SetStartUI();

        CheckHp();
        CheckMp();
        CheckExp();
        SetNowHP(Hpvalue);
        SetNowMP(Mpvalue);
        SetNowEXP(Expvalue);
        SaveData();


    }


    public bool PlayerAttackCriticalCheck()
    {
        float rand = Random.Range(1f, 100f);

        if (rand < CriticalChance) return true;
        else return false;
    }

    public bool CheckAvoidance()
    {
        int rand = Random.Range(0, 101);

        if (rand <= Avoidance) return true;
        else return false;
    }

    public void Character_For_Stat(int _level)
    {
        
    }


    public void SetStart(int _MaxHP, int _MaxMP, int _MaxEXP)
    {
        _playerBarManager = PlayerBarManager.instance;
        MaxHp = _MaxHP;
        NowHp = MaxHp;
        MaxMp = _MaxMP;
        NowMp = MaxMp;
        MaxExp = _MaxEXP;
        NowExp = 0;
        _playerBarManager.SetMax(MaxHp, MaxMp);
    }

    public void ChangeEnum(int _num)
    {
        switch(_num)
        {
            case 0:
                gender = EGender.Female;
                break;

            case 1:
                gender = EGender.male;
                break;
        }
    }

    public void ChangeStat(ArmorItemData _beforeItem, ArmorItemData _afterItem)
    {
        //Defence -= _beforeItem.Defence;
       //Defence += _afterItem.Defence;
    }

    public void ChangeStat(ArmorItemData _item)
    {
        //Defence += _item.Defence;
    }

    public void LevelUp()
    {
        Level++;
        MaxExp = DataManager.LevelUpEXP * Level;
        AudioManager.GetInstance.PlayerSound("LevelUP");
        switch(UnitCodes)
        {
            case UnitCode.WARRIOR:
                Damage += Warrior_LevelUpDamage;

                MaxHp += Warrior_LevelUpHP;
                MaxMp += Warrior_LevelUpMP;
                NowHp = MaxHp;
                NowMp = MaxMp;

                Defence += 1f;
                Avoidance += 1f;
                CriticalChance += 2f;


                break;

            case UnitCode.MAGE:
                Damage += Mage_LevelUpDamage;

                MaxHp += Mage_LevelUpHP;
                MaxMp += Mage_LevelUpMP;
                NowHp = MaxHp;
                NowMp = MaxMp;

                Defence += 2f;
                Avoidance += 1f;
                CriticalChance += 2f;

                break;

            case UnitCode.ARCHER:
                Damage += Archer_LevelUpDamage;

                MaxHp += Archer_LevelUpHP;
                MaxMp += Archer_LevelUpMP;
                NowHp = MaxHp;
                NowMp = MaxMp;


                Defence += 2f;
                Avoidance += 3f;
                CriticalChance += 1f;

                break;

        }

        //이펙트
        LevelupEffect.SetActive(true);
        LevelupEffect.GetComponent<ParticleSystem>().Play();
        CheckHp();
        CheckMp();
        CheckExp();
        SetNowHP(Hpvalue);
        SetNowMP(Mpvalue);
        SetNowEXP(Expvalue);
        DamageNum.instance.LevelUP();
        equipmentUI.LevelUP();
        SaveData();
    }


    private void SaveData()
    {
        int slotnum = DataManager.GetInstance.SLOT_NUM;
        DataManager.GetInstance.SET_PLAYER_LEVEL(slotnum, Level);
        DataManager.GetInstance.SET_PALYER_MAXHP(slotnum, MaxHp);
        DataManager.GetInstance.SET_PALYER_MAXMP(slotnum, MaxMp);
        DataManager.GetInstance.SET_PALYER_DAMAGE(slotnum, Damage);
        DataManager.GetInstance.SET_PALYER_SPEED(slotnum, Speed);
        DataManager.GetInstance.SET_PALYER_DEFENCE(slotnum, Defence);
        DataManager.GetInstance.SET_PALYER_AVOIDANCE(slotnum, Avoidance);
        DataManager.GetInstance.SET_PALYER_CRITICALCHANCE(slotnum, CriticalChance);
        DataManager.GetInstance.SET_PALYER_NOWHP(slotnum, NowHp);
        DataManager.GetInstance.SET_PALYER_NOWMP(slotnum, NowMp);
        DataManager.GetInstance.SET_PLAYER_EXP(slotnum, NowExp);

        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);
    }


    private void CheckHp()
    {
        if (NowHp <= 0)
        {
            NowHp = 0;
            Hpvalue = 0;
            if (playerController == null) playerController = GetComponent<PlayerController>();

            playerController.Dead();
        }
        else
        {
            Hpvalue = ((float)NowHp / (float)MaxHp);
        }
    }

    private void CheckMp()
    {
        if (NowMp <= 0 || MaxMp <= 0)
        {
            Mpvalue = 0;
        }
        else
        {
            Mpvalue = ((float)NowMp / (float)MaxMp);
        }
    }

    private void CheckExp()
    {
        if (NowExp <= 0 || MaxExp <= 0)
        {
            Expvalue = 0;
        }
        else
        {
            Expvalue = ((float)NowExp / (float)MaxExp);
        }
    }

    


    public void SetNowHP(float value)
    {
        _playerBarManager.SetHpBar(value, NowHp, MaxHp);
    }

    public void SetNowMP(float value)
    {
        _playerBarManager.SetMpBar(value, NowMp, MaxMp);
    }

    public void SetNowEXP(float value)
    {
        _playerBarManager.SetExpBar(value);
    }


    public void Recorvery()
    {
        NowHp = MaxHp;
        NowMp = MaxMp;
        DataManager.GetInstance.SET_PALYER_NOWHP(DataManager.GetInstance.SLOT_NUM, NowHp);
        DataManager.GetInstance.SET_PALYER_NOWMP(DataManager.GetInstance.SLOT_NUM, NowMp);
        CheckHp();
        SetNowHP(Hpvalue);

        CheckMp();
        SetNowMP(Mpvalue);

        SaveData();
    }

    public void GetDamage(int damage = 0)
    {
        bool isAvoidance = CheckAvoidance();

        damage = damage - (int)Defence - EquipmentDefence;
        if (damage <= 0) isAvoidance = true;
        else isAvoidance = false;


        if (isAvoidance)
        {
            NowHp = NowHp;
        }
        else NowHp = NowHp - damage;
        CheckHp();

        SetNowHP(Hpvalue);
        DamageNum.instance.Damage(damage, 0, this.transform, false, isAvoidance, true);
    }

    public bool UseMp(int num, int SkillNum)
    {
        if (NowMp - num < 0)
        {
            PopupManager.GetInstance.NoMpPopup();
            return false;
        }

        if (!UIManager.GetInstance.CheckCoolTime(SkillNum)) return false;

        
        else NowMp -= num;
        CheckMp();
        SetNowMP(Mpvalue);
        SaveData();

        return true;
    }

    public void GetExp(int num =0)
    {
        NowExp += num;
        if (NowExp >= MaxExp)
        {
            NowExp = NowExp - MaxExp;
            LevelUp();
        }
        CheckExp();
        SetNowEXP(Expvalue);
        SaveData();
    }

    public void GetHeel(int heel)
    {
        NowHp += heel;
        if (NowHp > MaxHp)
        {
            NowHp = MaxHp;
        }
        CheckHp();
        SetNowHP(Hpvalue);
        SaveData();
    }

    public void RecoveryMp(int mp)
    {
        NowMp += mp;
        if (NowMp > MaxMp)
        {
            NowMp = MaxMp;

        }
        CheckMp();
        SetNowMP(Mpvalue);
        SaveData();
    }

    #region 피격시 무시간 1.5초
    private bool isInvincible = false;
    public float invincibilityDuration = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (!isInvincible && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GetDamage(other.GetComponent<Enemy>().damage);
            StartCoroutine(InvincibilityCooldown());
        }

        if (!isInvincible && other.gameObject.layer == LayerMask.NameToLayer("EnemyAttack"))
        {
            GetDamage(other.GetComponent<EnemyAttack>().damage);
            StartCoroutine(InvincibilityCooldown());
        }

        if (!isInvincible && other.gameObject.layer == LayerMask.NameToLayer("Specter"))
        {
            GetDamage(other.GetComponent<SpecterAttack>().damage);
            StartCoroutine(InvincibilityCooldown());
        }

        if (!isInvincible && other.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            GetDamage(other.GetComponent<DemonBoss>().Damage);
            StartCoroutine(InvincibilityCooldown());
        }
    }

    private IEnumerator InvincibilityCooldown()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    #endregion

}
