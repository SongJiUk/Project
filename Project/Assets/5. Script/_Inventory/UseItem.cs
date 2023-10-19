using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;
using static UnityEditor.Progress;

public class UseItem : MonoBehaviour
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
    private UseItemUI _useItemUI; // ����� ���â
    [SerializeField]
    private InventoryUI _inventoryUI;
    [SerializeField]
    private Inventory _inventory;

    private Item HpPotion;
    private Item MpPotion;
    private Item Skill1;
    private Item Skill2;

    public Item EquipmentItem(EquipmentItem A)
    {
        Item returnItem = null;


        if (A.EquipmentData.Type == Types.Head)
        {
            if(MpPotion !=null)
            {
                returnItem = MpPotion;
                MpPotion = A;
            }
            else
            {
                returnItem = null;
                MpPotion = A;
            }
            UpdateSlot(1);
        }
        else if (A.EquipmentData.Type == Types.Top)
        {
            if (Skill1 != null)
            {
                returnItem = Skill1;
                Skill1 = A;
            }
            else
            {
                returnItem = null;
                Skill1 = A;
            }
            UpdateSlot(2);
        }
        else if (A.EquipmentData.Type == Types.Pants)
        {
            if (Skill2 != null)
            {
                returnItem = Skill2;
                Skill2 = A;
            }
            else
            {
                returnItem = null;
                Skill2 = A;
            }
            UpdateSlot(3);
        }
        else
        {
            if (HpPotion != null)
            {
                returnItem = HpPotion;
                HpPotion = A;
            }
            else
            {
                returnItem = null;
                HpPotion = A;
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
            item = HpPotion;
        }
        else if (index == 1)
        {
            item = MpPotion;
        }
        else if (index == 2)
        {
            item = Skill1;
        }
        else if (index == 3)
        {
            item = Skill2;
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
            _useItemUI.SetItemIcon(index, item.Data.IconSprite);
            // ���� ���� ���� ������Ʈ
            _useItemUI.UpdateSlotFilterState(index, item.Data);
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
        _useItemUI.RemoveItem(index);
    }
    // Start is called before the first frame update
    void Awake()
    {
        _useItemUI.SetUseItemReference(this);
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
    /*
    /// <summary> 
    /// �ش� ������ ���� ������ ���� ����
    /// <para/> - �߸��� �ε��� : -1 ����
    /// <para/> - �� ���� : 0 ����
    /// <para/> - �� �� ���� ������ : 1 ����
    /// </summary>
    public int GetCurrentAmount(int index)
    {
        if (index == 0 || index == 1) return 0;

        CountableItem ci = _items[index] as CountableItem;
        if (ci == null)
            return 1;

        return ci.Amount;
    }
    */
    #endregion
    /***********************************************************************
       *                               Public Methods
       ***********************************************************************/

    /// <summary> �κ��丮 UI ���� </summary>
    public void ConnectUI(UseItemUI useItemUI)
    {
        _useItemUI = useItemUI;
        _useItemUI.SetUseItemReference(this);
    }

    /// <summary> �κ��丮�� ������ �߰�
    /// <para/> �ִ� �� ������ �׿� ������ ���� ����
    /// <para/> ������ 0�̸� �ִµ� ��� �����ߴٴ� �ǹ�
    /// </summary>
   
    /// <summary> �ش� ������ ������ ���� </summary>
    public void Remove(int index)
    {
        if (index == 0)
            HpPotion = null;
        else if (index == 1)
            MpPotion = null;
        else if (index == 2)
            Skill1 = null;
        else if (index == 3)
            Skill2 = null;

        _useItemUI.RemoveItem(index);
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

    /// <summary> �ش� ������ ������ �ǵ����� </summary>
    public void Back(int index)
    {
        if (slot(index) is EquipmentItem uItem2)
        {
            // true : ���� ������, false : ��ȯ �Ǵ� �̵�
            int currentAmount = 0;
            /*
            // ���� ���� Ȯ��
            if (isSeparatable)
            {
                currentAmount = _inventory.GetCurrentAmount(_beginDragSlot.Index);
                if (currentAmount > 1)
                {
                    isSeparation = true;
                }
            }
            */

            _inventory.Add(slot(index).Data, 1);
            Remove(index);
            UpdateSlot(index);


        }
    }
}
