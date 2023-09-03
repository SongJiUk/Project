using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    int level;
    float exp;

    public int LEVEL
    {
        get { return level; }
        set { level = value;}
    }

    public float EXP
    {
        get { return exp; }
        set { exp = value; }
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("exp", exp);
        PlayerPrefs.SetInt("level", level);
    }


    public void LoadData()
    {
        level = PlayerPrefs.GetInt("level", level);
        exp = PlayerPrefs.GetFloat("exp", exp);
    }
}
