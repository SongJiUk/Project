using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSlotManager : Singleton<ScreenSlotManager>
{
    [SerializeField] List<ScreenSlotUI> _skillSlotUIList = new List<ScreenSlotUI>();
    [SerializeField] List<Sprite> _skill1 = new List<Sprite>();
    [SerializeField] List<Sprite> _skill2 = new List<Sprite>();
    [SerializeField] List<Sprite> _skill3 = new List<Sprite>();
    [SerializeField] List<ScreenSlotUI> _itemSlotUIList = new List<ScreenSlotUI>();
    [SerializeField] List<Sprite> _useItem = new List<Sprite>();

    [SerializeField] List<Sprite> _DefulatUseItem = new List<Sprite>();

    [SerializeField] List<Text> _useItemTxt = new List<Text>();
    int num = 0;
    public bool isSlot1_Use;
    public bool isSlot2_Use;

    public int isSlot1_index;
    public int isSlot2_index;


    public int isSlot1_itemCode;
    public int isSlot2_itemCode;
    // Start is called before the first frame update
    void Awake()
    {
        num = DataManager.GetInstance.GET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM);
        SetIconImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetIconImage()
    {
        _skillSlotUIList[0].SetIconImage(_skill1[num]);
        _skillSlotUIList[1].SetIconImage(_skill2[num]);
        _skillSlotUIList[2].SetIconImage(_skill3[num]);
    }


    public int hp_amount;
    public int mp_amount;
    public void UsePortion(int _slot)
    {
        switch(_slot)
        {
            case 0:
                hp_amount--;
                _useItemTxt[0].text = hp_amount.ToString();
                break;

            case 1:
                mp_amount--;
                _useItemTxt[1].text = mp_amount.ToString();
                break;

        }
    }

    public void PortionSlotUpdate(int _slot, int _index, int _itemCode, int _amount, bool _isSlotOpen = false)
    {

        switch(_slot)
        {
            case 0:
                if(_isSlotOpen)
                {
                    _itemSlotUIList[0].SetIconImage(_useItem[0]);
                    isSlot1_Use = _isSlotOpen;
                    isSlot1_index = _index;
                    isSlot1_itemCode = _itemCode;
                    _useItemTxt[0].text = _amount.ToString();
                    hp_amount = _amount;
                    break;
                }
                else
                {
                    _itemSlotUIList[0].SetIconImage(_DefulatUseItem[0]);
                    isSlot1_Use = _isSlotOpen;
                    isSlot1_index = _index;
                    isSlot1_itemCode = _itemCode;
                    _useItemTxt[0].text = "";
                    hp_amount = 0;
                    break;
                }
                

            case 1:
                if(_isSlotOpen)
                {
                    _itemSlotUIList[1].SetIconImage(_useItem[1]);
                    isSlot2_Use = _isSlotOpen;
                    isSlot2_index = _index;
                    isSlot2_itemCode = _itemCode;
                    _useItemTxt[1].text = _amount.ToString();
                    mp_amount = _amount;
                    break;
                }
                else
                {
                    _itemSlotUIList[1].SetIconImage(_DefulatUseItem[1]);
                    isSlot1_Use = _isSlotOpen;
                    isSlot1_index = _index;
                    isSlot1_itemCode = _itemCode;
                    _useItemTxt[1].text = "";
                    mp_amount = 0;
                    break;

                }
                

        }
    }



    void SlotCoolDown(int numSlot, float time)
    {
        _skillSlotUIList[numSlot].SetIconTime(time);
    }
}
