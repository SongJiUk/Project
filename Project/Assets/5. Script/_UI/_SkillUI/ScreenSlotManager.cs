using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSlotManager : MonoBehaviour
{
    [SerializeField] List<ScreenSlotUI> _skillSlotUIList = new List<ScreenSlotUI>();
    [SerializeField] List<Sprite> _skill1 = new List<Sprite>();
    [SerializeField] List<Sprite> _skill2 = new List<Sprite>();
    [SerializeField] List<Sprite> _skill3 = new List<Sprite>();
    [SerializeField] List<ScreenSlotUI> _itemSlotUIList = new List<ScreenSlotUI>();
    [SerializeField] List<Sprite> _useItem = new List<Sprite>();

    int num = 0;

    // Start is called before the first frame update
    void Awake()
    {
        num = DataManager.GetInstance.PLAYER_JOB(DataManager.GetInstance.SLOT_NUM);
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
        _itemSlotUIList[0].SetIconImage(_useItem[0]);
        _itemSlotUIList[1].SetIconImage(_useItem[1]);
    }

    void SlotCoolDown(int numSlot, float time)
    {
        _skillSlotUIList[numSlot].SetIconTime(time);
    }
}
