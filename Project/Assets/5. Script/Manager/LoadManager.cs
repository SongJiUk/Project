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
    private void Awake()
    {
        DataManager.GetInstance.LoadData();
        DontDestroyOnLoad(gameObject);
    }
    public void LoadSceneAsync(string _name)
    {
        SceneManager.LoadScene(LoadSceneName);
        if (UIManager.GetInstance != null)
        {
            UIManager.GetInstance.MoveScene();
        }

        StartCoroutine(LoadSceneAsyncCoroutine(_name));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {


       

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

    }

}
