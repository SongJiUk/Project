using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    #region 현재 캐릭터에 장착되어있는 무기들
    [SerializeField] List<Weapon> WeaponList = new List<Weapon>();
    [SerializeField] List<Weapon> BackWeaponList = new List<Weapon>();
    [SerializeField] List<Weapon> ShiledList = new List<Weapon>();
    [SerializeField] List<Weapon> BackShiledList = new List<Weapon>();
    [SerializeField] List<Weapon> BackOrbList = new List<Weapon>();
    #endregion

    #region 플레이어 장비 장착 및 해제
    bool isEquip = false;
    bool isChangeWeapon = false;
    public bool ISEQUIP { get { return isEquip; } set { isEquip = value; } }

    [SerializeField] GameObject EquipWeapon_back;
    [SerializeField] GameObject EquipWeapon_hand;
    [SerializeField] GameObject EquipShiled_back;
    [SerializeField] GameObject EquipShiled_hand;
    [SerializeField] GameObject EquipOrb_back;

    public GameObject EW_Back { get { return EquipWeapon_back; } private set { } }
    public GameObject EW_Hand { get { return EquipWeapon_hand; } private set { } }
    public GameObject ES_back { get { return EquipShiled_back; } private set { } }
    public GameObject ES_hand { get { return EquipShiled_hand; } private set { } }
    #endregion


    #region 현재 끼고있는 장비 정보

    public Weapon weapon;
    public WeaponItemData Weapondata;
    public WeaponItemData ShiledData;
    GameObject handWeapon;
    GameObject backWeapon;
    GameObject handShiled;
    GameObject backShiled;
    GameObject backOrb;
    #endregion

    #region 끼고있던 장비 정보
    public WeaponItemData B_Weapondata;
    public WeaponItemData B_ShiledData;
    GameObject B_handWeapon;
    GameObject B_handShiled;

    bool isUIUnEquip = false;
    #endregion
    bool isEquipShiled = false;
    bool isOrb = false;
    private void Start()
    {
        if (EquipWeapon_hand != null)
        {

            weapon = EquipWeapon_hand.GetComponent<Weapon>();
        }
    }

    public int FindIndex(int _num)
    {
        for (int i = 0; i < WeaponList.Count; i++)
        {
            if(WeaponList[i].DATA.ItemCode == _num)
            {
                return WeaponList[i].DATA._EquipmentNum;
            }
        }
        return 0;
    }

    public WeaponItemData FindIndexs(int _num)
    {
        for (int i = 0; i < WeaponList.Count; i++)
        {
            if (WeaponList[i].DATA.ItemCode == _num)
            {
                return WeaponList[i].DATA;
            }
        }
        return null;
    }

    public void InitEquipMentWeapon(int _num)
    {
        if (DataManager.GetInstance.ISEQUIPWEAPON(_num))
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
                if (WeaponList[i].DATA.ItemCode ==
                    DataManager.GetInstance.WEAPONCODE(_num))
                {
                    WeaponList[i].gameObject.SetActive(true);
                }
            }

            for (int i = 0; i < ShiledList.Count; i++)
            {
                if (ShiledList[i].DATA.ItemCode ==
                    DataManager.GetInstance.WEAPONCODE(_num))
                {
                    ShiledList[i].gameObject.SetActive(true);
                }
            }
        }
        else
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
               
                    WeaponList[i].gameObject.SetActive(false);
                
            }

            for (int i = 0; i < ShiledList.Count; i++)
            {
              
                    ShiledList[i].gameObject.SetActive(false);
                
            }
        }
    }

    //public void ChangeWeapon(WeaponItemData _weaponData, WeaponItemData _shiledData = null)
    //{

    //}

    public void ChangeWeapon(WeaponItemData _weaponData = null, WeaponItemData _shiledData = null)
    {
        /*
        
        1. 무기 정보를 받아옴
        2. 일단 끼고있는 무기 비활성화
        3. 받아와서 넣어준다.
        4.  무기가 껴져있으면 무기가 껴져있는 상태에서 바꿔준다
                Equip -> UnEquip -> Equip
            무기가 등 뒤에있으면 등 뒤에 있는 상태에서 바꿔준다.
                UnEquip -> Equip
        5.

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           ChangeWeapon(ItemManager.GetInstance.GetWeaponData("Dagger_1"));
            무기의 정보를 건내줌
            Player.GetInstance.ANIM.SetInteger("EquipNum", 1);
            모두 바뀌면 EquipNum를 1로 바꿔준다.
        }
         */


        // 전에 끼던 무기 정보 저장

        if(_weaponData != null)
        {
            if (handWeapon != null)
            {
                B_handWeapon = handWeapon;
                B_Weapondata = Weapondata;
                B_handWeapon.SetActive(false);
            }
            if (handShiled != null)
            {
                B_handShiled = handShiled;
                B_ShiledData = ShiledData;
                B_handShiled.SetActive(false);
            }
            // 교체할 무기 저장
            Weapondata = _weaponData;
            ShiledData = _shiledData;


            handWeapon = null;
            if (backWeapon != null) backWeapon.SetActive(false);
            if (backShiled != null) backShiled.SetActive(false);
            backWeapon = null;

            //웨폰 리스트에서 맞는 정보를 가져와서 저장해줌

            for (int i = 0; i < WeaponList.Count; i++)
            {
                if (Weapondata.ItemCode == WeaponList[i].DATA.ItemCode)
                    handWeapon = WeaponList[i].gameObject;
            }

            for (int i = 0; i < BackWeaponList.Count; i++)
            {
                if (Weapondata.ItemCode == BackWeaponList[i].DATA.ItemCode) backWeapon = BackWeaponList[i].gameObject;
            }
            


            if (handWeapon != null) EquipWeapon_hand = handWeapon;
            if (backWeapon != null) EquipWeapon_back = backWeapon;


            DataManager.GetInstance.ISEQUIPWEAPON(DataManager.GetInstance.SLOT_NUM, true);


            if (Player.GetInstance.playerStat.UnitCodes == UnitCode.WARRIOR)
            {
                WarriorEquipmentChange();
            }
            else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.MAGE)
            {
                MageEquipmentChange();
            }
            else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.ARCHER)
            {
                ArcherEquipmentChange();
            }



            if (isEquip)
            {
                isEquip = !isEquip;
                isChangeWeapon = true;
                Player.GetInstance.ANIM.SetBool("IsEquip", isEquip);
                Player.GetInstance.ANIM.SetInteger("EquipNum", Weapondata._EquipmentNum);

            }
            else
            {
                isEquip = !isEquip;
                Player.GetInstance.ANIM.SetBool("IsEquip", isEquip);
                Player.GetInstance.ANIM.SetInteger("EquipNum", 0);
            }


            if (B_Weapondata != null)
                if (B_Weapondata._EquipmentNum == Weapondata._EquipmentNum)
                {
                    //EquipWeapon_hand.SetActive(true);
                    Player.GetInstance.ANIM.SetInteger("EquipNum", Weapondata._EquipmentNum);
                }
                else Player.GetInstance.ANIM.SetInteger("EquipNum", Weapondata._EquipmentNum);
            else Player.GetInstance.ANIM.SetInteger("EquipNum", Weapondata._EquipmentNum);



            if (B_ShiledData != null && ShiledData != null)
                if (B_ShiledData._EquipmentNum == ShiledData._EquipmentNum)
                    EquipShiled_hand.SetActive(true);
                else EquipShiled_hand.SetActive(true);
        }
        else
        {
            isUIUnEquip = true;
            DataManager.GetInstance.ISEQUIPWEAPON(DataManager.GetInstance.SLOT_NUM, false);
            Player.GetInstance.ANIM.SetBool("IsEquip", false);
            Player.GetInstance.ANIM.SetInteger("EquipNum", 0);
            EquipWeapon_hand.SetActive(false);
            EquipWeapon_back.SetActive(false);
            handWeapon = null;
            backWeapon = null;
            isEquip = false;
        }
        

    }

    public void WarriorEquipmentChange()
    {
        if (ShiledData != null)
        {
            isEquipShiled = true;

            for (int i = 0; i < ShiledList.Count; i++)
            {
                if (ShiledData.ItemCode == ShiledList[i].DATA.ItemCode) handShiled = ShiledList[i].gameObject;
                if (ShiledData.ItemCode == BackShiledList[i].DATA.ItemCode) backShiled = BackShiledList[i].gameObject;
            }

            EquipShiled_hand = handShiled;
            EquipShiled_back = backShiled;

        }
        else isEquipShiled = false;
    }

    public void MageEquipmentChange()
    {
        if (Weapondata.Type == Types.Orb)
        {
            for (int i = 0; i < BackOrbList.Count; i++)
            {
                if (Weapondata.ItemCode == BackOrbList[i].DATA.ItemCode) backOrb = BackOrbList[i].gameObject;
            }

            EquipOrb_back = backOrb;
            isOrb = true;
        }
        else isOrb = false;
    }

    public void ArcherEquipmentChange()
    {

    }

    #region 애니메이션에서 실행
    public void Equip()
    {
        if(EquipWeapon_back != null) EquipWeapon_back.SetActive(!isEquip);
        
            
        if(EquipWeapon_hand != null) EquipWeapon_hand.SetActive(isEquip);

        if(isEquipShiled)
        {
            EquipShiled_back.SetActive(!isEquip);
            EquipShiled_hand.SetActive(isEquip);
        }

        if(isOrb) EquipOrb_back.SetActive(!isEquip);
    }


    public void UnEquip()
    {
        if (Player.GetInstance.playerStat.UnitCodes == UnitCode.WARRIOR)
        {
            if (EquipWeapon_back != null)
            {
                if (isUIUnEquip) EquipWeapon_back.SetActive(false);
                else EquipWeapon_back.SetActive(!isEquip);
            }
            
            if (EquipWeapon_hand != null) EquipWeapon_hand.SetActive(isEquip);

            if (B_handWeapon != null) B_handWeapon.SetActive(false);
            if (B_handShiled != null) B_handShiled.SetActive(false);

            if (isEquipShiled)
            {
                if(isUIUnEquip) EquipShiled_back.SetActive(false);
                else EquipShiled_back.SetActive(!isEquip);

                EquipShiled_hand.SetActive(isEquip);
            }
            else
            {
                if (EquipShiled_back != null) EquipShiled_back.SetActive(false);
                if (EquipShiled_hand != null) EquipShiled_hand.SetActive(false);
            }
        }
        else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.MAGE)
        {
            if (EquipWeapon_hand != null) EquipWeapon_hand.SetActive(isEquip);
            if (B_handWeapon != null) B_handWeapon.SetActive(false);
            if (B_handShiled != null) B_handShiled.SetActive(false);

            if (isOrb)
            {
                EquipOrb_back.SetActive(!isEquip);
            }
            else
            {
                if (EquipOrb_back != null) EquipOrb_back.SetActive(false);
                if (EquipWeapon_back != null) EquipWeapon_back.SetActive(!isEquip);
            }
        }
        else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.ARCHER)
        {
            if (EquipWeapon_back != null) EquipWeapon_back.SetActive(!isEquip);
            if (EquipWeapon_hand != null) EquipWeapon_hand.SetActive(isEquip);

            if (B_handWeapon != null) B_handWeapon.SetActive(false);
            if (B_handShiled != null) B_handShiled.SetActive(false);

        }

       

        if (isChangeWeapon)
        {
            isEquip = !isEquip;
            Player.GetInstance.ANIM.SetBool("IsEquip", isEquip);
            isChangeWeapon = false;
        }

        if(isUIUnEquip) isUIUnEquip = false;
    }
    #endregion




    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Player.GetInstance.playerStat.UnitCodes == UnitCode.WARRIOR)
            {
                ChangeWeapon(ItemManager.GetInstance.GetWeaponData("Dagger_1"));
            }
            else if(Player.GetInstance.playerStat.UnitCodes == UnitCode.MAGE)
            {
                ChangeWeapon(ItemManager.GetInstance.GetWeaponData("Staff_1"));
            }
            else if(Player.GetInstance.playerStat.UnitCodes == UnitCode.ARCHER)
            {
                ChangeWeapon(ItemManager.GetInstance.GetWeaponData("CrossBow_1"));
            }
           //
           //
           
            Player.GetInstance.ANIM.SetInteger("EquipNum", 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Player.GetInstance.playerStat.UnitCodes == UnitCode.WARRIOR)
            {
                ChangeWeapon(ItemManager.GetInstance.GetWeaponData("OneHandMace_1"),
                    ItemManager.GetInstance.GetWeaponData("Shiled_1"));
            }
            else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.MAGE)
            {
                ChangeWeapon(ItemManager.GetInstance.GetWeaponData("Orb_1"));
            }
            else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.ARCHER)
            {
                ChangeWeapon(ItemManager.GetInstance.GetWeaponData("Bow_1"));
            }
            //
            //
            
            Player.GetInstance.ANIM.SetInteger("EquipNum", 2);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Player.GetInstance.playerStat.UnitCodes == UnitCode.WARRIOR)
            {
                ChangeWeapon(ItemManager.GetInstance.GetWeaponData("TwoHandSword_1"));
                Player.GetInstance.ANIM.SetInteger("EquipNum", 3);

            }
            else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.MAGE)
            {

            }
            else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.ARCHER)
            {

            }
            

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Player.GetInstance.playerStat.UnitCodes == UnitCode.WARRIOR)
            {
                ChangeWeapon(ItemManager.GetInstance.GetWeaponData("Spear_1"));
                Player.GetInstance.ANIM.SetInteger("EquipNum", 4);
            }
            else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.MAGE)
            {

            }
            else if (Player.GetInstance.playerStat.UnitCodes == UnitCode.ARCHER)
            {
           

            }
            

        }
    }
}
