using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    TalkManager talkManager;
    QuestManager questManager;
    [SerializeField]
    GameObject talkPanel;
    [SerializeField]
    UnityEngine.UI.Text talkText;
    [SerializeField]
    GameObject scanObject;
    [SerializeField]
    bool isAction;
    [SerializeField]
    int talkIndex;





    private void Start()
    {
        //DontDestroyOnLoad(this);
        questManager = QuestManager.GetInstance;
        Debug.Log(questManager.CheckQuest());
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc, objData.isSellNPC);
        //talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc, bool isSellNPC)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        isAction = true;
        talkIndex++;
    }
}
