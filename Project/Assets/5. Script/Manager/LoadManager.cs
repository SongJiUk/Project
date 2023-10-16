using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    private void Start()
    {
        DataManager.GetInstance.LoadData();
        
    }


    //private IEnumerator GoToNextSceneCoroutine()
    //{
    //    yield return new WaitForSeconds(0.05f);
    //    Screen.sleepTimeout = SleepTimeout.NeverSleep;

    //    Debug.LogWarningFormat("KKI GoToNextSceneCoroutine");
    //    var operation = SceneManager.LoadSceneAsync("");
    //    operation.allowSceneActivation = false;
    //    LoadingGauge._Checking = false;

    //    yield return new WaitForEndOfFrame();
    //    LoadingGauge._Persent = 2;
    //    Purchaser.GetInstance.Init();
    //    LoadingGauge._Persent = 5;
    //    var value = false;
    //    var delay = 0.0f;
    //    int limitCount = 0;

    //    LoadingGauge._Persent = 10;
    //    yield return new WaitWhile(() => LoadingGauge._Checking == false);
    //    LoadingGauge._Checking = false;
    //    LoadingImageManager._isGameStart = true;
    //    LoadingImageManager.LoadingImageNumber = 100;
    //    //AdsManager.GetInstance.InitAds();
    //    LoadingGauge._Persent = 30;
    //    yield return new WaitWhile(() => LoadingGauge._Checking == false);
    //    LoadingGauge._Checking = false;
    //    yield return new WaitWhile(() => LoadingGauge._Checking == false);
    //    LoadingGauge._Checking = false;
    //    //FirebaseManager.GetInstance.Init();
    //    Application.targetFrameRate = 60;
    //    QualitySettings.vSyncCount = 0;
    //    PlayerData.GetInstance.LoadData();

    

    //    //if (!PlayerData.GetInstance.IsPlayBGM)
    //    //{
    //    //    MasterAudio.PlaylistMasterVolume = 0f;
    //    //}
    //    //else
    //    //{
    //    //    MasterAudio.PlaylistMasterVolume = 1f;
    //    //}

    //    //if (!PlayerData.GetInstance.IsPlaySFX)
    //    //{
    //    //    MasterAudio.SetBusVolumeByName("SFX", 0f);
    //    //    MasterAudio.SetBusVolumeByName("Loop", 0f);
    //    //}
    //    //else
    //    //{
    //    //    MasterAudio.SetBusVolumeByName("SFX", 1f);
    //    //    MasterAudio.SetBusVolumeByName("Loop", 1f);
    //    //}

    //    LoadingGauge._Persent = 60;
    //    yield return new WaitWhile(() => LoadingGauge._Checking == false);
    //    LoadingGauge._Checking = false;

       
    //    LoadingGauge._Persent = 70;
    //    yield return new WaitWhile(() => LoadingGauge._Checking == false);
    //    LoadingGauge._Checking = false;
    //    LanguageManager.GetInstance.Init();
    //    LoadingGauge._Persent = 80;
    //    yield return new WaitWhile(() => LoadingGauge._Checking == false);
    //    LoadingGauge._Checking = false;

    //    //SingularSDK.InitializeSingularSDK();


    //    //GameObject obj = GameObject.Find("PopupManager");   
    //    //obj.GetComponent<PopupManager>().CallLoadingTutorialPop("MainScene");
    //    LoadingGauge._Persent = 90;
    //    yield return new WaitWhile(() => LoadingGauge._Checking == false);
    //    LoadingGauge._Checking = false;
    //    operation.allowSceneActivation = true;
    //}

}
