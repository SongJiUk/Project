using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemData : MonoBehaviour
{
    [SerializeField] ItemData itemdata;
    [SerializeField] Image Item_IMG;
    [SerializeField] Text ItemName_txt;
    [SerializeField] Text ItemPrice_txt;

    private void Start()
    {
        Item_IMG.sprite = itemdata.IconSprite;
        ItemName_txt.text = itemdata.Name;
        ItemPrice_txt.text = itemdata.ItemPrice.ToString();
    }

    public void BuyBtnClick()
    {
        EquipmentShop_Popup.GetInstance.Sell_itemdata = itemdata;
        EquipmentShop_Popup.GetInstance.BuyEquipmentItem();
    }
}
