using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Player))]
public class PlayerStat : Singleton<PlayerStat>
{
    public UnitCode UnitCodes { get; set; }
    public int Level { get; set; }
    public int SlotNum { get; set; }
    public int MaxHp { get; set; }
    public int MaxMp { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float ComboDelay { get; set; }
    public float Defence { get; set; }


    float NowHp = 0;
    float NowMp = 0;
    float MaxExp = 0;
    float NowExp = 0;
    float Hpvalue = 0;
    float Mpvalue = 0;
    float Expvalue = 0;

    public EGender gender { get; set; }

    PlayerBarManager _playerBarManager;

    public void InitStat(UnitCode _UnitCodes)
    {
        UnitCodes = _UnitCodes;
        switch (UnitCodes)
        {
            case UnitCode.WARRIOR:
                ComboDelay = 1.5f;

                break;

            case UnitCode.MAGE:
                ComboDelay = 2f;
                break;

            case UnitCode.ARCHER:
                ComboDelay = 1f;
                break;
        }
        ChangeEnum(DataManager.GetInstance.GENDERNUM(DataManager.GetInstance.SLOT_NUM));
        
    }

    private void Awake()
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
        MaxHp += 50;
        MaxMp += 50;
        Damage += 1f;

    }

    private void Update()
    {
        Debug.Log(Defence);

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetDamage(10);
        }
    }










    private void CheckHp()
    {
        if (NowHp <= 0 || MaxHp <= 0)
        {
            Hpvalue = 0;
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
        if (NowExp > MaxExp)
        {
            NowExp = MaxExp;
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
