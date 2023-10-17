using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : Singleton<DataManager>
{
    /*

저장해야될것들
1. 플레이어 - 아이디, 레벨, 경험치, hp, mp, 커스터마이징
2. 아이템 - 무기번호, 골드, 물약 등

*/
    static int SlotCount = 3;
    Dictionary<int, PlayerJobs> SlotJob = new Dictionary<int, PlayerJobs>();

    public PlayerJobs PLAYERJOBS(int _slot)
    {
        return SlotJob[_slot];
    }

    public void PLAYERJOBS(int _slot, PlayerJobs _vaule)
    {
        if(!SlotJob.ContainsKey(_slot))
        {
            SlotJob.Add(_slot, _vaule);
        }

    }


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    bool[] isSlotOpen = new bool[SlotCount];

    public bool ISSLOTOPEN(int _slot)
    {
        return isSlotOpen[_slot];
    }
    public void ISSLOTOPEN(int _slot, bool value)
    {
        isSlotOpen[_slot] = value;
    }

    public static void SetBool(string key, bool value)
    {
        if (value)
            PlayerPrefs.SetInt(key, 1);
        else
            PlayerPrefs.SetInt(key, 0);
    }

    public static bool? GetBool(string key)
    {
        int tmp = PlayerPrefs.GetInt(key, -100);
        if (tmp == 1)
            return true;
        else if (tmp == -100)
            return false;
        else
            return null;
    }

    #region 플레이어 커스터마이징
    int[] GenderNum = new int[SlotCount];
    int[] HairNum = new int[SlotCount];
    int[] Female_FaceNum = new int[SlotCount];
    int[] male_FaceNum = new int[SlotCount];
    int[] Female_EyebrowNum = new int[SlotCount];
    int[] male_EyebrowNum = new int[SlotCount];
    int[] MustacheNum = new int[SlotCount];
    int[] Female_TopNum = new int[SlotCount];
    int[] Female_PantsNum = new int[SlotCount];
    int[] male_TopNum = new int[SlotCount];
    int[] male_PantsNum = new int[SlotCount];

    public int GENDERNUM(int _slot)
    {
        return GenderNum[_slot];
    }
    public void GENDERNUM(int _slot, int value)
    {
        GenderNum[_slot] = value;
    }

    public int HAIRNUM(int _slot)
    {
        return HairNum[_slot];
    }

    public void HAIRNUM(int _slot, int value)
    {
       HairNum[_slot] = value;
    }
    
    public int FEMALE_FACENUM(int _slot)
    {
        return Female_FaceNum[_slot];
    }

    public void FEMALE_FACENUM(int _slot, int value)
    {
        Female_FaceNum[_slot] = value;
    }


    public int MALE_FACENUM(int _slot)
    {
        return male_FaceNum[_slot];
    }

    public void MALE_FACENUM(int _slot, int value)
    {
        male_FaceNum[_slot] = value;
    }

    public int FEMALE_EYEBROWNUM(int _slot)
    {
        return Female_EyebrowNum[_slot];
    }

    public void FEMALE_EYEBROWNUM(int _slot, int value)
    {
        Female_EyebrowNum[_slot] = value;
    }

    public int MALE_EYEBROWNUM(int _slot)
    {
        return male_EyebrowNum[_slot];
    }

    public void MALE_EYEBROWNUM(int _slot, int value)
    {
        male_EyebrowNum[_slot] = value;
    }

    public int MUSTACHENUM(int _slot)
    {
        return MustacheNum[_slot];
    }

    public void MUSTACHENUM(int _slot, int value)
    {
        MustacheNum[_slot] = value;
    }

    public int FEMALE_TOPNUM(int _slot)
    {
        return Female_TopNum[_slot];
    }

    public void FEMALE_TOPNUM(int _slot, int value)
    {
        Female_TopNum[_slot] = value;
    }

    public int FEMALE_PANTSNUM(int _slot)
    {
        return Female_PantsNum[_slot];
    }

    public void FEMALE_PANTSNUM(int _slot, int value)
    {
        Female_PantsNum[_slot] = value;
    }

    public int MALE_TOPNUM(int _slot)
    {
        return male_TopNum[_slot];
    }

    public void MALE_TOPNUM(int _slot, int value)
    {
        male_TopNum[_slot] = value;
    }

    public int MALE_PANTSNUM(int _slot)
    {
        return male_PantsNum[_slot];
    }

    public void MALE_PANTSNUM(int _slot, int value)
    {
        male_PantsNum[_slot] = value;
    }

    #endregion
    int Slot_Num;

    PlayerJobs[] playerJobs;
    string[] player_id = new string[SlotCount];
    int[] player_level = new int[SlotCount];
    float[] player_exp = new float[SlotCount];
    
    public int SLOT_NUM
    {
        get => Slot_Num;
        set => Slot_Num = value;
    }


    public string PLAYER_ID(int _slot)
    {
        return player_id[_slot];
    }

    public void PLAYER_ID(int _slot, string value)
    {
        player_id[_slot] = value;
    }

    public int PLAYER_LEVEL(int _slot)
    {
        return player_level[_slot];
    }

    public void PLAYER_LEVEL(int _slot, int value)
    {
        player_level[_slot] = value;
    }

    public float PLAYER_EXP(int _slot)
    {
        return player_exp[_slot];
    }

    public void PLAYER_EXP(int _slot, float value)
    {
        player_exp[_slot] = value;
    }

    


    public void SaveData(int _index)
    {
        
        isSlotOpen[_index] = true;
        SetBool("isSlotOpen" + _index, isSlotOpen[_index]);

        PlayerPrefs.SetInt("SlotJob"+_index, (int)SlotJob[_index]);

        PlayerPrefs.SetFloat("player_exp" + _index, player_exp[_index]);
        PlayerPrefs.SetInt("player_level" + _index, player_level[_index]);
        PlayerPrefs.SetString("player_id" + _index, player_id[_index]);

        PlayerPrefs.SetInt("GenderNum" + _index, GenderNum[_index]);
        PlayerPrefs.SetInt("Female_FaceNum" + _index, Female_FaceNum[_index]);
        PlayerPrefs.SetInt("male_FaceNum" + _index, male_FaceNum[_index]);
        PlayerPrefs.SetInt("Female_EyebrowNum" + _index, Female_EyebrowNum[_index]);
        PlayerPrefs.SetInt("male_EyebrowNum" + _index, male_EyebrowNum[_index]);
        PlayerPrefs.SetInt("MustacheNum" + _index, MustacheNum[_index]);
        PlayerPrefs.SetInt("Female_TopNum" + _index, Female_TopNum[_index]);
        PlayerPrefs.SetInt("male_TopNum" + _index, male_TopNum[_index]);
        PlayerPrefs.SetInt("Female_PantsNum" + _index, Female_PantsNum[_index]);
        PlayerPrefs.SetInt("male_PantsNum" + _index, male_PantsNum[_index]);

        //int equipindex = 0;

        //PlayerPrefs.SetInt("Equip_" + equipindex +"_"+ _index, male_PantsNum);


        PlayerPrefs.Save();
    }


    public void LoadData()
    {

        for(int i = 0; i< SlotCount; i++)
        {

            string isSlotOpenKey = "isSlotOpen" + i;
            if (PlayerPrefs.HasKey(isSlotOpenKey)) isSlotOpen[i] = GetBool(isSlotOpenKey).HasValue;
            else isSlotOpen[i] = false;

            if (isSlotOpen[i])
            {
                SlotJob[i] = (PlayerJobs)PlayerPrefs.GetInt("SlotJob" + i);

                player_level[i] = PlayerPrefs.GetInt("player_level" + i);
                player_exp[i] = PlayerPrefs.GetFloat("player_exp" + i);
                player_id[i] = PlayerPrefs.GetString("player_id" + i);

                GenderNum[i] = PlayerPrefs.GetInt("GenderNum" + i);
                Female_FaceNum[i] = PlayerPrefs.GetInt("Female_FaceNum" + i);
                male_FaceNum[i] = PlayerPrefs.GetInt("male_FaceNum" + i);
                Female_EyebrowNum[i] = PlayerPrefs.GetInt("Female_EyebrowNum" + i);
                male_EyebrowNum[i] = PlayerPrefs.GetInt("male_EyebrowNum" + i);
                MustacheNum[i] = PlayerPrefs.GetInt("MustacheNum" + i);
                Female_TopNum[i] = PlayerPrefs.GetInt("Female_TopNum" + i);
                male_TopNum[i] = PlayerPrefs.GetInt("male_TopNum" + i);
                Female_PantsNum[i] = PlayerPrefs.GetInt("Female_PantsNum" + i);
                male_PantsNum[i] = PlayerPrefs.GetInt("male_PantsNum" + i);
            }

            if(SlotJob.ContainsKey(i)) Debug.Log(SlotJob[i]);
        }
        
    }
}
