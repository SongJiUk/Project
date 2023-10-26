using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.Experimental.GraphView.Port;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.VolumeComponent;

public class Equipment : MonoBehaviour
{
    /***********************************************************************
        *                               Public Properties
        ***********************************************************************/
    #region .
    /// <summary> ?????? ???? ???? </summary>
    public int Capacity { get; private set; }

    #endregion
    /***********************************************************************
       *                               Private Fields
       ***********************************************************************/

    [SerializeField]
    private EquipmentUI _equipmentUI; // ?????? ??????
    [SerializeField]
    private InventoryUI _inventoryUI;
    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private Customizing _customizingEquipment;

    private Item WeaponL;
    private Item Head;
    private Item Top;
    private Item Pants;
    private Item Shoes;
    private Item Hand;
    private Item WeaponR;

    public Item EquipmentItem(EquipmentItem A)
    {
       
        Item returnItem = null;
       // 1 - 레벨부족
       // 2 - 성별 안맞음
       // 3 - 직업 안맞음
        
        if (A.EquipmentData.Type == Types.Top)
        {
            int num = UIManager.GetInstance.customizing.ChangeEquipmentItem(A.EquipmentData as ArmorItemData);

            switch(num)
            {
                case 0:
                    if (Top != null)
                    {
                        returnItem = Top;
                        Top = A;
                    }
                    else
                    {
                        returnItem = null;
                        Top = A;
                    }
                    UpdateSlot(1);
                    DataManager.GetInstance.TOPCODE(DataManager.GetInstance.SLOT_NUM, A.EquipmentData.ItemCode);
                    break;

                case 1:
                    //레벨 부족
                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 2:
                    //성별 x
                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 3:
                    // 직업 안맞음
                    UIManager.GetInstance.isNoEquip = true;
                    break;
            }
            
            

        }
        else if (A.EquipmentData.Type == Types.Pants)
        {

            int num = UIManager.GetInstance.customizing.ChangeEquipmentItem(A.EquipmentData as ArmorItemData);

            switch (num)
            {
                case 0:
                    if (Pants != null)
                    {
                        returnItem = Pants;
                        Pants = A;
                    }
                    else
                    {
                        returnItem = null;
                        Pants = A;
                    }
                    UpdateSlot(1);
                    DataManager.GetInstance.PANTSCODE(DataManager.GetInstance.SLOT_NUM, A.EquipmentData.ItemCode);
                    break;

                case 1:
                    //레벨 부족
                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 2:
                    //성별 x
                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 3:
                    // 직업 안맞음
                    UIManager.GetInstance.isNoEquip = true;
                    break;
            }
        }
        else if (A.EquipmentData.Type == Types.Head)
        {

            int num = UIManager.GetInstance.customizing.ChangeEquipmentItem(A.EquipmentData as ArmorItemData);

            switch (num)
            {
                case 0:
                    if (Head != null)
                    {
                        returnItem = Head;
                        Head = A;
                    }
                    else
                    {
                        returnItem = null;
                        Head = A;
                    }
                    UpdateSlot(1);
                    DataManager.GetInstance.HELMATCODE(DataManager.GetInstance.SLOT_NUM, A.EquipmentData.ItemCode);
                    break;

                case 1:
                    //레벨 부족
                    Debug.Log("레벨 부족");

                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 2:
                    //성별 x
                    Debug.Log("성별 다름");

                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 3:
                    // 직업 안맞음
                    Debug.Log("직업 안맞음");

                    UIManager.GetInstance.isNoEquip = true;
                    break;
            }
        }
        else if (A.EquipmentData.Type == Types.Hand)
        {

            int num = UIManager.GetInstance.customizing.ChangeEquipmentItem(A.EquipmentData as ArmorItemData);

            switch (num)
            {
                case 0:
                    if (Hand != null)
                    {
                        returnItem = Hand;
                        Hand = A;
                    }
                    else
                    {
                        returnItem = null;
                        Hand = A;
                    }
                    UpdateSlot(1);
                    DataManager.GetInstance.HANDCODE(DataManager.GetInstance.SLOT_NUM, A.EquipmentData.ItemCode);
                    break;

                case 1:
                    //레벨 부족
                    Debug.Log("레벨 부족");
                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 2:
                    //성별 x
                    Debug.Log("성별 다름");
                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 3:
                    // 직업 안맞음
                    Debug.Log("직업 안맞음");
                    UIManager.GetInstance.isNoEquip = true;
                    break;
            }
        }
        else if (A.EquipmentData.Type == Types.Shoes)
        {
            int num = UIManager.GetInstance.customizing.ChangeEquipmentItem(A.EquipmentData as ArmorItemData);

            switch (num)
            {
                case 0:
                    if (Shoes != null)
                    {
                        returnItem = Shoes;
                        Shoes = A;
                    }
                    else
                    {
                        returnItem = null;
                        Shoes = A;
                    }
                    UpdateSlot(1);
                    DataManager.GetInstance.SHOESCODE(DataManager.GetInstance.SLOT_NUM, A.EquipmentData.ItemCode);
                    break;

                case 1:
                    //레벨 부족
                    Debug.Log("레벨 부족");
                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 2:
                    //성별 x
                    Debug.Log("성별 다름");
                    UIManager.GetInstance.isNoEquip = true;
                    break;

                case 3:
                    // 직업 안맞음
                    Debug.Log("직업 안맞음");
                    UIManager.GetInstance.isNoEquip = true;
                    break;
            }
        }
        else
        {
            if (WeaponL != null)
            {
                returnItem = WeaponL;
                WeaponL = A;
            }
            else
            {
                returnItem = null;
                WeaponL = A;
            }
            UpdateSlot(0);
            DataManager.GetInstance.WEAPONCODE(DataManager.GetInstance.SLOT_NUM, A.EquipmentData.ItemCode);
            //WeaponManager.GetInstance.ISEQUIP = true;
            if (A.EquipmentData.Type == Types.OneHandMace) UIManager.GetInstance.weaponManger.ChangeWeapon(A.EquipmentData as WeaponItemData, A.EquipmentData as WeaponItemData);
            else UIManager.GetInstance.weaponManger.ChangeWeapon(A.EquipmentData as WeaponItemData);

        }

        

        return returnItem;
    }

