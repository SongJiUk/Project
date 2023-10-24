using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSlotScene : MonoBehaviour
{

    [SerializeField] GameObject selectPopup;
    [SerializeField] Text slot_txt;
    [SerializeField] Customizing player;

    [SerializeField] GameObject gameStartPopup;
    [SerializeField] Text gameStart_txt;


    public List<GameObject> playerInfos = new List<GameObject>();
    public List<Text> playerName_txt = new List<Text>();
    public List<Text> playerJob_txt = new List<Text>();
    public List<Text> playerLevel_txt = new List<Text>();
    private void Start()
    {
        if (null == player) player = GetComponent<Customizing>();
        for(int i =0; i<DataManager.SlotCount; i++)
        {
            if(DataManager.GetInstance.ISSLOTOPEN(i))
            {
                playerInfos[i].SetActive(true);
                playerName_txt[i].text = $"{DataManager.GetInstance.PLAYER_ID(i)}";
                playerJob_txt[i].text = $"{DataManager.GetInstance.UnitCodes(i).ToString()}";
                playerLevel_txt[i].text = $"{DataManager.GetInstance.PLAYER_LEVEL(i)}";
            }
            else
            {
                playerInfos[i].SetActive(false);
            }
        }
    }

    public void SelectSlot(int _num)
    {
        player.gameObject.SetActive(false);

        //Debug.Log("DataManager : "+DataManager.GetInstance.SLOT_NUM);
        if (DataManager.GetInstance.ISSLOTOPEN(_num))
        {
            DataManager.GetInstance.SLOT_NUM = _num;
            player.InitPlayer(_num);
            player.gameObject.SetActive(true);

            gameStartPopup.SetActive(true);
            gameStart_txt.text = $"{_num +1}번 슬롯의 영웅으로 플레이 하시겠습니까?";
        }
        else
        {
            DataManager.GetInstance.SLOT_NUM = _num;
            player.gameObject.SetActive(false);
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
            var operation = SceneManager.LoadSceneAsync("2_CharacterSelect");
            operation.allowSceneActivation = true;
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
            //var operation = SceneManager.LoadSceneAsync("4_TownMap");
            var operation = SceneManager.LoadSceneAsync("5_Dungeon");
            operation.allowSceneActivation = true;
        }
        else
        {
            gameStartPopup.SetActive(false);
        }
    }
}
