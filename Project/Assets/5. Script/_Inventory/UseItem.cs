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
    /// <summary> 아이템 수용 한도 </summary>
    public int Capacity { get; private set; }

    #endregion
    /***********************************************************************
       *                               Private Fields
       ***********************************************************************/

    [SerializeField]
    private UseItemUI _useItemUI; // 연결된 장비창
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

        // 1. 아이템이 슬롯에 존재하는 경우
        if (item != null)
        {
            // 아이콘 등록
            _useItemUI.SetItemIcon(index, item.Data.IconSprite);
            // 슬롯 필터 상태 업데이트
            _useItemUI.UpdateSlotFilterState(index, item.Data);
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
    /*
    /// <summary> 
    /// 해당 슬롯의 현재 아이템 개수 리턴
    /// <para/> - 잘못된 인덱스 : -1 리턴
    /// <para/> - 빈 슬롯 : 0 리턴
    /// <para/> - 셀 수 없는 아이템 : 1 리턴
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

    /// <summary> 인벤토리 UI 연결 </summary>
    public void ConnectUI(UseItemUI useItemUI)
    {
        _useItemUI = useItemUI;
        _useItemUI.SetUseItemReference(this);
    }

    /// <summary> 인벤토리에 아이템 추가
    /// <para/> 넣는 데 실패한 잉여 아이템 개수 리턴
    /// <para/> 리턴이 0이면 넣는데 모두 성공했다는 의미
    /// </summary>
   
    /// <summary> 해당 슬롯의 아이템 제거 </summary>
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

    /// <summary> 해당 슬롯의 아이템 되돌리기 </summary>
    public void Back(int index)
    {
        if (slot(index) is EquipmentItem uItem2)
        {
            // true : 수량 나누기, false : 교환 또는 이동
            int currentAmount = 0;
            /*
            // 현재 개수 확인
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
