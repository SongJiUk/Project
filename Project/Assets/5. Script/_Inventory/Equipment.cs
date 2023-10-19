using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.Experimental.GraphView.Port;
using static UnityEditor.Progress;

public class Equipment : MonoBehaviour
{
    /***********************************************************************
        *                               Public Properties
        ***********************************************************************/
    #region .
    /// <summary> ������ ���� �ѵ� </summary>
    public int Capacity { get; private set; }

    #endregion
    /***********************************************************************
       *                               Private Fields
       ***********************************************************************/

    [SerializeField]
    private EquipmentUI _equipmentUI; // ����� ���â
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


        
        if (A.EquipmentData.Type == Types.Top)
        {
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
        }
        else if (A.EquipmentData.Type == Types.Pants)
        {
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
            UpdateSlot(2);
        }
        else if (A.EquipmentData.Type == Types.Head)
        {
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
            UpdateSlot(3);
        }
        else if (A.EquipmentData.Type == Types.Hand)
        {
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
            UpdateSlot(4);
        }
        else if (A.EquipmentData.Type == Types.Shoes)
        {
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
            UpdateSlot(5);
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

        // 1. �������� ���Կ� �����ϴ� ���
        if (item != null)
        {
            // ������ ���
            _equipmentUI.SetItemIcon(index, item.Data.IconSprite);
            // ���� ���� ���� ������Ʈ
            _equipmentUI.UpdateSlotFilterState(index, item.Data);
        }
        // 2. �� ������ ��� : ������ ����
        else
        {
            RemoveIcon(index);
        }

    }
    // ���� : ������ �����ϱ�
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
    /// �ش� ������ ���� ������ ���� ����
    /// <para/> - �߸��� �ε��� : -1 ����
    /// <para/> - �� ���� : 0 ����
    /// <para/> - �� �� ���� ������ : 1 ����
    /// </summary>



    /// <summary> �ش� ������ ������ ���� ���� </summary>
    public ItemData GetItemData(int index)
    {
        if (slot(index) == null) return null;

        return slot(index).Data;
    }

    /// <summary> �ش� ������ ������ �̸� ���� </summary>
    public string GetItemName(int index)
    {
        if (slot(index) == null) return "";

        return slot(index).Data.Name;
    }
    #endregion
    /***********************************************************************
       *                               Public Methods
       ***********************************************************************/

    /// <summary> �κ��丮 UI ���� </summary>
    public void ConnectUI(EquipmentUI equipmentUI)
    {
        _equipmentUI = equipmentUI;
        _equipmentUI.SetEquipmentReference(this);
    }

    /// <summary> �κ��丮�� ������ �߰�
    /// <para/> �ִ� �� ������ �׿� ������ ���� ����
    /// <para/> ������ 0�̸� �ִµ� ��� �����ߴٴ� �ǹ�
    /// </summary>

    /// <summary> �ش� ������ ������ ���� </summary>
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

    /// <summary> �� �ε����� ������ ��ġ�� ���� ��ü </summary>
    public void Swap(int indexA, int indexB)
    {
        _inventory.SwapE(indexA, indexB);
        UpdateSlotEquipment(indexA);
        UpdateSlotEquipment(indexA);
    }

    /// <summary> �ش� ������ ������ ��� </summary>
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
            _customizingEquipment.Helmate(GetItemData(index));
        }
        else
        {
            if(true)
            {
                
            }
        }
    }
}
