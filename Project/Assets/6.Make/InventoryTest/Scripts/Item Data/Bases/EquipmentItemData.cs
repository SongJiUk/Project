using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Types
{
    Head = 0,    
    Top = 1,    
    Bottom = 2,
    Sword = 3,
    Bow = 4,
    Spear = 5,


}

namespace Rito.InventorySystem
{
    /// <summary> 장비 아이템 </summary>
    public abstract class EquipmentItemData : ItemData
    {
        /// <summary> 최대 내구도 </summary>
        public int MaxDurability => _maxDurability;

        public Types Type;

        [SerializeField] private int _maxDurability = 100;
    }
}