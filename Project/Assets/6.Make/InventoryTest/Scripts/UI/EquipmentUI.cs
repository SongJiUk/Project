using Rito.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    /***********************************************************************
        *                               Option Fields
        ***********************************************************************/

    [SerializeField]
     List<ItemSlotUI> _slotUIList = new List<ItemSlotUI>();

    /***********************************************************************
        *                               Private Fields
        ***********************************************************************/

    private enum FilterOption
    {
        All, Equipment, Portion
    }
    private FilterOption _currentFilterOption = FilterOption.All;


    /***********************************************************************
        *                               Public Methods
        ***********************************************************************/

    /// <summary> 슬롯에 아이템 아이콘 등록 </summary>
    public void SetItemIcon(int index, Sprite icon)
    {
        EditorLog($"Set Item Icon : Slot [{index}]");

        _slotUIList[index].SetItem(icon);
    }

    /// <summary> 슬롯에서 아이템 아이콘 제거, 개수 텍스트 숨기기 </summary>
    public void RemoveItem(int index)
    {
        EditorLog($"Remove Item : Slot [{index}]");

        _slotUIList[index].RemoveItem();
    }

    /// <summary> 특정 슬롯의 필터 상태 업데이트 </summary>
    public void UpdateSlotFilterState(int index, ItemData itemData)
    {
        bool isFiltered = true;

        // null인 슬롯은 타입 검사 없이 필터 활성화
        if (itemData != null)
            switch (_currentFilterOption)
            {
                case FilterOption.Equipment:
                    isFiltered = (itemData is EquipmentItemData);
                    break;

                case FilterOption.Portion:
                    isFiltered = (itemData is PortionItemData);
                    break;
            }

        _slotUIList[index].SetItemAccessibleState(isFiltered);
    }

    /***********************************************************************
       *                               Editor Only Debug
       ***********************************************************************/
#if UNITY_EDITOR
    [Header("Editor Options")]
    [SerializeField] private bool _showDebug = true;
#endif
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    private void EditorLog(object message)
    {
        if (!_showDebug) return;
        UnityEngine.Debug.Log($"[InventoryUI] {message}");
    }
}