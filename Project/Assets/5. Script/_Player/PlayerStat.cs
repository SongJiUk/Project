using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStat : Singleton<PlayerStat>
{
    public UnitCode UnitCodes { get; set; }
    public int SlotNum { get; set; }
    public int MaxHp { get; set; }
    public int MaxMp { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float ComboDelay { get; set; }


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
    }

    public void ChangeStat(EquipmentItemData _beforeItem, EquipmentItemData _afterItem)
    {

    }

    public void LevelUp()
    {
        MaxHp += 50;
        MaxMp += 50;
        Damage += 1f;

    }
}
