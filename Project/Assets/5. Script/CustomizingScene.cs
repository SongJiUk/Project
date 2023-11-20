using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomizingScene : MonoBehaviour
{
    static int IeastNum = 3;
    [SerializeField] InputField playerNameInput;
    [SerializeField] GameObject SelectName_Popup;
    [SerializeField] GameObject RealUseName_Popup;
    [SerializeField] GameObject Error_Popup;
    [SerializeField] Text Error_txt;
    [SerializeField] Customizing customizing;
    string playerName;
    string unavailablename_reason;

    private void Start()
    {
        //playerNameInput.onEndEdit.AddListener(EnterName);
    }
  
    public bool Check_availablename(string name)
    {
        if(name.Length == 0)
        {
            unavailablename_reason = "아무것도 입력하지 않았습니다.";
            return false;
        }

        if(name.Length < IeastNum)
        {
            unavailablename_reason = "이름이 너무 짧습니다."; 
            return false;
        }

        for(int i=0; i<DataManager.GetInstance.SLOT_NUM; i++)
        {
            if (name == DataManager.GetInstance.GET_PLAYER_ID(i))
            {
                unavailablename_reason = "사용중인 이름 입니다.";
                return false;
            }
        }

        return true;
    }

    public void CloseErrorPopup()
    {
        Error_Popup.SetActive(false);
    }

    public void CheckNamePopup(bool _isYes)
    {
        if(_isYes)
        {
            EnterName(playerNameInput.text);
        }
        else
        {
            SelectName_Popup.SetActive(false);
        }
    }
    public void EnterName(string name)
    {
        if (Check_availablename(name))
        {
            playerName = name;
            RealUseName_Popup.SetActive(true);

        }
        else
        {
            Error_Popup.SetActive(true);
            Error_txt.text = unavailablename_reason;
        }
    }
    public void UseNamePopup(bool _isYes)
    {
        if (_isYes)
        {
            DataManager.GetInstance.SET_PLAYER_ID(DataManager.GetInstance.SLOT_NUM, playerName);
            customizing.CreateCharacter();
            //var operation = SceneManager.LoadSceneAsync("4_TownMap");
            //operation.allowSceneActivation = true;
            DataManager.GetInstance.SET_ISCREATE(DataManager.GetInstance.SLOT_NUM, true);
            DataManager.GetInstance.SET_QUEST_ID(DataManager.GetInstance.SLOT_NUM, 10);
            DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);
            QuestManager.GetInstance.CheckQuestData();
            LoadManager.GetInstance.LoadSceneAsync("4_TownMap");
        }
        else RealUseName_Popup.SetActive(false);
    }

}
