using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : Singleton<PopupManager>
{

    public GameObject GameExit_Popup;
    public GameObject TownMap_MoveDungeon_Popup;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void TownMap_MoveToDungeonBtn(bool _isYes)
    {
        if (_isYes)
        {
            LoadManager.GetInstance.LoadSceneAsync("5_Dungeon");
            TownMap_MoveDungeon_Popup.SetActive(false);
        }
        else TownMap_MoveDungeon_Popup.SetActive(false);
    }

    public void Option()
    {

    }


    public void CharacterSelectScene()
    {
        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);
        GameExit_Popup.SetActive(false);
        LoadManager.GetInstance.LoadSceneAsync("1_PlayerSlotScene");
    }

    public void GameExit()
    {
        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);
        GameExit_Popup.SetActive(false);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void EscapeBtn()
    {
        GameExit_Popup.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameExit_Popup.SetActive(true);
        }
    }
}
