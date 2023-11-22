using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static ItemSlotUI;

public class UseItemUI : MonoBehaviour
{
    
    /***********************************************************************
        *                               Option Fields
        ***********************************************************************/

    [SerializeField]
    List<ItemSlotUI> _slotUIList = new List<ItemSlotUI>();

    [Space]
    [SerializeField] private bool _showTooltip = true;
    [SerializeField] private bool _showHighlight = true;
    [SerializeField] private bool _showRemovingPopup = true;

    [Header("Connected Objects")]
    [SerializeField] private ItemTooltipUI _itemTooltip;   // ?????? ?????? ?????? ???? UI
    [SerializeField] private InventoryPopupUI _popup;      // ???? UI ???? ????

    [Space(16)]
    [SerializeField] private bool _mouseReversed = false; // ?????? ???? ???? ????

    /***********************************************************************
        *                               Private Fields
        ***********************************************************************/
    #region .
    /// <summary> ?????? ???????? </summary>
    [SerializeField]
    private UseItem _useItem;
    [SerializeField]
    private InventoryUI _inventoryUI;

    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrList;

    private ItemSlotUI _pointerOverSlot; // ???? ???????? ?????? ???? ????
    private ItemSlotUI _beginDragSlot; // ???? ???????? ?????? ????
    private Transform _beginDragIconTransform; // ???? ?????? ?????? ????????

    private int _leftClick = 0;
    private int _rightClick = 1;

    private Vector3 _beginDragIconPoint;   // ?????? ???? ?? ?????? ????
    private Vector3 _beginDragCursorPoint; // ?????? ???? ?? ?????? ????
    private int _beginDragSlotSiblingIndex;

    /// <summary> ???????? UI ?? ?????? ?????? ???? </summary>
    private enum FilterOption
    {
        All, Equipment, Portion
    }
    private FilterOption _currentFilterOption = FilterOption.All;
    #endregion 
    /***********************************************************************
       *                               Unity Events
       ***********************************************************************/
    #region .
    private void Awake()
    {
        Init();
        slotnum();
    }

    private void Update()
    {
        _ped.position = Input.mousePosition;

        OnPointerEnterAndExit();
        if (_showTooltip) ShowOrHideItemTooltip();
        OnPointerDown();
        OnPointerDrag();
        OnPointerUp();
    }

    #endregion

    /***********************************************************************
       *                               Init Methods
       ***********************************************************************/
    #region .
    private void Init()
    {
        TryGetComponent(out _gr);
        if (_gr == null)
            _gr = gameObject.AddComponent<GraphicRaycaster>();

        // Graphic Raycaster
        _ped = new PointerEventData(EventSystem.current);
        _rrList = new List<RaycastResult>(10);

        // Item Tooltip UI
        if (_itemTooltip == null)
        {
            _itemTooltip = GetComponentInChildren<ItemTooltipUI>();
            EditorLog("???????????? ?????? ???? UI?? ???? ???????? ???? ???????? ???????? ????????????????.");
        }
    }

    private void slotnum()
    {
        for (int i = 0; i < 4; i++)
        {
            _slotUIList[i].SetSlotIndex(i);
        }
    }

    #endregion
    /***********************************************************************
   *                               Mouse Event Methods
   ***********************************************************************/
    #region .
    private bool IsOverUI()
        => EventSystem.current.IsPointerOverGameObject();