    public Item slot(int index)
    {
        Item item = null;
        if (index == 0)
        {
            item = WeaponL;
        }
        else if (index == 1)
        {
            item = Top;
        }
        else if (index == 2)
        {
            item = Pants;
        }
        else if (index == 3)
        {
            item = Head;
        }
        else if (index == 4)
        {
            item = Hand;
        }
        else if (index == 5)
        {
            item = Shoes;
        }
        else
        {
            item = null;
        }
        return item;
    }


    public void UpdateSlot(int index)
    {
        //if (!IsValidIndex(index)) return;
        Item item = slot(index);

        // 1. ???????? ?????? ???????? ????
        if (item != null)
        {
            // ?????? ????
            _equipmentUI.SetItemIcon(index, item.Data.IconSprite);
            // ???? ???? ???? ????????
            _equipmentUI.UpdateSlotFilterState(index, item.Data);
        }
        // 2. ?? ?????? ???? : ?????? ????
        else
        {
            RemoveIcon(index);
        }
        UpdateSlotEquipment(index);
    }
    // ???? : ?????? ????????
    void RemoveIcon(int index)
    {
        _equipmentUI.RemoveItem(index);
    }
    // Start is called before the first frame update
    void Awake()
    {
        _equipmentUI.SetEquipmentReference(this);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            UpdateSlot(0);
        }
    }

    /***********************************************************************
        *                               Check & Getter Methods
        ***********************************************************************/
    #region 

    /// <summary> 
    /// ???? ?????? ???? ?????? ???? ????
    /// <para/> - ?????? ?????? : -1 ????
    /// <para/> - ?? ???? : 0 ????
    /// <para/> - ?? ?? ???? ?????? : 1 ????
    /// </summary>



    /// <summary> ???? ?????? ?????? ???? ???? </summary>
    public ItemData GetItemData(int index)
    {
        if (slot(index) == null) return null;

        return slot(index).Data;
    }

    /// <summary> ???? ?????? ?????? ???? ???? </summary>
    public string GetItemName(int index)
    {
        if (slot(index) == null) return "";

        return slot(index).Data.Name;
    }
    #endregion
    /***********************************************************************
       *                               Public Methods
       ***********************************************************************/

    /// <summary> ???????? UI ???? </summary>
    public void ConnectUI(EquipmentUI equipmentUI)
    {
        _equipmentUI = equipmentUI;
        _equipmentUI.SetEquipmentReference(this);
    }

    /// <summary> ?????????? ?????? ????
    /// <para/> ???? ?? ?????? ???? ?????? ???? ????
    /// <para/> ?????? 0???? ?????? ???? ?????????? ????
    /// </summary>

    /// <summary> ???? ?????? ?????? ???? </summary>
    public void Remove(int index)
    {
        if (index == 0)
            WeaponL = null;
        else if (index == 1)
            Top = null;
        else if (index == 2)
            Pants = null;
        else if (index == 3)
            Head = null;
        else if (index == 4)
            Hand = null;
        else if (index == 5)
            Shoes = null;
        _equipmentUI.RemoveItem(index);
    }

    /// <summary> ?? ???????? ?????? ?????? ???? ???? </summary>
    public void Swap(int indexA, int indexB)
    {
        _inventory.SwapE(indexA, indexB);
        UpdateSlotEquipment(indexA);
    }

    /// <summary> ???? ?????? ?????? ???? </summary>
    public void Use(int index)
    {
        if (slot(index) is EquipmentItem uItem2)
        {
            _inventory.Add(slot(index).Data, 1);
            Remove(index);
            UpdateSlot(index);
            UpdateSlotEquipment(index);
        }
    }

    public void UpdateSlotEquipment(int index) 
    { 
        if(index==0)
        {

        }
        else if(index==3)
        {
            Debug.Log("sadgsag");
            //_customizingEquipment.Helmate(GetItemData(index));
            
        }
        else
        {
            if(true)
            {
                
            }
        }
    }
}
