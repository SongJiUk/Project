using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            CameraManager.GetInstance.ISUIOFF = true;
            UIManager.GetInstance.isOnPopupCount = 0;
        }
        else
        {
            TownMap_MoveDungeon_Popup.SetActive(false);
            CameraManager.GetInstance.ISUIOFF = true;
            UIManager.GetInstance.isOnPopupCount--;
        }
    }

    public void Option()
    {

    }


    public void CharacterSelectScene()
    {
        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);
        GameExit_Popup.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = false;
        UIManager.GetInstance.isOnPopupCount = 0;
        LoadManager.GetInstance.LoadSceneAsync("1_PlayerSlotScene");
    }

    public void GameExit()
    {
        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);
        GameExit_Popup.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = true;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void EscapeBtn()
    {
        GameExit_Popup.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "1_PlayerSlotScene")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameExit_Popup.SetActive(!GameExit_Popup.activeSelf);

                if (GameExit_Popup.activeSelf)
                {
                    CameraManager.GetInstance.ISUIOFF = false;
                    UIManager.GetInstance.isOnPopupCount++;
                }
                else
                {
                    CameraManager.GetInstance.ISUIOFF = true;
                    UIManager.GetInstance.isOnPopupCount--;
                }

            }
        }
        
    }
}
