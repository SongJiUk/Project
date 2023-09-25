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
    /// <summary> 아이템 수용 한도 </summary>
    public int Capacity { get; private set; }

    #endregion
    /***********************************************************************
       *                               Private Fields
       ***********************************************************************/

    [SerializeField]
    private EquipmentUI _equipmentUI; // 연결된 장비창
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

        // 1. 아이템이 슬롯에 존재하는 경우
        if (item != null)
        {
            // 아이콘 등록
            _equipmentUI.SetItemIcon(index, item.Data.IconSprite);
            // 슬롯 필터 상태 업데이트
            _equipmentUI.UpdateSlotFilterState(index, item.Data);
        }
        // 2. 빈 슬롯인 경우 : 아이콘 제거
        else
        {
            RemoveIcon(index);
        }

    }
    // 로컬 : 아이콘 제거하기
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
    /// 해당 슬롯의 현재 아이템 개수 리턴
    /// <para/> - 잘못된 인덱스 : -1 리턴
    /// <para/> - 빈 슬롯 : 0 리턴
    /// <para/> - 셀 수 없는 아이템 : 1 리턴
    /// </summary>



    /// <summary> 해당 슬롯의 아이템 정보 리턴 </summary>
    public ItemData GetItemData(int index)
    {
        if (slot(index) == null) return null;

        return slot(index).Data;
    }

    /// <summary> 해당 슬롯의 아이템 이름 리턴 </summary>
    public string GetItemName(int index)
    {
        if (slot(index) == null) return "";

        return slot(index).Data.Name;
    }
    #endregion
    /***********************************************************************
       *                               Public Methods
       ***********************************************************************/

    /// <summary> 인벤토리 UI 연결 </summary>
    public void ConnectUI(EquipmentUI equipmentUI)
    {
        _equipmentUI = equipmentUI;
        _equipmentUI.SetEquipmentReference(this);
    }

    /// <summary> 인벤토리에 아이템 추가
    /// <para/> 넣는 데 실패한 잉여 아이템 개수 리턴
    /// <para/> 리턴이 0이면 넣는데 모두 성공했다는 의미
    /// </summary>
   
    /// <summary> 해당 슬롯의 아이템 제거 </summary>
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

    /// <summary> 두 인덱스의 아이템 위치를 서로 교체 </summary>
    public void Swap(int indexA, int indexB)
    {
        _inventory.SwapE(indexA, indexB);
    }

    /// <summary> 해당 슬롯의 아이템 사용 </summary>
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
