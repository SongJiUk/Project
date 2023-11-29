using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : Singleton<LoadManager>
{
    public static string LoadSceneName = "LoadScene";
    private float time;
    private Coroutine coroutine;
    AsyncOperation asyncOperation;
    public float LoadNum;
    public bool isSceneChange = false;
    int bgmNum;
    private void Awake()
    {
        DataManager.GetInstance.LoadData();
        //DontDestroyOnLoad(gameObject);
    }
    public void LoadSceneAsync(string _name)
    {
        if (_name == "4_TownMap") bgmNum = 1;
        else if (_name == "5_Dungeon") bgmNum = 2;
        else bgmNum = 0;


        isSceneChange = true;
        SceneManager.LoadScene(LoadSceneName);
        if (UIManager.GetInstance != null)
        {
            UIManager.GetInstance.MoveScene();
        }

        StartCoroutine(LoadSceneAsyncCoroutine(_name));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        bool isQuesting = false;
        if(PopupManager.GetInstance.Questing_Popup.activeSelf)
        {
            isQuesting = true;
            PopupManager.GetInstance.Questing_Popup.SetActive(false);
        }

       

        float elapsedTime = 0f;
        float targetTime = 2f;

        
        while (true)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= targetTime)
            {
                asyncOperation = SceneManager.LoadSceneAsync(sceneName);
                asyncOperation.allowSceneActivation = false;

                break;
            }
            else
            {
                LoadNum = elapsedTime / targetTime;

            }
            
           
            yield return null;
        }
        

        while (asyncOperation.progress < 0.9f)
        { 
            yield return null;
        }

        if(UIManager.GetInstance != null)
        {
            UIManager.GetInstance.CompleteMoveScene();
        }
        asyncOperation.allowSceneActivation = true;

        if (isQuesting)
        {
            Invoke("WaitForPopup", 3f);
        }

        if(bgmNum != 0) Invoke("StartBGM", 2f);
    }

    public void WaitForPopup()
    {
        PopupManager.GetInstance.Questing_Popup.SetActive(true);
    }

    public void StartBGM()
    {
        AudioManager.GetInstance.PlayBgm(bgmNum);
    }

}
