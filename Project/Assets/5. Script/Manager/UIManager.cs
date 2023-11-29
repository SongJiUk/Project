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


    public ScreenSlotUI[] SkillCoolTime;

    public Inventory inventory;

    public NPC[] NPC;
    public Quest_NPCUP[] Quest_NPC;
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

    public bool CheckCoolTime(int _SkillNum)
    {
        switch(_SkillNum)
        {
            case 1:

                return SkillCoolTime[0].CheckCoolTime();

            case 2:
                return SkillCoolTime[1].CheckCoolTime();

            case 3:
                return SkillCoolTime[2].CheckCoolTime();


        }
        return false;
    }

    #region 사운드 관련

    public void UISound(string _key)
    {
        AudioManager.GetInstance.UISound(_key);
    }
    #endregion
}
