using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentShop_Popup : Singleton<EquipmentShop_Popup>
{

    public ItemData Sell_itemdata;

    [SerializeField] Inventory inventory;

    [SerializeField] GameObject[] Jobs_Tap;
    [SerializeField] GameObject[] Gender_Tap;

    [SerializeField] GameObject[] Female_EquipMentTap;
    [SerializeField] GameObject[] male_EquipMentTap;

    [SerializeField] GameObject Select_Equipment_Btn;
    [SerializeField] GameObject Select_Weapon_Btn;


    [SerializeField] GameObject RealBuy_Popup;
    [SerializeField] Text ItemName_txt;
    [SerializeField] Text ItemPrice;

    [SerializeField] GameObject No_Money_Popup;
    [SerializeField] GameObject Succes_Buy_Popup;



    private void OnEnable()
    {
        WeaponScroll(true);
        Select_Weapon_Btn.SetActive(true);
        CameraManager.GetInstance.ISUIOFF = false;
        UIManager.GetInstance.isOnPopupCount++;
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
        WeaponScroll(false);
        EquipmentScroll(false);
        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;
    }


    public void ClickEquipMentType(bool _isWeapon)
    {
        if(_isWeapon)
        {
            Select_Weapon_Btn.SetActive(true);
            Select_Equipment_Btn.SetActive(false);
            WeaponScroll(true);
            EquipmentScroll(false);
        }
        else
        {
            Select_Equipment_Btn.SetActive(true);
            Select_Weapon_Btn.SetActive(false);
            EquipmentScroll(true);
            WeaponScroll(false);
        }
    }


    public void WeaponScroll(bool _isOnEnable)
    {
        switch (DataManager.GetInstance.GET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM))
        {
            case 0:
                if(_isOnEnable) Jobs_Tap[0].SetActive(true);
                else Jobs_Tap[0].SetActive(false);
                break;

            case 1:
                if (_isOnEnable) Jobs_Tap[1].SetActive(true);
                else Jobs_Tap[1].SetActive(false);
                break;

            case 2:
                if (_isOnEnable) Jobs_Tap[2].SetActive(true);
                else Jobs_Tap[2].SetActive(false);
                break;
        }
    }

    public void EquipmentScroll(bool _isOnEnable)
    {
        if(DataManager.GetInstance.GET_GENDERNUM(DataManager.GetInstance.SLOT_NUM) == 0)
        {
            if(_isOnEnable) Gender_Tap[0].SetActive(true);
            else Gender_Tap[0].SetActive(false);

            switch (DataManager.GetInstance.GET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM))
            {
                case 0:
                    if (_isOnEnable) Female_EquipMentTap[0].SetActive(true);
                    else Female_EquipMentTap[0].SetActive(false);
                    break;


                case 1:
                    if (_isOnEnable) Female_EquipMentTap[1].SetActive(true);
                    else Female_EquipMentTap[1].SetActive(false);
                    break;


                case 2:
                    if (_isOnEnable) Female_EquipMentTap[2].SetActive(true);
                    else Female_EquipMentTap[2].SetActive(false);
                    break;

            }
        }
        else
        {
            if (_isOnEnable) Gender_Tap[1].SetActive(true);
            else Gender_Tap[1].SetActive(false);

            switch (DataManager.GetInstance.GET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM))
            {
                case 0:
                    if(_isOnEnable) male_EquipMentTap[0].SetActive(true);
                    else male_EquipMentTap[0].SetActive(false);

                    break;


                case 1:
                    if (_isOnEnable) male_EquipMentTap[1].SetActive(true);
                    else male_EquipMentTap[1].SetActive(false);
                    break;


                case 2:
                    if (_isOnEnable) male_EquipMentTap[2].SetActive(true);
                    else male_EquipMentTap[2].SetActive(false);
                    break;

            }
        }
    }

    public void BuyEquipmentItem()
    {
        
        if(Player.GetInstance.CheckGold(Sell_itemdata.ItemCode))
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
