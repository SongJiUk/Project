using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Types
{
    Head = 0,    
    Top = 1,    
    Pants = 2,
    Shoes = 3,
    Hand = 4,
    HandAttack,
    Dagger,
    OneHandMace,
    TwoHandSword,
    Axe,
    Spear,
    Shield,
    Bow,
    CrossBow,
    Staff,
    Orb

}

public enum ClassPrivateItems
{
    WARRIOR = 0,
    MAGE,
    ARCHER
}


/// <summary> 장비 아이템 </summary>
public abstract class EquipmentItemData : ItemData
{
    virtual public void GetDatas()
    {

    }

    /// <summary> 최대 내구도 </summary>
    public int MaxDurability => _maxDurability;

    public Types Type;

    public ClassPrivateItems ClassPrivateItem;
        
    public EquipmmentGender Gender;

    [SerializeField] public int _EquipmentNum = 0;

    [SerializeField] public int _EquipmentLevel = 1;

    [SerializeField] private int _maxDurability = 100;


}
