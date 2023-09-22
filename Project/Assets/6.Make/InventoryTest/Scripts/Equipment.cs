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

    [SerializeField]
    private EquipmentUI _EquipmentUI; // 연결된 장비창

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

    private void UpdateSlot(int index)
    {
        //if (!IsValidIndex(index)) return;
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
        
        // 1. 아이템이 슬롯에 존재하는 경우
        if (item != null)
        {
            // 아이콘 등록
            _EquipmentUI.SetItemIcon(index, item.Data.IconSprite);
            // 슬롯 필터 상태 업데이트
            _EquipmentUI.UpdateSlotFilterState(index, item.Data);
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
        _EquipmentUI.RemoveItem(index);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            UpdateSlot(0);
        }
    }
}
