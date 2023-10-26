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
    //[SerializeField] GameObject
    public bool isNoEquip = false;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name.Equals("LoadScene"))
        {
            for (int i = 0; i < UsePlayingObj.Length; i++)
            {
                UsePlayingObj[i].enabled = false;
            }
            UsePlayeringGameObj.SetActive(false);
        }



        if (customizing == null) customizing = Player.GetInstance.GetComponent<Customizing>();
        if (null == weaponManger) weaponManger = Player.GetInstance.GetComponent<WeaponManager>();
    }

    public void MoveScene()
    {
        for (int i = 0; i < UsePlayingObj.Length; i++)
        {
            UsePlayingObj[i].enabled = false;
        }
        UsePlayeringGameObj.SetActive(false);
    }

    public void CompleteMoveScene()
    {
        if (SceneManager.GetActiveScene().name.Equals("4_TownMap") ||
           SceneManager.GetActiveScene().name.Equals("5_Dungeon"))
        {
            for (int i = 0; i < UsePlayingObj.Length; i++)
            {
                UsePlayingObj[i].enabled = true;
            }
            UsePlayeringGameObj.SetActive(true);
        }
        else
        {
            for (int i = 0; i < UsePlayingObj.Length; i++)
            {
                UsePlayingObj[i].enabled = false;
            }
            UsePlayeringGameObj.SetActive(false);
        }
    }
}
