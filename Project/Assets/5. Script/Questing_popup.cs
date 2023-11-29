using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questing_popup : Singleton<Questing_popup>
{

    [SerializeField] Image QuestType_Img;
    [SerializeField] Sprite[] imgs;

    [SerializeField] Text QuestName;
    [SerializeField] Text QuestCount;

    [SerializeField] GameObject Clear;

    public void AcceptQuest(EQuestGoal _quest, string _questName, int KillCount = 0)
    {
        if(_quest == EQuestGoal.Talk)
        {
            UpdateTalkType(_questName);
            QuestCount.text = "언덕으로 가자";
        }
        else
        {
            UpdateKillType(_questName, KillCount);
        }

        NextQuest();
    }



    void UpdateTalkType(string _questName)
    {
        QuestType_Img.sprite = imgs[0];
        QuestName.text = $"{_questName}";
    }

    void UpdateKillType(string _questName, int KillCount)
    {
        QuestType_Img.sprite = imgs[1];
        QuestName.text = $"{_questName}";
        UpdateKillCount(0, KillCount);
    }

    public void UpdateKillCount(int NowCount, int GoalCount)
    {
        QuestCount.text = $"{NowCount} / {GoalCount}";
    }

    public void ClearQuest()
    {
        Clear.SetActive(true);
    }

    public void NextQuest()
    {
        Clear.SetActive(false);
    }
}
