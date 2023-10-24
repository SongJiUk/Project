using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary> 장비 - 방어구 아이템 </summary>
[CreateAssetMenu(fileName = "Item_Armor_", menuName = "Inventory System/Item Data/Armor", order = 2)]
public class ArmorItemData : EquipmentItemData
{
    /// <summary> 방어력 </summary>
    public int Defence => _defence;


    private void Start()
    {

    }
    public override void GetDatas()
    {
        
    }

    //여기다가 함수를 만드는게 낫다
    public ArmorItemData CallArmorItemData()
    {
        return this;
    }
     
    [SerializeField] private int _defence = 1;
    public override Item CreateItem()
    {
        return new ArmorItem(this);
    }
}
