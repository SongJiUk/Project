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

    /// <summary> ���Կ� ������ ������ ��� </summary>
    public void SetItemIcon(int index, Sprite icon)
    {
        EditorLog($"Set Item Icon : Slot [{index}]");

        _slotUIList[index].SetItem(icon);
    }

    /// <summary> ���Կ��� ������ ������ ����, ���� �ؽ�Ʈ ����� </summary>
    public void RemoveItem(int index)
    {
        EditorLog($"Remove Item : Slot [{index}]");

        _slotUIList[index].RemoveItem();
    }

    /// <summary> Ư�� ������ ���� ���� ������Ʈ </summary>
    public void UpdateSlotFilterState(int index, ItemData itemData)
    {
        bool isFiltered = true;

        // null�� ������ Ÿ�� �˻� ���� ���� Ȱ��ȭ
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