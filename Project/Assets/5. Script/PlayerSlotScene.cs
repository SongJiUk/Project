using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSlotScene : MonoBehaviour
{

    [SerializeField] GameObject selectPopup;
    [SerializeField] Text slot_txt;
    [SerializeField] Customizing playercutomizing;
    [SerializeField] WeaponManager playerWeapon;

    [SerializeField] GameObject gameStartPopup;
    [SerializeField] Text gameStart_txt;

    [SerializeField] GameObject[] Player_Anim;
    public List<GameObject> playerInfos = new List<GameObject>();
    public List<Text> playerName_txt = new List<Text>();
    public List<Text> playerJob_txt = new List<Text>();
    public List<Text> playerLevel_txt = new List<Text>();

    public RuntimeAnimatorController[] PlayerJob;
    public GameObject obj;
    public Animator anim;


    private void Start()
    {
        if (null == playercutomizing) playercutomizing = GetComponent<Customizing>();
        if (null == playerWeapon) playerWeapon = GetComponent<WeaponManager>();
        for (int i =0; i<DataManager.SlotCount; i++)
        {
            if(DataManager.GetInstance.GET_ISSLOTOPEN(i))
            {
                playerInfos[i].SetActive(true);
                playerName_txt[i].text = $"{DataManager.GetInstance.GET_PLAYER_ID(i)}";
                playerJob_txt[i].text = $"{DataManager.GetInstance.GET_UnitCodes(i).ToString()}";
                playerLevel_txt[i].text = $"{DataManager.GetInstance.GET_PLAYER_LEVEL(i)}";
            }
            else
            {
                playerInfos[i].SetActive(false);
            }
        }
    }

    public void ChangeAnim(int _num)
    {
        
        
    }

   
    public void SelectSlot(int _num)
    {
        playercutomizing.gameObject.SetActive(false);

        //Debug.Log("DataManager : "+DataManager.GetInstance.SLOT_NUM);
        if (DataManager.GetInstance.GET_ISSLOTOPEN(_num))
        {
            DataManager.GetInstance.SLOT_NUM = _num;
            playercutomizing.InitPlayer(_num);
            playercutomizing.InitEquipMentItem(_num);
            playerWeapon.InitEquipMentWeapon(_num);

            anim = obj.GetComponent<Animator>();
            int num = DataManager.GetInstance.GET_PLAYER_JOB(_num);
            anim.runtimeAnimatorController = PlayerJob[num];
            int weaponNum = DataManager.GetInstance.GET_WEAPONCODE(_num);

           
           int equipNum =  playerWeapon.FindIndex(weaponNum);

            playercutomizing.gameObject.SetActive(true);
            anim.SetInteger("EquipNum", equipNum);
            

            gameStartPopup.SetActive(true);
            gameStart_txt.text = $"{_num +1}번 슬롯의 영웅으로 플레이 하시겠습니까?";
        }
        else
        {
            DataManager.GetInstance.SLOT_NUM = _num;
            playercutomizing.gameObject.SetActive(false);
            //여기서 생성하시겠습니까? 띄워주기
            Debug.Log("생성하자!!");
            selectPopup.SetActive(true);
            slot_txt.text = $"{_num + 1}번 슬롯을 선택하시겠습니까?";
        }
    }

    public void ClickCreateBtn(bool _isanswer)
    {
        if(_isanswer)
        {
            selectPopup.SetActive(false);

            LoadManager.GetInstance.LoadSceneAsync("2_CharacterSelect");
            //var operation = SceneManager.LoadSceneAsync("2_CharacterSelect");
            //operation.allowSceneActivation = true;
        }
        else
        {
            selectPopup.SetActive(false);
        }
    }

    public void ClickPlayBtn(bool _isanswer)
    {
        if (_isanswer)
        {
            gameStartPopup.SetActive(false);
            LoadManager.GetInstance.LoadSceneAsync("4_TownMap");
            //var operation = SceneManager.LoadSceneAsync("4_Song");
            //var operation = SceneManager.LoadSceneAsync("4_TownMap");
            //var operation = SceneManager.LoadSceneAsync("5_Dungeon");
            //operation.allowSceneActivation = true;
        }
        else
        {
            gameStartPopup.SetActive(false);
        }
    }
}