    /// <summary> ?????????????? ???? ?? ???? UI???? ???????? ???? ???? </summary>
    public T RaycastAndGetFirstComponent<T>() where T : Component
    {
        _rrList.Clear();

        _gr.Raycast(_ped, _rrList);

        if (_rrList.Count == 0)
            return null;

        return _rrList[0].gameObject.GetComponent<T>();
    }
    /// <summary> ?????? ???????? ???????? ????, ???????? ???????? ?????????? ???? </summary>
    private void OnPointerEnterAndExit()
    {
        // ???? ???????? ????
        var prevSlot = _pointerOverSlot;

        // ???? ???????? ????
        var curSlot = _pointerOverSlot = RaycastAndGetFirstComponent<ItemSlotUI>();

        if (prevSlot == null)
        {
            // Enter
            if (curSlot != null)
            {
                OnCurrentEnter();
            }
        }
        else
        {
            // Exit
            if (curSlot == null)
            {
                OnPrevExit();
            }

            // Change
            else if (prevSlot != curSlot)
            {
                OnPrevExit();
                OnCurrentEnter();
            }
        }

        // ===================== Local Methods ===============================
        void OnCurrentEnter()
        {
            if (_showHighlight)
                curSlot.Highlight(true);
        }
        void OnPrevExit()
        {
            prevSlot.Highlight(false);
        }
    }
    /// <summary> ?????? ???? ???? ?????????? ?????? </summary>
    private void ShowOrHideItemTooltip()
    {
        // ???????? ?????? ?????? ?????? ???? ?????? ?????? ???? ????????
        bool isValid =
            _pointerOverSlot != null && _pointerOverSlot.HasItem && _pointerOverSlot.IsAccessible
            && (_pointerOverSlot != _beginDragSlot); // ?????? ?????? ???????? ???????? ????

        if (isValid)
        {
            UpdateTooltipUI(_pointerOverSlot);
            _itemTooltip.Show();
        }
        else
            _itemTooltip.Hide();
    }
    /// <summary> ?????? ???????? ???? </summary>
    private void OnPointerDown()
    {
        // Left Click : Begin Drag
        /*
        if (Input.GetMouseButtonDown(_leftClick))
        {
            _beginDragSlot = RaycastAndGetFirstComponent<ItemSlotUI>();

            // ???????? ???? ???? ?????? ????
            if (_beginDragSlot != null && _beginDragSlot.HasItem && _beginDragSlot.IsAccessible)
            {
                EditorLog($"Drag Begin : Slot [{_beginDragSlot.Index}]");

                // ???? ????, ???? ????
                _beginDragIconTransform = _beginDragSlot.IconRect.transform;
                _beginDragIconPoint = _beginDragIconTransform.position;
                _beginDragCursorPoint = Input.mousePosition;

                // ?? ???? ??????
                _beginDragSlotSiblingIndex = _beginDragSlot.transform.GetSiblingIndex();
                _beginDragSlot.transform.SetAsLastSibling();

                // ???? ?????? ?????????? ???????? ?????????? ???? ??????????
                _beginDragSlot.SetHighlightOnTop(false);
            }
            else
            {
                _beginDragSlot = null;
            }
        }
        */
        if (Input.GetMouseButtonDown(_leftClick))
        {
            ItemSlotUI slot = RaycastAndGetFirstComponent<ItemSlotUI>();

            if (slot != null && slot.HasItem && slot.IsAccessible)
            {
                TryBackItem(slot.Index);
            }
        }

        // Right Click : Use Item
        else if (Input.GetMouseButtonDown(_rightClick))
        {
            ItemSlotUI slot = RaycastAndGetFirstComponent<ItemSlotUI>();

            if (slot != null && slot.HasItem && slot.IsAccessible)
            {
                TryUseItem(slot.Index);
            }
        }
    }
    /// <summary> ?????????? ???? </summary>
    private void OnPointerDrag()
    {
        if (_beginDragSlot == null) return;

        if (Input.GetMouseButton(_leftClick))
        {
            // ???? ????
            _beginDragIconTransform.position =
                _beginDragIconPoint + (Input.mousePosition - _beginDragCursorPoint);
        }
    }
    /// <summary> ?????? ?? ???? </summary>
    private void OnPointerUp()
    {
        if (Input.GetMouseButtonUp(_leftClick))
        {
            // End Drag
            if (_beginDragSlot != null)
            {
                // ???? ????
                _beginDragIconTransform.position = _beginDragIconPoint;

                // UI ???? ????
                _beginDragSlot.transform.SetSiblingIndex(_beginDragSlotSiblingIndex);

                // ?????? ???? ????
                EndDrag();

                // ???? ?????? ?????????? ???????? ?????????? ???? ??????????
                _beginDragSlot.SetHighlightOnTop(true);

                // ???? ????
                _beginDragSlot = null;
                _beginDragIconTransform = null;
            }
        }

    }

