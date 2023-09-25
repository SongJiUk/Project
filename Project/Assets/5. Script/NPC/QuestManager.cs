using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager QuestCurrent = null;
    void Awake()
    {
        if (QuestCurrent == null)
        {
            QuestCurrent = this;
        }else
        {
            Debug.LogError("퀘스트 매니저가 이미 존재");
            Destroy(gameObject);
        }
    }

    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    void Start()
    {
        questList = new Dictionary<int, QuestData>();
        GenerataData();
    }

    void GenerataData()
    {
        questList.Add(10, new QuestData("박쥐 잡기", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("식인 식물", new int[] { 5000, 2000 }));
        questList.Add(30, new QuestData("퀘스트 올 클리어", new int[] { 0 }));
    }

    void NextQuest()
    {
        questId += 10;
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

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
            Debug.Log(questId);
        }

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }
}
