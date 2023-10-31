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


    #region 슬롯 정보
    public static int SlotCount = 3;
    public static int InventorySlotNum = 64;
    Dictionary<int, UnitCode> SlotJob = new Dictionary<int, UnitCode>();
    int Slot_Num;
    public int SLOT_NUM
    {
        get => Slot_Num;
        set => Slot_Num = value;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    bool[] isSlotOpen = new bool[SlotCount];

    public bool GET_ISSLOTOPEN(int _slot)
    {
        return isSlotOpen[_slot];
    }
    public void SET_ISSLOTOPEN(int _slot, bool value)
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

    #endregion

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

    public int GET_GENDERNUM(int _slot)
    {
        return GenderNum[_slot];
    }
    public void SET_GENDERNUM(int _slot, int value)
    {
        GenderNum[_slot] = value;
    }

    public int GET_HAIRNUM(int _slot)
    {
        return HairNum[_slot];
    }

    public void SET_HAIRNUM(int _slot, int value)
    {
       HairNum[_slot] = value;
    }
    
    public int GET_FEMALE_FACENUM(int _slot)
    {
        return Female_FaceNum[_slot];
    }

    public void SET_FEMALE_FACENUM(int _slot, int value)
    {
        Female_FaceNum[_slot] = value;
    }


    public int GET_MALE_FACENUM(int _slot)
    {
        return male_FaceNum[_slot];
    }

    public void SET_MALE_FACENUM(int _slot, int value)
    {
        male_FaceNum[_slot] = value;
    }

    public int GET_FEMALE_EYEBROWNUM(int _slot)
    {
        return Female_EyebrowNum[_slot];
    }

    public void SET_FEMALE_EYEBROWNUM(int _slot, int value)
    {
        Female_EyebrowNum[_slot] = value;
    }

    public int GET_MALE_EYEBROWNUM(int _slot)
    {
        return male_EyebrowNum[_slot];
    }

    public void SET_MALE_EYEBROWNUM(int _slot, int value)
    {
        male_EyebrowNum[_slot] = value;
    }

    public int GET_MUSTACHENUM(int _slot)
    {
        return MustacheNum[_slot];
    }

    public void SET_MUSTACHENUM(int _slot, int value)
    {
        MustacheNum[_slot] = value;
    }

    public int GET_FEMALE_TOPNUM(int _slot)
    {
        return Female_TopNum[_slot];
    }

    public void SET_FEMALE_TOPNUM(int _slot, int value)
    {
        Female_TopNum[_slot] = value;
    }

    public int GET_FEMALE_PANTSNUM(int _slot)
    {
        return Female_PantsNum[_slot];
    }

    public void SET_FEMALE_PANTSNUM(int _slot, int value)
    {
        Female_PantsNum[_slot] = value;
    }

    public int GET_MALE_TOPNUM(int _slot)
    {
        return male_TopNum[_slot];
    }

    public void SET_MALE_TOPNUM(int _slot, int value)
    {
        male_TopNum[_slot] = value;
    }

    public int GET_MALE_PANTSNUM(int _slot)
    {
        return male_PantsNum[_slot];
    }

    public void SET_MALE_PANTSNUM(int _slot, int value)
    {
        male_PantsNum[_slot] = value;
    }

    #endregion

    #region 플레이어가 장착하고 있는 장비 및 인벤토리
    
    int[] HelmatCode = new int[SlotCount];
    int[] TopCode = new int[SlotCount];
    int[] PantsCode = new int[SlotCount];
    int[] HandCode = new int[SlotCount];
    int[] ShoesCode = new int[SlotCount];

    bool[] isEquipHelmat = new bool[SlotCount];
    bool[] isEquipTop = new bool[SlotCount];
    bool[] isEquipPants = new bool[SlotCount];
    bool[] isEquipHand = new bool[SlotCount];
    bool[] isEquipShoes = new bool[SlotCount];

    int[] WeaponCode = new int[SlotCount];
    bool[] isEquipWeapon = new bool[SlotCount];

    int[] InventorySlot = new int[InventorySlotNum];

    public void SET_INVENTORYSLOT(int _num, int _value)
    {
        InventorySlot[_num] = _value;
    }

    public int GET_GETINVENTORYSLOT(int _num)
    {
        return InventorySlot[_num];
    }

    public int GET_WEAPONCODE(int _slot)
    {
        return WeaponCode[_slot];
    }

    public void SET_WEAPONCODE(int _slot, int value)
    {
        WeaponCode[_slot] = value;
    }
    public bool GET_ISEQUIPWEAPON(int _slot)
    {
        return isEquipWeapon[_slot];
    }
    public void SET_ISEQUIPWEAPON(int _slot, bool value)
    {
        isEquipWeapon[_slot] = value;
    }


    public int GET_HELMATCODE(int _slot)
    {
        return HelmatCode[_slot];
    }

    public void SET_HELMATCODE(int _slot, int value)
    {
        HelmatCode[_slot] = value;
    }

    public int GET_TOPCODE(int _slot)
    {
        return TopCode[_slot];
    }

    public void SET_TOPCODE(int _slot, int value)
    {
        TopCode[_slot] = value;
    }

    public int GET_PANTSCODE(int _slot)
    {
        return PantsCode[_slot];
    }

    public void SET_PANTSCODE(int _slot, int value)
    {
        PantsCode[_slot] = value;
    }

    public int GET_HANDCODE(int _slot)
    {
        return HandCode[_slot];
    }

    public void SET_HANDCODE(int _slot, int value)
    {
        HandCode[_slot] = value;
    }

    public int GET_SHOESCODE(int _slot)
    {
        return ShoesCode[_slot];
    }

    public void SET_SHOESCODE(int _slot, int value)
    {
        ShoesCode[_slot] = value;
    }


    public bool GET_ISEQUIPHELMAT(int _slot)
    {
        return isEquipHelmat[_slot];
    }
    public void SET_ISEQUIPHELMAT(int _slot, bool value)
    {
        isEquipHelmat[_slot] = value;
    }

    public bool GET_ISEQUIPTOP(int _slot)
    {
        return isEquipTop[_slot];
    }
    public void SET_ISEQUIPTOP(int _slot, bool value)
    {
        isEquipTop[_slot] = value;
    }
    public bool GET_ISEQUIPPANTS(int _slot)
    {
        return isEquipPants[_slot];
    }
    public void SET_ISEQUIPPANTS(int _slot, bool value)
    {
        isEquipPants[_slot] = value;
    }
    public bool GET_ISEQUIPHAND(int _slot)
    {
        return isEquipHand[_slot];
    }

    public void SET_ISEQUIPHAND(int _slot, bool value)
    {
        isEquipHand[_slot] = value;
    }

    public bool GET_ISEQUIPSHOES(int _slot)
    {
        return isEquipShoes[_slot];
    }
    public void SET_ISEQUIPSHOES(int _slot, bool value)
    {
        isEquipShoes[_slot] = value;
    }
    #endregion



    #region 플레이어 관련
    string[] player_id = new string[SlotCount];
    int[] player_level = new int[SlotCount];
    float[] player_exp = new float[SlotCount];

    int[] player_job = new int[SlotCount];


    public UnitCode GET_UnitCodes(int _slot)
    {
        return SlotJob[_slot];
    }

    public void SET_UnitCodes(int _slot, UnitCode _vaule)
    {
        if (!SlotJob.ContainsKey(_slot))
        {
            SlotJob.Add(_slot, _vaule);
        }

    }

    public string GET_PLAYER_ID(int _slot)
    {
        return player_id[_slot];
    }

    public void SET_PLAYER_ID(int _slot, string value)
    {
        player_id[_slot] = value;
    }

    public int GET_PLAYER_LEVEL(int _slot)
    {
        return player_level[_slot];
    }

    public void SET_PLAYER_LEVEL(int _slot, int value)
    {
        player_level[_slot] = value;
    }

    public float GET_PLAYER_EXP(int _slot)
    {
        return player_exp[_slot];
    }

    public void SET_PLAYER_EXP(int _slot, float value)
    {
        player_exp[_slot] = value;
    }

    public int GET_PLAYER_JOB(int _slot)
    {
        return player_job[_slot];
    }

    public void SET_PLAYER_JOB(int _slot, int value)
    {
        player_job[_slot] = value;
    }
    #endregion

    #region 로딩창 관련 데이터
    string[] loading_text = new string[SlotCount];

    public string GET_LOADING_TEXT(int _slot)
    {
        return loading_text[_slot];
    }

    public void SET_LOADING_TEXT(int _slot, string value)
    {
        loading_text[_slot] = value;
    }
    #endregion


    #region 퀘스트 관련
    #endregion

    public void SaveData(int _index)
    {
        
        isSlotOpen[_index] = true;
        SetBool("isSlotOpen" + _index, isSlotOpen[_index]);

        PlayerPrefs.SetInt("SlotJob"+_index, (int)SlotJob[_index]);

        for (int num = 0; num < InventorySlotNum; num++)
        {
            PlayerPrefs.SetInt($"InventorySlot{_index}" + num, InventorySlot[num]);
        }

        PlayerPrefs.SetFloat("player_exp" + _index, player_exp[_index]);
        PlayerPrefs.SetInt("player_level" + _index, player_level[_index]);
        PlayerPrefs.SetString("player_id" + _index, player_id[_index]);
        PlayerPrefs.SetInt("player_job" + _index, player_job[_index]);

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

        PlayerPrefs.SetInt("WeaponCode" + _index, WeaponCode[_index]);
        PlayerPrefs.SetInt("HelmatCode" + _index, HelmatCode[_index]);
        PlayerPrefs.SetInt("TopCode" + _index, TopCode[_index]);
        PlayerPrefs.SetInt("PantsCode" + _index, PantsCode[_index]);
        PlayerPrefs.SetInt("HandCode" + _index, HandCode[_index]);
        PlayerPrefs.SetInt("ShoesCode" + _index, HandCode[_index]);

        SetBool("isEquipWeapon" + _index, isEquipWeapon[_index]);
        SetBool("isEquipHelmat" + _index, isEquipHelmat[_index]);
        SetBool("isEquipTop" + _index, isEquipTop[_index]);
        SetBool("isEquipPants" + _index, isEquipPants[_index]);
        SetBool("isEquipHand" + _index, isEquipHand[_index]);
        SetBool("isEquipShoes" + _index, isEquipShoes[_index]);
       
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
                SlotJob[i] = (UnitCode)PlayerPrefs.GetInt("SlotJob" + i);
               
                for (int num = 0; num < InventorySlotNum; num++)
                {
                    InventorySlot[num] = PlayerPrefs.GetInt($"InventorySlot{i}" + num);
                }

                player_level[i] = PlayerPrefs.GetInt("player_level" + i);
                player_exp[i] = PlayerPrefs.GetFloat("player_exp" + i);
                player_id[i] = PlayerPrefs.GetString("player_id" + i);
                player_job[i] = PlayerPrefs.GetInt("player_job" + i);

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

                WeaponCode[i] = PlayerPrefs.GetInt("WeaponCode" + i);
                HelmatCode[i] = PlayerPrefs.GetInt("HelmatCode" + i);
                TopCode[i] = PlayerPrefs.GetInt("TopCode" + i);
                PantsCode[i] = PlayerPrefs.GetInt("PantsCode" + i);
                HandCode[i] = PlayerPrefs.GetInt("HandCode" + i);
                HandCode[i] = PlayerPrefs.GetInt("HandCode" + i);

                string isEquipWeaponKey = "isEquipWeapon" + i;
                if (PlayerPrefs.HasKey(isEquipWeaponKey)) isEquipWeapon[i] = GetBool(isEquipWeaponKey).HasValue;

                string isEquipHelmatKey = "isEquipHelmat" + i;
                if (PlayerPrefs.HasKey(isEquipHelmatKey)) isEquipHelmat[i] = GetBool(isEquipHelmatKey).HasValue;

                string isEquipTopKey = "isEquipTop" + i;
                if (PlayerPrefs.HasKey(isEquipTopKey)) isEquipTop[i] = GetBool(isEquipTopKey).HasValue;

                string isEquipPantsKey = "isEquipPants" + i;
                if (PlayerPrefs.HasKey(isEquipPantsKey)) isEquipPants[i] = GetBool(isEquipPantsKey).HasValue;

                string isEquipHandKey = "isEquipHand" + i;
                if (PlayerPrefs.HasKey(isEquipHandKey)) isEquipHand[i] = GetBool(isEquipHandKey).HasValue;

                string isEquipShoesKey = "isEquipShoes" + i;
                if (PlayerPrefs.HasKey(isEquipShoesKey)) isEquipShoes[i] = GetBool(isEquipShoesKey).HasValue;

            }

        }
        
    }
}
