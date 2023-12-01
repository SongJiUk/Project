using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSlotScene : MonoBehaviour
{

    
    [SerializeField] Customizing playercutomizing;
    [SerializeField] WeaponManager playerWeapon;


    [SerializeField] GameObject[] UseSlot;
    [SerializeField] GameObject[] NoUseSlot;


    #region 플레이어 직업 및 장비별로 애니메이션 변경
    [SerializeField] GameObject[] Player_Anim;
    public List<GameObject> playerInfos = new List<GameObject>();
    public List<Text> playerName_txt = new List<Text>();
    public List<Text> playerJob_txt = new List<Text>();
    public List<Text> playerLevel_txt = new List<Text>();

    public RuntimeAnimatorController[] PlayerJob;
    public GameObject obj;
    public Animator anim;
    #endregion

    #region 하단에 게임시작 및 캐릭터 삭제 버튼
    [SerializeField] GameObject GameStart_Btn;
    [SerializeField] GameObject CreateCharacter_Btn;
    [SerializeField] GameObject DeleteSlot_Btn;

    [SerializeField] GameObject gameStartPopup;
    [SerializeField] Text gameStart_txt;

    [SerializeField] GameObject CreateCharacter_Popup;
    [SerializeField] Text CreateCharacter_txt;

    [SerializeField] GameObject DeleteSlot_Popup;
    [SerializeField] Text DeleteSlot_txt;
    [SerializeField] GameObject CompleteDelete_Popup;
    int SlotNum;
    #endregion





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
                UseSlot[i].SetActive(true);
            }
            else
            {
                playerInfos[i].SetActive(false);
                NoUseSlot[i].SetActive(true);
            }
        }
    }

   
    public void SelectSlot(int _num)
    {
        playercutomizing.gameObject.SetActive(false);

        GameStart_Btn.SetActive(false);
        DeleteSlot_Btn.SetActive(false);
        CreateCharacter_Btn.SetActive(false);

        SlotNum = _num;

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



            GameStart_Btn.SetActive(true);
            DeleteSlot_Btn.SetActive(true);
           
        }
        else
        {
            DataManager.GetInstance.SLOT_NUM = _num;
            playercutomizing.gameObject.SetActive(false);

            CreateCharacter_Btn.SetActive(true);

            
        }
    }

    public void ClickCreateBtn(bool _isanswer)
    {
        if(_isanswer)
        {
            CreateCharacter_Popup.SetActive(false);

            LoadManager.GetInstance.LoadSceneAsync("2_CharacterSelect");
        }
        else CreateCharacter_Popup.SetActive(false);
    }

    public void ClickPlayBtn(bool _isanswer)
    {
        if (_isanswer)
        {
            gameStartPopup.SetActive(false);
            QuestManager.GetInstance.CheckQuestData();
            AudioManager.GetInstance.StopBgm();
            LoadManager.GetInstance.LoadSceneAsync("4_TownMap");
        }
        else gameStartPopup.SetActive(false);
    }

    public void ClickDeleteBtn(bool _isanswer)
    {
        if(_isanswer)
        {
            
            playercutomizing.gameObject.SetActive(false);
            UseSlot[SlotNum].SetActive(false);
            NoUseSlot[SlotNum].SetActive(true);
            CompleteDelete_Popup.SetActive(true);
            DeleteSlot_Popup.SetActive(false);

            CreateCharacter_Btn.SetActive(true);
            GameStart_Btn.SetActive(false);
            DeleteSlot_Btn.SetActive(false);

            DataManager.GetInstance.DeleteData(SlotNum);
        }
        else DeleteSlot_Popup.SetActive(false);
    }


    public void GameStart()
    {
        gameStartPopup.SetActive(true);
        gameStart_txt.text = $"{SlotNum + 1}번 슬롯의 영웅으로 플레이 하시겠습니까?";
    }

    public void Create()
    {
        CreateCharacter_Popup.SetActive(true);
        CreateCharacter_txt.text = $"{SlotNum + 1}번 슬롯에 캐릭터를 생성하시겠습니까?";
    }

    public void DeleteSlot()
    {
        DeleteSlot_Popup.SetActive(true);
        DeleteSlot_txt.text = $"정말 {SlotNum + 1 }번 슬롯에 있는 캐릭터를 삭제하시겠습니? 모든 정보가 삭제됩니다.";
    }

    public void CompleteDeletePopup()
    {
        CompleteDelete_Popup.SetActive(false);
    }
}
