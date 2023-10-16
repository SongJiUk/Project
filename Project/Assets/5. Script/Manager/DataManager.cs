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
    private void Start()
    {
        DontDestroyOnLoad(this);
    }


    bool[] isSlotOpen;

    public bool[] ISSLOTOPEN
    {
        get
        {
            if (isSlotOpen == null)
            {
                isSlotOpen = new bool[3];
            }
            return isSlotOpen;
        }
        set => isSlotOpen = value;
    }

    #region 플레이어 커스터마이징
    int GenderNum;
    int HairNum;
    int Female_FaceNum;
    int male_FaceNum;
    int Female_EyebrowNum;
    int male_EyebrowNum;
    int MustacheNum;
    int Female_TopNum;
    int Female_PantsNum;
    int male_TopNum;
    int male_PantsNum;

    
    public int GENDERNUM
    {
        get { return GenderNum; }
        set { GenderNum = value; }
    }

    public int HAIRNUM
    {
        get { return HairNum; }
        set { HairNum = value; }
    }

    public int FEMALE_FACENUM
    {
        get { return Female_FaceNum; }
        set { Female_FaceNum = value; }
    }

    public int MALE_FACENUM
    {
        get { return male_FaceNum; }
        set { male_FaceNum = value; }
    }

    public int FEMALE_EYEBROWNUM
    {
        get { return Female_EyebrowNum; }
        set { Female_EyebrowNum = value; }
    }

    public int MALE_EYEBROWNUM
    {
        get { return male_EyebrowNum; }
        set { male_EyebrowNum = value; }
    }
    public int MUSTACHENUM
    {
        get { return MustacheNum; }
        set { MustacheNum = value; }
    }

    public int FEMALE_TOPNUM
    {
        get { return Female_TopNum; }
        set { Female_TopNum = value; }
    }
    public int FEMALE_PANTSNUM
    {
        get { return Female_PantsNum; }
        set { Female_PantsNum = value; }
    }
    public int MALE_TOPNUM
    {
        get { return male_TopNum; }
        set { male_TopNum = value; }
    } public int MALE_PANTSNUM
    {
        get { return male_PantsNum; }
        set { male_PantsNum = value; }
    }


    #endregion
    int Slot_Num;

    string player_id;
    int player_level;
    float player_exp;
    
    public int SLOT_NUM
    {
        get => Slot_Num;
        set => Slot_Num = value;
    }


    public string PLAYER_ID
    {
        get { return player_id; }
        set { player_id = value; }
    }

    public int PLAYER_LEVEL
    {
        get { return player_level; }
        set { player_level = value; }
    }

    public float PLAYER_EXP
    {
        get { return player_exp; }
        set { player_exp = value; }
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
        int tmp = PlayerPrefs.GetInt(key,-100);
        if (tmp == 1)
            return true;
        else if (tmp == -100)
            return false;
        else
            return null;
    }


    public void SaveData(int _index)
    {
        
        isSlotOpen[_index] = true;
        SetBool("isSlotOpen" + _index, isSlotOpen[_index]);

        PlayerPrefs.SetFloat("player_exp" + _index, player_exp);
        PlayerPrefs.SetInt("player_level" + _index, player_level);
        PlayerPrefs.SetString("player_id" + _index, player_id);

        PlayerPrefs.SetInt("GenderNum" + _index, GenderNum);
        PlayerPrefs.SetInt("Female_FaceNum" + _index, Female_FaceNum);
        PlayerPrefs.SetInt("male_FaceNum" + _index, male_FaceNum);
        PlayerPrefs.SetInt("Female_EyebrowNum" + _index, Female_EyebrowNum);
        PlayerPrefs.SetInt("male_EyebrowNum" + _index, male_EyebrowNum);
        PlayerPrefs.SetInt("MustacheNum" + _index, MustacheNum);
        PlayerPrefs.SetInt("Female_TopNum" + _index, Female_TopNum);
        PlayerPrefs.SetInt("male_TopNum" + _index, male_TopNum);
        PlayerPrefs.SetInt("Female_PantsNum" + _index, Female_PantsNum);
        PlayerPrefs.SetInt("male_PantsNum" + _index, male_PantsNum);

        int equipindex = 0;

        PlayerPrefs.SetInt("Equip_" + equipindex +"_"+ _index, male_PantsNum);


        PlayerPrefs.Save();
    }


    public void LoadData()
    {

        for(int i = 0; i< SlotCount; i++)
        {
            isSlotOpen[i] = GetBool("isSlotOpen"+i).HasValue;

            if (isSlotOpen[i])
            {
                player_level = PlayerPrefs.GetInt("player_level" + i);
                player_exp = PlayerPrefs.GetFloat("player_exp" + i);
                player_id = PlayerPrefs.GetString("player_id" + i);

                GenderNum = PlayerPrefs.GetInt("GenderNum" + i);
                Female_FaceNum = PlayerPrefs.GetInt("Female_FaceNum" + i);
                male_FaceNum = PlayerPrefs.GetInt("male_FaceNum" + i);
                Female_EyebrowNum = PlayerPrefs.GetInt("Female_EyebrowNum" + i);
                male_EyebrowNum = PlayerPrefs.GetInt("male_EyebrowNum" + i);
                MustacheNum = PlayerPrefs.GetInt("MustacheNum" + i);
                Female_TopNum = PlayerPrefs.GetInt("Female_TopNum" + i);
                male_TopNum = PlayerPrefs.GetInt("male_TopNum" + i);
                Female_PantsNum = PlayerPrefs.GetInt("Female_PantsNum" + i);
                male_PantsNum = PlayerPrefs.GetInt("male_PantsNum" + i);
            }

        }
        
    }
}
