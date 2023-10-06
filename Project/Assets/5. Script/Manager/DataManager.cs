using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    /*

저장해야될것들
1. 플레이어 - 아이디, 레벨, 경험치, hp, mp, 커스터마이징
2. 아이템 - 무기, 골드, 물약 등

*/
    GameData WeaponData;
    GameData ShiledData;
    int level;
    float exp;

    public int LEVEL
    {
        get { return level; }
        set { level = value; }
    }

    public float EXP
    {
        get { return exp; }
        set { exp = value; }
    }

    public GameData WEAPONDATA
    {
        get { return WeaponData; }
        set { WeaponData = value; }
    }

    public GameData SHILEDDATA
    {
        get { return ShiledData; }
        set { ShiledData = value; }
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
