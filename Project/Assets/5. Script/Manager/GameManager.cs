using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public UnityEngine.UI.Text talkText;
    public TalkManager talkManager;
    public GameObject TalkImage;
    public GameObject scanObject;
    public UnityEngine.UI.Image portraitImage;
    public UnityEngine.UI.Text questText;

    public bool isMove;
    public int talkIndex;

    QuestManager questManager;

    void Start()
    {
        questManager = QuestManager.QuestCurrent;
        questText.text = questManager.CheckQuest();
        Debug.Log(questManager.CheckQuest());
    }

    void OnTalk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            isMove = false;
            talkIndex = 0;
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData;
            portraitImage.sprite = talkManager.GetSprite(id);
            portraitImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImage.color = new Color(1, 1, 1, 0);
        }

        isMove = true;
        talkIndex++;
    }

    public void ShowText(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objectData = scanObject.GetComponent<ObjectData>();
        OnTalk(objectData.id, objectData.isNpc);

        TalkImage.SetActive(isMove);
    }
}
