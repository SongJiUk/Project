using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SkillUpSlotUI;

public class SkillUpUIManager : MonoBehaviour
{
    private SkillUpSlotUI _beforePickSkillUpSlotUI; //?????? ????
    private SkillUpSlotUI _pickSkillUpSlotUI; //?????? ????

    [SerializeField] private bool _showHighlight = true;

    private SkillUpSlotUI _pointerOverSlot;
    private GameObject _pointerOverObject;

    //LevelUpButtonUI
    [SerializeField] private GameObject _levelUpUI;
    [SerializeField] private Image _levelButtonImageUI;
    [SerializeField] private Text _skillPoint;
    [SerializeField] private Text _skillName;
    [SerializeField] private Text _skillImpormation;


    [SerializeField] List<SkillUpSlotUI> _skillUpSlotUIList = new List<SkillUpSlotUI>();
    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrrList;


    private GameObject _raycastGameObject;
    [SerializeField] private GameObject _button;
    [SerializeField] List<GameObject> _buttonArea = new List<GameObject>();

    [SerializeField] int PlayerLevel = 0;
    [SerializeField] int CanUseSkillPoint = 0;
    

    void Awake()
    {
        Init();
        SetInformationWindow(false);
        CheckSkillPoint();
        gameObject.SetActive(false);
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
        {
            _raycastGameObject = null;
            return null;
        }
        _raycastGameObject = _rrrList[0].gameObject;
        return _rrrList[0].gameObject.GetComponent<T>();
    }
    
    /// <summary> ?????? ???????? ???????? ????, ???????? ???????? ?????????? ???? </summary>
    private void OnPointerEnterAndExit()
    {
        // ???? ???????? ????
        var prevSlot = _pointerOverSlot;

        // ???? ???????? ????
        var curSlot = _pointerOverSlot = RaycastAndGetFirstComponent<SkillUpSlotUI>();


        //Debug.Log(curSlot);
        //Debug.Log(_raycastGameObject);
        //Debug.Log(_button);

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
            if (_pickSkillUpSlotUI != prevSlot)
            {
                prevSlot.Highlight(false);
            }
        }
    }   

    private void OnPointerDown()
    {
        // Left Click : Begin Drag

        if (Input.GetMouseButtonDown(0))
        {
            if (RaycastGameObject())
            {
                _beforePickSkillUpSlotUI = _pickSkillUpSlotUI;
                _pickSkillUpSlotUI = RaycastAndGetFirstComponent<SkillUpSlotUI>();

                if (_beforePickSkillUpSlotUI != null)
                {
                    _beforePickSkillUpSlotUI.Highlight(false);
                }
                // ???????? ???? ???? ?????? ????
                if (_pickSkillUpSlotUI != null)
                {
                    _pickSkillUpSlotUI.Highlight(true);
                    SetInformationWindow(true);
                    UpdateText();
                }
                else
                {
                    _pickSkillUpSlotUI = null;
                    SetInformationWindow(false);
                    if (_pickSkillUpSlotUI != null)
                    {
                        _pickSkillUpSlotUI.Highlight(false);
                    }
                }
            }
            else
            {
                if (_raycastGameObject == _button && CanUseSkillPoint > 0)
                {
                    SkillUp(_pickSkillUpSlotUI);
                    UpdateText();
                }
            }
        }

        // Right Click : Use Item
        else if (Input.GetMouseButtonDown(1))
        {
            SkillUpSlotUI slot = RaycastAndGetFirstComponent<SkillUpSlotUI>();

            if (slot != null)
            {
               // TryUseItem(slot.Index);
            }
        }
    }

    private void SetInformationWindow(bool ButtonOnOff)
    {
        if(ButtonOnOff)
        {
            _levelButtonImageUI.sprite = _pickSkillUpSlotUI.ReturnImage();
            _levelUpUI.SetActive(true);
        }
        else
        {
            _levelButtonImageUI.sprite = null;
            _levelUpUI.SetActive(false);
        }
    }

    private bool RaycastGameObject()
    {
        for (int i = 0; i < _buttonArea.Count; i++)
        {
            if (_buttonArea[i] == _raycastGameObject)
                return false;
        }
        return true;
    }
    private void SkillUp(SkillUpSlotUI SlotUI)
    {
        SlotUI.SetLevelUp();
    }

    private void UpdateText()
    {
        CheckSkillPoint();
        _skillName.text = $"{_pickSkillUpSlotUI.ReturnName()}";
        if (_pickSkillUpSlotUI.ReturnSkillLevel() != 5)
            _skillImpormation.text = $"Level : {_pickSkillUpSlotUI.ReturnSkillLevel()}" + System.Environment.NewLine + $"{_pickSkillUpSlotUI.ReturnText1()}" + System.Environment.NewLine + $"{_pickSkillUpSlotUI.ReturnText2()}"+ System.Environment.NewLine + $"Next Level" + System.Environment.NewLine + $"{_pickSkillUpSlotUI.ReturnText3()}";
        else
            _skillImpormation.text = $"Level : {_pickSkillUpSlotUI.ReturnSkillLevel()}" + System.Environment.NewLine + $"{_pickSkillUpSlotUI.ReturnText1()}" + System.Environment.NewLine + $"{_pickSkillUpSlotUI.ReturnText2()}";
    }

    private void CheckSkillPoint()
    {
        int UsedPoint = 0;
        for (int i = 0; i < _skillUpSlotUIList.Count; i++)
        {
            UsedPoint += _skillUpSlotUIList[i].ReturnSkillLevel();
        }
        CanUseSkillPoint = PlayerLevel - UsedPoint;

        _skillPoint.text = $"SkillPoint : {CanUseSkillPoint}";
    }






    private void ResetSkillPoint ()
    {
        for(int i=0;i< _skillUpSlotUIList.Count;i++)
        {
            _skillUpSlotUIList[i].SetLevel(0);
        }
    }

    public void SetSkillPoint(int playerLevel)
    {
        
    }

    private void OnPointerUp()
    {

    }

}
