using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField]
    int questId;

    public int QUESTID { get { return questId; } }

    public int NPCID;
    [SerializeField]
    int questActionIndex;
    [SerializeField]
    GameObject[] questObject;

    [SerializeField]
    List<QuestDatas> questDatas;

    public QuestDatas NowQuest;

    Dictionary<int, QuestData> questList;

    public bool isAllClear;
    public bool isQuesting;
    public bool isQuestClear;

    public int KillCount;
    private void Awake()
    {
       

    }

    private void Start()
    {
        questList = new Dictionary<int, QuestData>();

        //for(int i = 0; i<DataManager.SlotCount; i++)
        //{

        //}
        //questId = DataManager.GetInstance.GET_QUEST_ID(DataManager.GetInstance.SLOT_NUM);
        //GenerateData();
    }


    public void CheckQuestData()
    {
        questId = DataManager.GetInstance.GET_QUEST_ID(DataManager.GetInstance.SLOT_NUM);
        for(int i=0; i< questDatas.Count; i++)
        {
            if(questDatas[i].questId == questId)
            {
                NowQuest = questDatas[i];
                if(!isQuesting) NPCID = NowQuest.Before_NPCId;
                break;
            }
        }


    }

    public QuestDatas GetNowQuest()
    {
        return NowQuest;
    }

   

    public void QuestMidterminspection()
    {
        if(NowQuest.questtype == EQuestGoal.Talk) isQuestClear = true;
        else
        {
            if (KillCount == NowQuest.KillCount) isQuestClear = true;
        }
        
    }

    public void CheckKillCount()
    {
        KillCount++;
        if (KillCount >= NowQuest.KillCount)
        {
            KillCount = NowQuest.KillCount;
            QuestMidterminspection();
        }
       


    }

    public bool QuestCheck()
    {
        return isQuestClear;
    }

    public void ClearQuest()
    {
        isQuesting = false;
        isQuestClear = false;
        KillCount = 0;
        NextQuest();
    }


    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        if (questId > 30) isAllClear = true;
        DataManager.GetInstance.SET_QUEST_ID(DataManager.GetInstance.SLOT_NUM, questId);
        questActionIndex = 0;
        CheckQuestData();
        NPCID = NowQuest.Before_NPCId;
    }

   
}
