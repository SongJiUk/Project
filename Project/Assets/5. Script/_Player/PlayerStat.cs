using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public EGender gender { get; set; }
   
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
    }
}
