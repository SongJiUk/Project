using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortionShop_Popup : Singleton<PortionShop_Popup>
{
    public ItemData Sell_itemdata;

    [SerializeField] Inventory inventory;

    [SerializeField] GameObject RealBuy_Popup;
    [SerializeField] Text ItemName_txt;
    [SerializeField] Text ItemPrice;

    [SerializeField] GameObject No_Money_Popup;
    [SerializeField] GameObject Succes_Buy_Popup;

    private void OnEnable()
    {
     
        CameraManager.GetInstance.ISUIOFF = false;
        UIManager.GetInstance.isOnPopupCount++;
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;
    }

    public void BuyPortionItem()
    {

        if (Player.GetInstance.CheckGold(Sell_itemdata.ItemPrice))
        {
            //정말로 구매 하시겠습니까?
            RealBuy_Popup.SetActive(true);
            ItemName_txt.text = Sell_itemdata.Name;
            ItemPrice.text = Sell_itemdata.ItemPrice.ToString();
        }
        else
        {
            //골드가 부족합니다.
            No_Money_Popup.SetActive(true);
        }
    }

    public void BuyItem()
    {
        int gold = DataManager.GetInstance.GET_PLAYER_GOLD(DataManager.GetInstance.SLOT_NUM);

        gold -= Sell_itemdata.ItemPrice;

        DataManager.GetInstance.SET_PLAYER_GOLD(DataManager.GetInstance.SLOT_NUM, gold);

        inventory.Add(Sell_itemdata);
        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);

        RealBuy_Popup.SetActive(false);
        Succes_Buy_Popup.SetActive(true);
    }

    public void CloseNoticePopup()
    {
        RealBuy_Popup.SetActive(false);
        No_Money_Popup.SetActive(false);
        Succes_Buy_Popup.SetActive(false);
    }
}
    