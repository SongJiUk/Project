using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.InventorySystem
{
    /// <summary> 장비 - 방어구 아이템 </summary>
    public class ArmorItem : EquipmentItem, EquipmentItemsSetting
    {
        public ArmorItem(ArmorItemData data) : base(data) { }

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