using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.InventorySystem
{
    /// <summary> 장비 - 무기 아이템 </summary>
    public class WeaponItem : EquipmentItem, EquipmentItemsSetting
    {
        public WeaponItem(WeaponItemData data) : base(data) { }

        public bool Use()
        {

            return true;
        }

        public int Type()
        {
            return 0;
        }
    }
}