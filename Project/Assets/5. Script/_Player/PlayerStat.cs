using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStat : Singleton<PlayerStat>
{
    public UnitCode unitCode { get; set; }
    public int SlotNum { get; set; }
    public int MaxHp { get; set; }
    public int MaxMp { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float ComboDelay { get; set; }


    public void InitStat(UnitCode _unitCode)
    {
        unitCode = _unitCode;
        switch (_unitCode)
        {
            case UnitCode.WARRIOR:
                ComboDelay = 1.5f;
                break;

            case UnitCode.MAGE:
                ComboDelay = 2f;
                break;
        }
    }
}
