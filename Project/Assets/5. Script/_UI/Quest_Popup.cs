using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Popup : MonoBehaviour
{
    QuestDatas NowQuest;

    [SerializeField] Inventory _inventory;

    public Inventory Inventory { get { return _inventory; } }


    [SerializeField] Text QuestName_txt;
    [SerializeField] Text QuestTitle_txt;
    [SerializeField] Image[] Quest_Reward_Img;
    [SerializeField] Text[] Quest_Reward_Amount_txt;
    [SerializeField] GameObject already_received_Popup;
    [SerializeField] List<GameObject> Btns;

    private void OnEnable()
    {
        NowQuest = QuestManager.GetInstance.GetNowQuest();
        if(!QuestManager.GetInstance.isAllClear) UpdatePopup();

        CameraManager.GetInstance.ISUIOFF = false;
        UIManager.GetInstance.isOnPopupCount++;

    }

    private void OnDisable()
    {
        
    }

    void UpdatePopup()
    {
        if(QuestManager.GetInstance.QuestCheck())
        {
            QuestName_txt.text = "퀘스트 완료";
            QuestTitle_txt.text = "감사합니다! 약속한 보상을 드릴테니 사양말고 받아주세요!, 체력도 회복시켜드릴게요!";

            PlayerStat.GetInstance.Recorvery();

            for (int i = 0; i < Quest_Reward_Img.Length; i++)
            {
                Quest_Reward_Img[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < NowQuest.Rewarditems.Count; i++)
            {
                Quest_Reward_Img[i].gameObject.SetActive(true);

                Quest_Reward_Img[i].sprite = NowQuest.Rewarditems[i].IconSprite;
                if (NowQuest.Rewarditems[i].ItemType == ItemType.PortionItem)
                {
                    Quest_Reward_Amount_txt[i].text = $"X {NowQuest.Reward_Portion_Amount}";
                    
                }
                else if (NowQuest.Rewarditems[i].ItemType == ItemType.WeaponItem)
                {
                    Quest_Reward_Amount_txt[i].text = $"X 1";
                }
                else
                {
                    Quest_Reward_Amount_txt[i].text = $"X {NowQuest.Reward_Gold_Amount}";
                }
            }

            for(int i =0; i<Btns.Count; i++)
            {
                if (i == 2) Btns[i].SetActive(true);
                else Btns[i].SetActive(false);
            }
        }
        else
        {
            QuestName_txt.text = NowQuest.goal;
            QuestTitle_txt.text = NowQuest.title;

            for (int i = 0; i < Quest_Reward_Img.Length; i++)
            {
                Quest_Reward_Img[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < NowQuest.Rewarditems.Count; i++)
            {
                
                Quest_Reward_Img[i].gameObject.SetActive(true);

                Quest_Reward_Img[i].sprite = NowQuest.Rewarditems[i].IconSprite;
                if (NowQuest.Rewarditems[i].ItemType == ItemType.PortionItem)
                {
                    Quest_Reward_Amount_txt[i].text = $"X {NowQuest.Reward_Portion_Amount}";
                }
                else if(NowQuest.Rewarditems[i].ItemType == ItemType.WeaponItem)
                {
                    Quest_Reward_Amount_txt[i].text = $"X 1";
                }
                else
                {
                    Quest_Reward_Amount_txt[i].text = $"X {NowQuest.Reward_Gold_Amount}";
                }
            }


            for (int i = 0; i < Btns.Count; i++)
            {
                if (i == 2) Btns[i].SetActive(false);
                else Btns[i].SetActive(true);
            }

        }

        
       
    }

    public void AcceptQuest()
    {
        if (QuestManager.GetInstance.isQuesting) already_received_Popup.SetActive(true);
        else gameObject.SetActive(false);

        if (QuestManager.GetInstance.QUESTID == 10)
        {
            QuestManager.GetInstance.QuestMidterminspection();
        }

        QuestManager.GetInstance.EndChangePopup();
        QuestManager.GetInstance.NPCID = NowQuest.After_NPCId;
        QuestManager.GetInstance.isQuesting = true;

        QuestManager.GetInstance.ChangeNpcPopup();


        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;


        PopupManager.GetInstance.Questing_Popup.SetActive(true);
        Questing_popup.GetInstance.AcceptQuest(NowQuest.questtype, NowQuest.goal, NowQuest.KillCount);



        //for (int i = 0; i < UIManager.GetInstance.NPC.Length; i++)
        //{
        //    if (UIManager.GetInstance.NPC[i].NPCID == QuestManager.GetInstance.QUESTID)
        //    {
        //        QuestManager.GetInstance.NPCUP_ICON = UIManager.GetInstance.Quest_NPC[i];
        //    }
        //}
    }

    public void RefuseQuest()
    {
        gameObject.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;
    }

    public void ReceiveRewardItem()
    {
        for (int i = 0; i < UIManager.GetInstance.Quest_NPC.Length; i++)
        {
            UIManager.GetInstance.Quest_NPC[i].ALLCLEAR();
        }

        gameObject.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;

        

        for (int i=0; i< NowQuest.Rewarditems.Count; i++)
        {
            if(NowQuest.Rewarditems[i].ItemType == ItemType.Gold)
            {
                _inventory.GetGold(NowQuest.Reward_Gold_Amount);
            }
            else if(NowQuest.Rewarditems[i].ItemType == ItemType.WeaponItem)
            {
                WeaponItemData wid = NowQuest.Rewarditems[i] as WeaponItemData;
                switch(DataManager.GetInstance.GET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM))
                {
                    case 0:
                        if (wid.Type == Types.Dagger) _inventory.Add(NowQuest.Rewarditems[i]);
                        break;
                    case 1:
                        if (wid.Type == Types.Staff) _inventory.Add(NowQuest.Rewarditems[i]);
                        break;
                    case 2:
                        if (wid.Type == Types.Bow) _inventory.Add(NowQuest.Rewarditems[i]);
                        break;

                }
               
            }
            else _inventory.Add(NowQuest.Rewarditems[i], NowQuest.Reward_Portion_Amount); 
        }

        QuestManager.GetInstance.ClearQuest();
        QuestManager.GetInstance.ChangeNpcPopup();
        PopupManager.GetInstance.Questing_Popup.SetActive(false);
    }

    public void AlreadyQuest_Btn()
    {
        already_received_Popup.SetActive(false);
        gameObject.SetActive(false);
    }

}
