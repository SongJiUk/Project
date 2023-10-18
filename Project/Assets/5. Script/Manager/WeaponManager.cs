using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    #region 현재 캐릭터에 장착되어있는 무기들
    [SerializeField] List<GameObject> WeaponList = new List<GameObject>();
    [SerializeField] List<GameObject> BackWeaponList = new List<GameObject>();
    [SerializeField] List<GameObject> ShiledList = new List<GameObject>();
    [SerializeField] List<GameObject> BackShiledList = new List<GameObject>();
    [SerializeField] List<GameObject> BackOrbList = new List<GameObject>();
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

   
    public void ChangeWeapon(WeaponItemData _weaponData, WeaponItemData _shiledData = null)
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
        if (handWeapon != null) B_handWeapon = handWeapon;
        if (handShiled != null) B_handShiled = handShiled;
        // 교체할 무기 저장
        Weapondata = _weaponData;
        ShiledData = _shiledData;


        handWeapon = null;
        backWeapon = null;

        //웨폰 리스트에서 맞는 정보를 가져와서 저장해줌
        for (int i = 0; i < WeaponList.Count; i++)
        {
            if (Weapondata.Name == WeaponList[i].name) handWeapon = WeaponList[i];
        }

        for( int i=0; i<BackWeaponList.Count; i++)
        {
            if (Weapondata.Name == BackWeaponList[i].name) backWeapon = BackWeaponList[i];
        }

        if(backWeapon != null) EquipWeapon_back = backWeapon;
        if(handWeapon != null) EquipWeapon_hand = handWeapon;


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

    }

    public void WarriorEquipmentChange()
    {
        if (ShiledData != null)
        {
            isEquipShiled = true;
            for (int i = 0; i < ShiledList.Count; i++)
            {
                if (ShiledData.Name == ShiledList[i].name) handShiled = ShiledList[i];
                if (ShiledData.Name == BackShiledList[i].name) backShiled = BackShiledList[i];
            }

            EquipShiled_back = handShiled;
            EquipShiled_hand = backShiled;

        }
        else isEquipShiled = false;
    }

    public void MageEquipmentChange()
    {
        if (Weapondata.Type == Types.Orb)
        {
            for (int i = 0; i < BackOrbList.Count; i++)
            {
                if (Weapondata.Name == BackOrbList[i].name) backOrb = BackOrbList[i];
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
            if (EquipWeapon_back != null) EquipWeapon_back.SetActive(!isEquip);
            if (EquipWeapon_hand != null) EquipWeapon_hand.SetActive(isEquip);

            if (B_handWeapon != null) B_handWeapon.SetActive(false);
            if (B_handShiled != null) B_handShiled.SetActive(false);

            if (isEquipShiled)
            {
                EquipShiled_back.SetActive(!isEquip);
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
