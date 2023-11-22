using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSlotUI : MonoBehaviour
{

    public int SlotNum;
    [Tooltip("???? ?????? ??????")]
    [SerializeField] private Image _iconImage;
    [Tooltip("???? ?????? ??????")]
    [SerializeField] private Image _coolDown;

    [SerializeField] Text CoolTime_txt;

    float _starttime = 0;
    float _time = 0;
    float value = 0;
    bool isAvailableSkill;
    // Update is called once per frame

    private void Start()
    {
        int JobNum = DataManager.GetInstance.GET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM);
        isAvailableSkill = true;
        switch (SlotNum)
        {
            case 1:
                switch(JobNum)
                {
                    case 0:
                        _starttime = PlayerStat.W_Skill1_Cooltime;
                        break;

                    case 1:
                        _starttime = PlayerStat.M_Skill1_Cooltime;
                        break;

                    case 2:
                        _starttime = PlayerStat.A_Skill1_Cooltime;
                        break;

                }

                
                break;

            case 2:
                switch (JobNum)
                {
                    case 0:
                        _starttime = PlayerStat.W_Skill2_Cooltime;
                        break;

                    case 1:
                        _starttime = PlayerStat.M_Skill2_Cooltime;
                        break;

                    case 2:
                        _starttime = PlayerStat.A_Skill2_Cooltime;
                        break;

                }

                break;

            case 3:
                switch (JobNum)
                {
                    case 0:
                        _starttime = PlayerStat.W_Skill3_Cooltime;
                        break;

                    case 1:
                        _starttime = PlayerStat.M_Skill3_Cooltime;
                        break;

                    case 2:
                        _starttime = PlayerStat.A_Skill3_Cooltime;
                        break;
                }

                break;


        }
    }

    public bool CheckCoolTime()
    {

        if (isAvailableSkill)
        {
            StartCoroutine(UseSkill());
            return true;
        }
        else
        {
            PopupManager.GetInstance.CoolTimePopup();
            return false;
        }
    }

    IEnumerator UseSkill()
    {
        _time = _starttime;
        isAvailableSkill = false;
        while(true)
        {
            yield return null;

            if (_time > 0)
            {
                _time -= Time.deltaTime;

                value = _time / _starttime;
                CoolTime_txt.text = $"{(int)_time}";
                SetIconTime(value);
            }
            else
            {
                value = 0;
                SetIconTime(value);
                SetCoolDown();
                CoolTime_txt.text = "";
                break;
            }
        }
    }

    /// <summary> ?????? ?????? ???? </summary>
    public void SetIconImage(Sprite image)
    {
        _iconImage.sprite = image;
    }
    public void SetCoolTime()
    {
        _time = _starttime;
    }

    //public void SetCoolTime()
    //{
    //    _starttime = time;
    //    _time = _starttime;
    //}

    public void SetIconTime(float value)
    {
        _coolDown.fillAmount = value;
    }
    public void SetCoolDown()
    {
        _time = 0;
        isAvailableSkill = true;
    }
}
