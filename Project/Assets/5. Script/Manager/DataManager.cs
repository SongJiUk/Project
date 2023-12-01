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
    #region 캐릭터 정보
    public static int MaxLevel = 20;
    public static float LevelUpEXP = 50f;
    #endregion

    #region 슬롯 정보
    public static int SlotCount = 3;
    public static int InventorySlotNum = 64;
    public static int EquipmentSlotNum = 6;
    Dictionary<int, UnitCode> SlotJob = new Dictionary<int, UnitCode>();
    int Slot_Num;
    public int SLOT_NUM
    {
        get => Slot_Num;
        set => Slot_Num = value;
    }

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
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
    int[] WeaponCode = new int[SlotCount];

    bool[] isEquipHelmat = new bool[SlotCount];
    bool[] isEquipTop = new bool[SlotCount];
    bool[] isEquipPants = new bool[SlotCount];
    bool[] isEquipHand = new bool[SlotCount];
    bool[] isEquipShoes = new bool[SlotCount];
    bool[] isEquipWeapon = new bool[SlotCount];


    int[] WeaponEquipSlot = new int[SlotCount];
    int[] TopEquipSlot = new int[SlotCount];
    int[] PantsEquipSlot = new int[SlotCount];
    int[] HeadEquipSlot = new int[SlotCount];
    int[] HandEquipSlot = new int[SlotCount];
    int[] ShoesEquipSlot = new int[SlotCount];


    int[] player_Gold = new int[SlotCount];
   
    public int GET_PLAYER_GOLD(int _slot)
    {
        return player_Gold[_slot];
    }

    public void SET_PLAYER_GOLD(int _slot, int _value)
    {
        player_Gold[_slot] = _value;
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


    public int GET_WEAPONEQUIPSLOT(int _slot)
    {
        return WeaponEquipSlot[_slot];
    }

    public void SET_WEAPONEQUIPSLOT(int _slot, int value)
    {
        WeaponEquipSlot[_slot] = value;
    }

    public int GET_TOPEQUIPSLOT(int _slot)
    {
        return TopEquipSlot[_slot];
    }

    public void SET_TOPEQUIPSLOT(int _slot, int value)
    {
        TopEquipSlot[_slot] = value;
    }

    public int GET_PANTSEQUIPSLOT(int _slot)
    {
        return PantsEquipSlot[_slot];
    }

    public void SET_PANTSEQUIPSLOT(int _slot, int value)
    {
        PantsEquipSlot[_slot] = value;
    }

    public int GET_HEADEQUIPSLOT(int _slot)
    {
        return HeadEquipSlot[_slot];
    }

    public void SET_HEADEQUIPSLOT(int _slot, int value)
    {
        HeadEquipSlot[_slot] = value;
    }

    public int GET_HANDEQUIPSLOT(int _slot)
    {
        return HandEquipSlot[_slot];
    }

    public void SET_HANDEQUIPSLOT(int _slot, int value)
    {
        HandEquipSlot[_slot] = value;
    }

    public int GET_SHOESEQUIPSLOT(int _slot)
    {
        return ShoesEquipSlot[_slot];
    }

    public void SET_SHOESEQUIPSLOT(int _slot, int value)
    {
        ShoesEquipSlot[_slot] = value;
    }



    int[] InventorySlot_1 = new int[InventorySlotNum];
    int[] InventorySlot_2 = new int[InventorySlotNum];
    int[] InventorySlot_3 = new int[InventorySlotNum];
    int[] InventoryCount_1 = new int[InventorySlotNum];
    int[] InventoryCount_2 = new int[InventorySlotNum];
    int[] InventoryCount_3 = new int[InventorySlotNum];

    public void SET_INVENTORYSLOT(int _num, int _value, int count = 1)
    {
        switch(Slot_Num)
        {
            case 0:
                InventorySlot_1[_num] = _value;
                InventoryCount_1[_num] = count;
                break;

            case 1:
                InventorySlot_2[_num] = _value;
                InventoryCount_2[_num] = count;
                break;

            case 2:
                InventorySlot_3[_num] = _value;
                InventoryCount_3[_num] = count;
                break;

        }
       
    }

    public int GET_INVENTORYSLOT(int _num)
    {
        switch(Slot_Num)
        {
            case 0:
                return InventorySlot_1[_num];

            case 1:
                return InventorySlot_2[_num];

            case 2:
                return InventorySlot_3[_num];
        }

        return 0;
        
    }

    public int GET_INVENTORYSLOTCOUNT(int _num)
    {
        switch (Slot_Num)
        {
            case 0:
                return InventoryCount_1[_num];

            case 1:
                return InventoryCount_2[_num];

            case 2:
                return InventoryCount_3[_num];
        }

        return 0;
    }

    

    #endregion



    #region 플레이어 관련
    string[] player_id = new string[SlotCount];
    int[] player_level = new int[SlotCount];
    float[] player_exp = new float[SlotCount];
    int[] player_job = new int[SlotCount];

    float[] player_damage = new float[SlotCount];
    float[] player_speed = new float[SlotCount];
    float[] player_defence = new float[SlotCount];
    float[] player_avoidance = new float[SlotCount];
    float[] player_criticalchance = new float[SlotCount];

    int[] player_MaxHp = new int[SlotCount];
    int[] player_MaxMp = new int[SlotCount];
    float[] player_NowHp = new float[SlotCount];
    float[] player_NowMp = new float[SlotCount];

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

        if(SlotJob[_slot] == UnitCode.None)
        {
            SlotJob.Remove(_slot);
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


    public float GET_PLAYER_DAMAGE(int _slot)
    {
        return player_damage[_slot];
    }

    public void SET_PALYER_DAMAGE(int _slot, float _value)
    {
        player_damage[_slot] = _value;
    }

    public float GET_PLAYER_SPEED(int _slot)
    {
        return player_speed[_slot];
    }

    public void SET_PALYER_SPEED(int _slot, float _value)
    {
        player_speed[_slot] = _value;
    }

    public float GET_PLAYER_DEFENCE(int _slot)
    {
        return player_defence[_slot];
    }

    public void SET_PALYER_DEFENCE(int _slot, float _value)
    {
        player_defence[_slot] = _value;
    }

    public int GET_PLAYER_MAXHP(int _slot)
    {
        return player_MaxHp[_slot];
    }

    public void SET_PALYER_MAXHP(int _slot, int _value)
    {
        player_MaxHp[_slot] = _value;
    }

    public int GET_PLAYER_MAXMP(int _slot)
    {
        return player_MaxMp[_slot];
    }

    public void SET_PALYER_MAXMP(int _slot, int _value)
    {
        player_MaxMp[_slot] = _value;
    }

    public float GET_PLAYER_NOWHP(int _slot)
    {
        return player_NowHp[_slot];
    }

    public void SET_PALYER_NOWHP(int _slot, float _value)
    {
        player_NowHp[_slot] = _value;
    }

    public float GET_PLAYER_NOWMP(int _slot)
    {
        return player_NowMp[_slot];
    }

    public void SET_PALYER_NOWMP(int _slot, float _value)
    {
        player_NowMp[_slot] = _value;
    }

    public float GET_PLAYER_AVOIDANCE(int _slot)
    {
        return player_avoidance[_slot];
    }

    public void SET_PALYER_AVOIDANCE(int _slot, float _value)
    {
        player_avoidance[_slot] = _value;
    }
    public float GET_PLAYER_CRITICALCHANCE(int _slot)
    {
        return player_criticalchance[_slot];
    }

    public void SET_PALYER_CRITICALCHANCE(int _slot, float _value)
    {
        player_criticalchance[_slot] = _value;
    }

    #endregion

    #region 로딩창 관련 데이터

    #endregion


    #region 퀘스트 관련
    int[] quest_id = new int[SlotCount];

    public int GET_QUEST_ID(int _slot)
    {
        return quest_id[_slot];
    }

    public void SET_QUEST_ID(int _slot, int _value)
    {
        quest_id[_slot] = _value;
    }
    #endregion

    bool[] isCreate = new bool[SlotCount];

    public bool GET_ISCREATE(int _slot)
    {
        return isCreate[_slot];
    }

    public void SET_ISCREATE(int _slot, bool _value)
    {
        isCreate[_slot] = _value;
    }

    public void SaveData(int _slot)
    {
        isSlotOpen[_slot] = true;
        SetBool("isSlotOpen" + _slot, isSlotOpen[_slot]);
        SetBool("isCreate" + _slot, isCreate[_slot]);


        PlayerPrefs.SetInt("SlotJob" + _slot, (int)SlotJob[_slot]);

        switch(Slot_Num)
        {
            case 0:
                for (int num = 0; num < InventorySlotNum; num++)
                {
                    PlayerPrefs.SetInt($"InventorySlot{_slot}" + num, InventorySlot_1[num]);
                }

                for (int num = 0; num < InventorySlotNum; num++)
                {
                    PlayerPrefs.SetInt($"InventoryCount{_slot}" + num, InventoryCount_1[num]);
                }
                break;

            case 1:
                for (int num = 0; num < InventorySlotNum; num++)
                {
                    PlayerPrefs.SetInt($"InventorySlot{_slot}" + num, InventorySlot_2[num]);
                }

                for (int num = 0; num < InventorySlotNum; num++)
                {
                    PlayerPrefs.SetInt($"InventoryCount{_slot}" + num, InventoryCount_2[num]);
                }
                break;

            case 2:
                for (int num = 0; num < InventorySlotNum; num++)
                {
                    PlayerPrefs.SetInt($"InventorySlot{_slot}" + num, InventorySlot_3[num]);
                }

                for (int num = 0; num < InventorySlotNum; num++)
                {
                    PlayerPrefs.SetInt($"InventoryCount{_slot}" + num, InventoryCount_3[num]);
                }
                break;

        }
        

        PlayerPrefs.SetFloat("player_exp" + _slot, player_exp[_slot]);
        PlayerPrefs.SetInt("player_level" + _slot, player_level[_slot]);
        PlayerPrefs.SetString("player_id" + _slot, player_id[_slot]);
        PlayerPrefs.SetInt("player_job" + _slot, player_job[_slot]);


        PlayerPrefs.SetFloat("player_damage" + _slot, player_damage[_slot]);
        PlayerPrefs.SetFloat("player_speed" + _slot, player_speed[_slot]);
        PlayerPrefs.SetFloat("player_defence" + _slot, player_defence[_slot]);
        PlayerPrefs.SetFloat("player_avoidance" + _slot, player_avoidance[_slot]);
        PlayerPrefs.SetFloat("player_criticalchance" + _slot, player_criticalchance[_slot]);
        PlayerPrefs.SetInt("player_MaxHp" + _slot, player_MaxHp[_slot]);
        PlayerPrefs.SetInt("player_MaxMp" + _slot, player_MaxMp[_slot]);
        PlayerPrefs.SetFloat("player_NowHp" + _slot, player_NowHp[_slot]);
        PlayerPrefs.SetFloat("player_NowMp" + _slot, player_NowMp[_slot]);
        PlayerPrefs.SetInt("player_Gold" + _slot, player_Gold[_slot]);


        PlayerPrefs.SetInt("GenderNum" + _slot, GenderNum[_slot]);
        PlayerPrefs.SetInt("Female_FaceNum" + _slot, Female_FaceNum[_slot]);
        PlayerPrefs.SetInt("male_FaceNum" + _slot, male_FaceNum[_slot]);
        PlayerPrefs.SetInt("Female_EyebrowNum" + _slot, Female_EyebrowNum[_slot]);
        PlayerPrefs.SetInt("male_EyebrowNum" + _slot, male_EyebrowNum[_slot]);
        PlayerPrefs.SetInt("MustacheNum" + _slot, MustacheNum[_slot]);
        PlayerPrefs.SetInt("Female_TopNum" + _slot, Female_TopNum[_slot]);
        PlayerPrefs.SetInt("male_TopNum" + _slot, male_TopNum[_slot]);
        PlayerPrefs.SetInt("Female_PantsNum" + _slot, Female_PantsNum[_slot]);
        PlayerPrefs.SetInt("male_PantsNum" + _slot, male_PantsNum[_slot]);

        PlayerPrefs.SetInt("WeaponCode" + _slot, WeaponCode[_slot]);
        PlayerPrefs.SetInt("HelmatCode" + _slot, HelmatCode[_slot]);
        PlayerPrefs.SetInt("TopCode" + _slot, TopCode[_slot]);
        PlayerPrefs.SetInt("PantsCode" + _slot, PantsCode[_slot]);
        PlayerPrefs.SetInt("HandCode" + _slot, HandCode[_slot]);
        PlayerPrefs.SetInt("ShoesCode" + _slot, ShoesCode[_slot]);

        SetBool("isEquipWeapon" + _slot, isEquipWeapon[_slot]);
        SetBool("isEquipHelmat" + _slot, isEquipHelmat[_slot]);
        SetBool("isEquipTop" + _slot, isEquipTop[_slot]);
        SetBool("isEquipPants" + _slot, isEquipPants[_slot]);
        SetBool("isEquipHand" + _slot, isEquipHand[_slot]);
        SetBool("isEquipShoes" + _slot, isEquipShoes[_slot]);


        PlayerPrefs.SetInt("quest_id" + _slot, quest_id[_slot]);

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

            string isCreateKey = "isCreate" + i;
            if (PlayerPrefs.HasKey(isCreateKey)) isCreate[i] = GetBool(isCreateKey).HasValue;
            else isCreate[i] = false;

            if (isSlotOpen[i])
            {
                SlotJob[i] = (UnitCode)PlayerPrefs.GetInt("SlotJob" + i);

                switch(i)
                {
                    case 0:
                        for (int num = 0; num < InventorySlotNum; num++)
                        {
                            InventorySlot_1[num] = PlayerPrefs.GetInt($"InventorySlot{i}" + num);
                        }

                        for (int num = 0; num < InventorySlotNum; num++)
                        {
                            InventoryCount_1[num] = PlayerPrefs.GetInt($"InventoryCount{i}" + num);
                        }
                        break;

                    case 1:
                        for (int num = 0; num < InventorySlotNum; num++)
                        {
                            InventorySlot_2[num] = PlayerPrefs.GetInt($"InventorySlot{i}" + num);
                        }

                        for (int num = 0; num < InventorySlotNum; num++)
                        {
                            InventoryCount_2[num] = PlayerPrefs.GetInt($"InventoryCount{i}" + num);
                        }
                        break;

                    case 2:
                        for (int num = 0; num < InventorySlotNum; num++)
                        {
                            InventorySlot_3[num] = PlayerPrefs.GetInt($"InventorySlot{i}" + num);
                        }

                        for (int num = 0; num < InventorySlotNum; num++)
                        {
                            InventoryCount_3[num] = PlayerPrefs.GetInt($"InventoryCount{i}" + num);
                        }
                        break;

                }
                

                player_level[i] = PlayerPrefs.GetInt("player_level" + i);
                player_exp[i] = PlayerPrefs.GetFloat("player_exp" + i);
                player_id[i] = PlayerPrefs.GetString("player_id" + i);
                player_job[i] = PlayerPrefs.GetInt("player_job" + i);

                player_damage[i] = PlayerPrefs.GetFloat("player_damage" + i);
                player_speed[i] = PlayerPrefs.GetFloat("player_speed" + i);
                player_defence[i] = PlayerPrefs.GetFloat("player_defence" + i);
                player_avoidance[i] = PlayerPrefs.GetFloat("player_avoidance" + i);
                player_criticalchance[i] = PlayerPrefs.GetFloat("player_criticalchance" + i);
                player_MaxHp[i] = PlayerPrefs.GetInt("player_MaxHp" + i);
                player_MaxMp[i] = PlayerPrefs.GetInt("player_MaxMp" + i);
                player_NowHp[i] = PlayerPrefs.GetFloat("player_NowHp" + i);
                player_NowMp[i] = PlayerPrefs.GetFloat("player_NowMp" + i);
                player_Gold[i] = PlayerPrefs.GetInt("player_Gold" + i);


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
                ShoesCode[i] = PlayerPrefs.GetInt("ShoesCode" + i);

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


                quest_id[i] = PlayerPrefs.GetInt("quest_id" + i);
            }

        }
        
    }

    public void DeleteData(int _slot)
    { 
        isCreate[_slot] = false;
        SetBool("isCreate" + _slot, isCreate[_slot]);


        SlotJob[_slot] = UnitCode.None;
        PlayerPrefs.SetInt("SlotJob" + _slot, (int)SlotJob[_slot]);

        for (int num = 0; num < InventorySlotNum; num++)
        {
            PlayerPrefs.SetInt($"InventorySlot{_slot}" + num, 0);
            PlayerPrefs.SetInt($"InventoryCount{_slot}" + num, 0);
        }

        PlayerPrefs.SetFloat("player_exp" + _slot, 0);
        PlayerPrefs.SetInt("player_level" + _slot, 0);
        PlayerPrefs.SetString("player_id" + _slot, "");
        PlayerPrefs.SetInt("player_job" + _slot, 0);

        PlayerPrefs.SetFloat("player_damage" + _slot, 0);
        PlayerPrefs.SetFloat("player_speed" + _slot, 0);
        PlayerPrefs.SetFloat("player_defence" + _slot, 0);
        PlayerPrefs.SetFloat("player_avoidance" + _slot, 0);
        PlayerPrefs.SetFloat("player_criticalchance" + _slot, 0);
        PlayerPrefs.SetInt("player_MaxHp" + _slot, 0);
        PlayerPrefs.SetInt("player_MaxMp" + _slot, 0);
        PlayerPrefs.SetFloat("player_NowHp" + _slot, 0);
        PlayerPrefs.SetFloat("player_NowMp" + _slot, 0);
        PlayerPrefs.SetInt("player_Gold" + _slot, 0);


        PlayerPrefs.SetInt("GenderNum" + _slot, 0);
        PlayerPrefs.SetInt("Female_FaceNum" + _slot, 0);
        PlayerPrefs.SetInt("male_FaceNum" + _slot, 0);
        PlayerPrefs.SetInt("Female_EyebrowNum" + _slot, 0);
        PlayerPrefs.SetInt("male_EyebrowNum" + _slot, 0);
        PlayerPrefs.SetInt("MustacheNum" + _slot, 0);
        PlayerPrefs.SetInt("Female_TopNum" + _slot, 0);
        PlayerPrefs.SetInt("male_TopNum" + _slot, 0);
        PlayerPrefs.SetInt("Female_PantsNum" + _slot, 0);
        PlayerPrefs.SetInt("male_PantsNum" + _slot, 0);

        PlayerPrefs.SetInt("WeaponCode" + _slot, 0);
        PlayerPrefs.SetInt("HelmatCode" + _slot, 0);
        PlayerPrefs.SetInt("TopCode" + _slot, 0);
        PlayerPrefs.SetInt("PantsCode" + _slot, 0);
        PlayerPrefs.SetInt("HandCode" + _slot, 0);
        PlayerPrefs.SetInt("ShoesCode" + _slot, 0);

        SetBool("isEquipWeapon" + _slot, false);
        SetBool("isEquipHelmat" + _slot, false);
        SetBool("isEquipTop" + _slot, false);
        SetBool("isEquipPants" + _slot, false);
        SetBool("isEquipHand" + _slot, false);
        SetBool("isEquipShoes" + _slot, false);

        PlayerPrefs.SetInt("quest_id" + _slot, 0);
        //int equipindex = 0;

        //PlayerPrefs.SetInt("Equip_" + equipindex +"_"+ _index, male_PantsNum);


        

        LoadData();
        isSlotOpen[_slot] = false;
        SetBool("isSlotOpen" + _slot, isSlotOpen[_slot]);

        PlayerPrefs.Save();
    }
}
