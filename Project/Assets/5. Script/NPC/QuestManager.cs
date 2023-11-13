using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField]
    int questId;
    [SerializeField]
    int questActionIndex;
    [SerializeField]
    GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();


        questId = DataManager.GetInstance.GET_QUEST_ID(DataManager.GetInstance.SLOT_NUM);
        GenerateData();
    }

    
    void GenerateData()
    {
        questList.Add(10, new QuestData("?????? ???? ???????", new int[] {1000, 2000}));
        questList.Add(20, new QuestData("???? ??????", new int[] { 4000, 2000 }));
        questList.Add(30, new QuestData("???? ????", new int[] { 5000, 2000 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {

        if (id == questList[questId].npcId[questActionIndex])
        questActionIndex++;

        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        DataManager.GetInstance.SET_QUEST_ID(DataManager.GetInstance.SLOT_NUM, questId);
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
