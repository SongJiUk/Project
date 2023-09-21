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

    #endregion

    #region 플레이어 장비 장착 및 해제
    bool isEquip = false;
    bool isChangeWeapon = false;
    public bool ISEQUIP { get { return isEquip; } set { isEquip = value; } }

    [SerializeField] GameObject EquipWeapon_back;
    [SerializeField] GameObject EquipWeapon_hand;
    [SerializeField] GameObject EquipShiled_back;
    [SerializeField] GameObject EquipShiled_hand;

    public GameObject EW_Back { get { return EquipWeapon_back; } private set { } }
    public GameObject EW_Hand { get { return EquipWeapon_hand; } private set { } }
    public GameObject ES_back { get { return EquipShiled_back; } private set { } }
    public GameObject ES_hand { get { return EquipShiled_hand; } private set { } }
    #endregion


    #region 현재 끼고있는 장비 정보

    public Weapon weapon;
    public GameData Weapondata;
    public GameData ShiledData;
    GameObject handWeapon;
    GameObject backWeapon;
    GameObject handShiled;
    GameObject backShiled;
    #endregion

    #region 끼고있던 장비 정보
    public GameData B_Weapondata;
    public GameData B_ShiledData;
    GameObject B_handWeapon;
    GameObject B_handShiled;

    #endregion

    private void Start()
    {
        if (EquipWeapon_hand != null)
        {

            weapon = EquipWeapon_hand.GetComponent<Weapon>();
        }
    }

    bool isEquipShiled = false;
    public void ChangeWeapon(GameData _weaponData, GameData _shiledData = null)
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
        

        //웨폰 리스트에서 맞는 정보를 가져와서 저장해줌
        for (int i = 0; i < WeaponList.Count; i++)
        {
            if (Weapondata.equipmentName == WeaponList[i].name) handWeapon = WeaponList[i];
            if (Weapondata.equipmentName == BackWeaponList[i].name) backWeapon = BackWeaponList[i];
        }

        EquipWeapon_back = backWeapon;
        EquipWeapon_hand = handWeapon;

        if (_shiledData != null)
        {
            isEquipShiled = true;
            for (int i = 0; i < ShiledList.Count; i++)
            {
                if (ShiledData.equipmentName == ShiledList[i].name) handShiled = ShiledList[i];
                if (ShiledData.equipmentName == BackShiledList[i].name) backShiled = BackShiledList[i];
            }

            EquipShiled_back = handShiled;
            EquipShiled_hand = backShiled;

        }
        else isEquipShiled = false;

        //if (EquipWeapon_hand != null) weapon = EquipWeapon_hand.GetComponent<Weapon>();

        if (isEquip)
        {
            isEquip = !isEquip;
            isChangeWeapon = true;
            Player.GetInstance.ANIM.SetBool("IsEquip", isEquip);
            Player.GetInstance.ANIM.SetInteger("EquipNum", Weapondata.equipmentNum);
            
        }
        else
        {
            isEquip = !isEquip;
            Player.GetInstance.ANIM.SetBool("IsEquip", isEquip);
        }

    }


    #region 애니메이션에서 실행
    public void Equip()
    {
        EquipWeapon_back.SetActive(!isEquip);
        EquipWeapon_hand.SetActive(isEquip);

        if(isEquipShiled)
        {
            EquipShiled_back.SetActive(!isEquip);
            EquipShiled_hand.SetActive(isEquip);
        }
        
    }


    public void UnEquip()
    {
        EquipWeapon_back.SetActive(!isEquip);
        EquipWeapon_hand.SetActive(isEquip);
        if(B_handWeapon != null) B_handWeapon.SetActive(false);
        if (B_handShiled != null) B_handShiled.SetActive(false);

        if(isEquipShiled)
        {
            EquipShiled_back.SetActive(!isEquip);
            EquipShiled_hand.SetActive(isEquip);
        }
        else
        {
            EquipShiled_back.SetActive(false);
            EquipShiled_hand.SetActive(false);
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
           ChangeWeapon(ItemManager.GetInstance.GetWeaponData("Dagger_1"));
            Player.GetInstance.ANIM.SetInteger("EquipNum", 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(ItemManager.GetInstance.GetWeaponData("OneHandMace_1"), ItemManager.GetInstance.GetWeaponData("Shiled_1"));
            Player.GetInstance.ANIM.SetInteger("EquipNum", 2);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(ItemManager.GetInstance.GetWeaponData("TwoHandSword_1"));
            Player.GetInstance.ANIM.SetInteger("EquipNum", 3);

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeWeapon(ItemManager.GetInstance.GetWeaponData("Spear_1"));
            Player.GetInstance.ANIM.SetInteger("EquipNum", 4);

        }
    }
}
