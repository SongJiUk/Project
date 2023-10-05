using Rito.InventorySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;
using static UnityEditor.Progress;
using Item = Rito.InventorySystem.Item;

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

    private Item Weapon;
    private Item Head;
    private Item Top;
    private Item Bottom;

    public Item EquipmentItem(EquipmentItem A)
    {
        Item returnItem = null;


        if (A.EquipmentData.Type == Types.Head)
        {
            if(Head !=null)
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
        }
        else if (A.EquipmentData.Type == Types.Top)
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
            UpdateSlot(2);
        }
        else if (A.EquipmentData.Type == Types.Bottom)
        {
            if (Bottom != null)
            {
                returnItem = Bottom;
                Bottom = A;
            }
            else
            {
                returnItem = null;
                Bottom = A;
            }
            UpdateSlot(3);
        }
        else 
        {
            if (Weapon != null)
            {
                returnItem = Weapon;
                Weapon = A;
            }
            else
            {
                returnItem = null;
                Weapon = A;
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
            item = Weapon;
        }
        else if (index == 1)
        {
            item = Head;
        }
        else if (index == 2)
        {
            item = Top;
        }
        else if (index == 3)
        {
            item = Bottom;
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
            Weapon = null;
        else if (index == 1)
            Head = null;
        else if (index == 2)
            Top = null;
        else if (index == 3)
            Bottom = null;

        _equipmentUI.RemoveItem(index);
    }

    /// <summary> �� �ε����� ������ ��ġ�� ���� ��ü </summary>
    public void Swap(int indexA, int indexB)
    {
        _inventory.SwapE(indexA, indexB);
    }

    /// <summary> �ش� ������ ������ ��� </summary>
    public void Use(int index)
    {
        if (slot(index) is EquipmentItem uItem2)
        {
            _inventory.Add(slot(index).Data, 1);
            Remove(index);
            UpdateSlot(index);
        }
    }
}