    private void EndDrag()
    {
        ItemSlotUI endDragSlot = RaycastAndGetFirstComponent<ItemSlotUI>();

        if(endDragSlot==null)
        {
            endDragSlot = _inventoryUI.RaycastAndGetFirstComponent<ItemSlotUI>();
            return;
        }
        if (endDragSlot._currentSetSlotOption != IsWhereSlot.Inventory)
        {
            return;
        }
        // ?????? ???????? ?????? ???? ???? ????
        if (endDragSlot != null && endDragSlot.IsAccessible && endDragSlot._currentSetSlotOption == IsWhereSlot.Inventory)
        {
           
            


            TrySwapItems(_beginDragSlot, endDragSlot);

            // ???? ????
            UpdateTooltipUI(endDragSlot);
            return;
        }

        // ??????(?????? UI ?????????? ???? ???? ???? ???? ????)
        if (!IsOverUI())
        {
            // ???? ???? ?????? ???? ????
            int index = _beginDragSlot.Index;
            string itemName = _useItem.GetItemName(index);
            int amount = 1;

            // ?? ?? ???? ???????? ????, ???? ????
            if (amount > 1)
                itemName += $" x{amount}";

            if (_showRemovingPopup)
                _popup.OpenConfirmationPopup(() => TryRemoveItem(index), itemName);
            else
                TryRemoveItem(index);
        }
        // ?????? ???? ???? UI ???? ???? ????
        else
        {
            EditorLog($"Drag End(Do Nothing)");
        }
    }

    #endregion

    /***********************************************************************
        *                               Private Methods
        ***********************************************************************/
    #region .

    /// <summary> UI ?? ???????????? ?????? ???? </summary>
    private void TryRemoveItem(int index)
    {
        EditorLog($"UI - Try Remove Item : Slot [{index}]");

        _useItem.Remove(index);
    }

    /// <summary> ?????? ?????????? ???????? </summary>
    private void TryBackItem(int index)
    {
        EditorLog($"UI - Try Use Item : Slot [{index}]");

        _useItem.Back(index);
    }

    /// <summary> ?????? ???? </summary>
    private void TryUseItem(int index)
    {
        EditorLog($"UI - Try Use Item : Slot [{index}]");

        _useItem.Use(index);
    }

    /// <summary> ?? ?????? ?????? ???? </summary>(???? ???????? ??????, ???? ????????)
    private void TrySwapItems(ItemSlotUI from, ItemSlotUI to)
    {
        if (from == to)
        {
            EditorLog($"UI - Try Swap Items: Same Slot [{from.Index}]");
            return;
        }

        EditorLog($"UI - Try Swap Items: Slot [{from.Index} -> {to.Index}]");

        from.SwapOrMoveIcon(to);
        _useItem.Swap(from.Index, to.Index);
    }

    /// <summary> ???? UI?? ???? ?????? ???? </summary>
    private void UpdateTooltipUI(ItemSlotUI slot)
    {
        if (!slot.IsAccessible || !slot.HasItem)
            return;
        Debug.Log(slot.Index);
        // ???? ???? ????
        _itemTooltip.SetItemInfo(_useItem.GetItemData(slot.Index));

        // ???? ???? ????
        _itemTooltip.SetRectPosition(slot.SlotRect);
    }

    #endregion

    /***********************************************************************
        *                               Public Methods
        ***********************************************************************/

    /// <summary> ???????? ???? ???? (???????????? ???? ????) </summary>
    public void SetUseItemReference(UseItem useItem)
    {
        _useItem = useItem;
    }



    /// <summary> ?????? ?????? ?????? ???? </summary>
    public void SetItemIcon(int index, Sprite icon)
    {
        EditorLog($"Set Item Icon : Slot [{index}]");

        _slotUIList[index].SetItem(icon);
    }

    /// <summary> ???????? ?????? ?????? ????, ???? ?????? ?????? </summary>
    public void RemoveItem(int index)
    {
        EditorLog($"Remove Item : Slot [{index}]");

        _slotUIList[index].RemoveItem();
    }

    /// <summary> ???? ?????? ???? ???? ???????? </summary>
    public void UpdateSlotFilterState(int index, ItemData itemData)
    {
        bool isFiltered = true;

        // null?? ?????? ???? ???? ???? ???? ??????
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

    /// <summary> ???? ???? ???? ???? ???????? </summary>
    public void UpdateAllSlotFilters()
    {
        int capacity = _useItem.Capacity;

        for (int i = 0; i < capacity; i++)
        {
            ItemData data = _useItem.GetItemData(i);
            UpdateSlotFilterState(i, data);
        }
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
        //if (!_showDebug) return;
        UnityEngine.Debug.Log($"[InventoryUI] {message}");
    }
}