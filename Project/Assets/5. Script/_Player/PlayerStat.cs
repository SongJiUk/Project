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

    public EGender gender { get; set; }

    PlayerBarManager _playerBarManager;


    PlayerController playerController;

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
                if(Level == 1)
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
                }
                break;

            case UnitCode.MAGE:
                ComboDelay = 2f;
                if(Level == 1)
                {
                    MaxHp = M_DefaultHP;
                    MaxMp = M_DefaultMP;
                    Damage = M_DefaultDamage;
                    Speed = M_DefaultSpeed;
                    Defence = M_DefaultDefence;
                    Avoidance = M_DefaultAvoidance;
                    CriticalChance = M_DefaultCriticalChance;
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
                }
                break;

            case UnitCode.ARCHER:
                ComboDelay = 1f;
                if(Level == 1)
                {
                    MaxHp = A_DefaultHP;
                    MaxMp = A_DefaultMP;
                    Damage = A_DefaultDamage;
                    Speed = A_DefaultSpeed;
                    Defence = A_DefaultDefence;
                    Avoidance = A_DefaultAvoidance;
                    CriticalChance = A_DefaultCriticalChance;
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
                }
                break;
        }
        ChangeEnum(DataManager.GetInstance.GET_GENDERNUM(DataManager.GetInstance.SLOT_NUM));
        
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
        Defence -= _beforeItem.Defence;
        Defence += _afterItem.Defence;
    }

    public void ChangeStat(ArmorItemData _item)
    {
        Defence += _item.Defence;
    }

    public void LevelUp()
    {
        Level++;
        MaxExp = DataManager.LevelUpEXP * Level;

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

                NowExp = 0;

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

                NowExp = 0;
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

                NowExp = 0;
                break;

        }


        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);
    }








    private void CheckHp()
    {
        if (NowHp <= 0)
        {
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



    public void GetDamage(int damage)
    {
        NowHp -= damage;
        CheckHp();

        SetNowHP(Hpvalue);
        DamageNum.instance.Damage(damage, 1, this.transform);
    }

    public void UseMp(int num)
    {
        NowMp -= num;
        if (NowMp < 0)
        {
            NowMp = 0;
        }
        CheckMp();
        SetNowMP(Mpvalue);
    }

    public void GetExp(int num)
    {
        NowExp += num;
        if (NowExp >= MaxExp)
        {
            LevelUp();
        }
        CheckExp();
        SetNowEXP(Expvalue);
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
    }

    public void RecoveryMp(int mp)
    {
        NowMp += mp;
        if (NowMp > MaxMp)
        {
            NowMp = MaxMp;
        }
        CheckMp();
        SetNowMP(Hpvalue);
    }




}
