using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Canvas[] UsePlayingObj;
    [SerializeField] GameObject UsePlayeringGameObj;

    public Customizing customizing;
    public WeaponManager weaponManger;


    [SerializeField] GameObject[] CloseUI;

    public int isOnPopupCount;
    //[SerializeField] GameObject
    public bool isNoEquip = false;
    private void Awake()
    {
        //DontDestroyOnLoad(this);
        if (customizing == null) customizing = Player.GetInstance.GetComponent<Customizing>();
        if (null == weaponManger) weaponManger = Player.GetInstance.GetComponent<WeaponManager>();
        isOnPopupCount = 0;
    }

    void Start()
    {
       
    }

    public void ErrorForNull_Reset()
    {
        if (customizing == null) customizing = Player.GetInstance.GetComponent<Customizing>();
        if (null == weaponManger) weaponManger = Player.GetInstance.GetComponent<WeaponManager>();
    }

    public void MoveScene()
    {
        //for (int i = 0; i < UsePlayingObj.Length; i++)
        //{
        //    UsePlayingObj[i].enabled = false;
        //}
        //UsePlayeringGameObj.SetActive(false);
    }

    public void CompleteMoveScene()
    {
        //for (int i = 0; i < UsePlayingObj.Length; i++)
        //{
        //    UsePlayingObj[i].enabled = true;
        //}
        //UsePlayeringGameObj.SetActive(true);
    }

    private void Update()
    {
    //    if (SceneManager.GetActiveScene().name != "LoadScene")
    //    {
    //        if (customizing == null) customizing = Player.GetInstance.GetComponent<Customizing>();
    //        if (null == weaponManger) weaponManger = Player.GetInstance.GetComponent<WeaponManager>();
    //    }
        
    }
}
