using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    /*

저장해야될것들
1. 플레이어 - 아이디, 레벨, 경험치, hp, mp, 커스터마이징
2. 아이템 - 무기번호, 골드, 물약 등

*/
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    #region 플레이어 커스터마이#
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

    string player_id;
    int player_level;
    float player_exp;
    

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
   




    public void SaveData()
    {
       
        PlayerPrefs.SetFloat("player_exp", player_exp);
        PlayerPrefs.SetInt("player_level", player_level);
        PlayerPrefs.SetString("player_id", player_id);

        PlayerPrefs.SetInt("GenderNum", GenderNum);
        PlayerPrefs.SetInt("Female_FaceNum", Female_FaceNum);
        PlayerPrefs.SetInt("male_FaceNum", male_FaceNum);
        PlayerPrefs.SetInt("Female_EyebrowNum", Female_EyebrowNum);
        PlayerPrefs.SetInt("male_EyebrowNum", male_EyebrowNum);
        PlayerPrefs.SetInt("MustacheNum", MustacheNum);
        PlayerPrefs.SetInt("Female_TopNum", Female_TopNum);
        PlayerPrefs.SetInt("male_TopNum", male_TopNum);
        PlayerPrefs.SetInt("Female_PantsNum", Female_PantsNum);
        PlayerPrefs.SetInt("male_PantsNum", male_PantsNum);

        PlayerPrefs.Save();
    }


    public void LoadData()
    {
        player_level = PlayerPrefs.GetInt("player_level", player_level);
        player_exp = PlayerPrefs.GetFloat("player_exp", player_exp);
        player_id = PlayerPrefs.GetString("player_id", player_id);

        GenderNum = PlayerPrefs.GetInt("GenderNum", GenderNum);
        Female_FaceNum = PlayerPrefs.GetInt("Female_FaceNum", Female_FaceNum);
        male_FaceNum = PlayerPrefs.GetInt("male_FaceNum", male_FaceNum);
        Female_EyebrowNum = PlayerPrefs.GetInt("Female_EyebrowNum", Female_EyebrowNum);
        male_EyebrowNum = PlayerPrefs.GetInt("male_EyebrowNum", male_EyebrowNum);
        MustacheNum = PlayerPrefs.GetInt("MustacheNum", MustacheNum);
        Female_TopNum = PlayerPrefs.GetInt("Female_TopNum", Female_TopNum);
        male_TopNum = PlayerPrefs.GetInt("male_TopNum", male_TopNum);
        Female_PantsNum = PlayerPrefs.GetInt("Female_PantsNum", Female_PantsNum);
        male_PantsNum = PlayerPrefs.GetInt("male_PantsNum", male_PantsNum);
        
    }
}
