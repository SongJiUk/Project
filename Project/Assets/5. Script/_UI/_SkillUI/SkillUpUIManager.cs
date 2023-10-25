using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SkillUpSlotUI;

public class SkillUpUIManager : MonoBehaviour
{

    private SkillUpSlotUI _pickSkillUpSlotUI; //선택할 슬롯

    [SerializeField] private bool _showHighlight = true;

    private SkillUpSlotUI _pointerOverSlot;

    [SerializeField] List<SkillUpSlotUI> _skillUpSlotUIList = new List<SkillUpSlotUI>();
    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrrList;

    void Awake()
    {
        Init();
    }

    void Update()
    {
        _ped.position = Input.mousePosition;

        OnPointerEnterAndExit();

        OnPointerDown();

        OnPointerUp();
    }

    private void Init()
    {
        TryGetComponent(out _gr);
        if (_gr == null)
            _gr = gameObject.AddComponent<GraphicRaycaster>();

        // Graphic Raycaster
        _ped = new PointerEventData(EventSystem.current);
        _rrrList = new List<RaycastResult>(10);
    }

    public T RaycastAndGetFirstComponent<T>() where T : Component
    {
        _rrrList.Clear();

        _gr.Raycast(_ped, _rrrList);

        if (_rrrList.Count == 0)
            return null;

        return _rrrList[0].gameObject.GetComponent<T>();
    }

    /// <summary> 슬롯에 포인터가 올라가는 경우, 슬롯에서 포인터가 빠져나가는 경우 </summary>
    private void OnPointerEnterAndExit()
    {
        // 이전 프레임의 슬롯
        var prevSlot = _pointerOverSlot;

        // 현재 프레임의 슬롯
        var curSlot = _pointerOverSlot = RaycastAndGetFirstComponent<SkillUpSlotUI>();
        Debug.Log(curSlot);
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

    private void OnPointerDown()
    {
        // Left Click : Begin Drag

        if (Input.GetMouseButtonDown(0))
        {
            _pickSkillUpSlotUI = RaycastAndGetFirstComponent<SkillUpSlotUI>();

            // 아이템을 갖고 있는 슬롯만 해당
            if (_pickSkillUpSlotUI != null)
            {
                _pickSkillUpSlotUI.Highlight(true);
            }
            else
            {
                _pickSkillUpSlotUI = null;
            }
        }

        // Right Click : Use Item
        else if (Input.GetMouseButtonDown(1))
        {
            ItemSlotUI slot = RaycastAndGetFirstComponent<ItemSlotUI>();

            if (slot != null && slot.HasItem && slot.IsAccessible)
            {
               // TryUseItem(slot.Index);
            }
        }
    }


    private void OnPointerUp()
    {

    }

}
