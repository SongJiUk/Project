using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    #region 현재 캐릭터에 장착되어있는 무기들
    [SerializeField] List<GameObject> WeaponList = new List<GameObject>();
    #endregion

    #region 플레이어 장비 장착 및 해제
    bool isEquip = false;
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

    public GameData Weapondata;
    public GameData ShiledData;
    #endregion

    private void Start()
    {
        
    }

    public void ChangeWeapon(GameData _weaponData, GameData _shiledData = null)
    {
        /*
         무기가 껴져있으면 무기가 껴져있는 상태에서 바꿔준다
         무기가 등 뒤에있으면 등 뒤에 있는 상태에서 바꿔준다.

         */
        Weapondata = _weaponData;
        Debug.Log(Weapondata.equipmentName);

        //for (int i=0; i<WeaponList.Count; i++)
        //{
           

        //}

        //if(Weapondata.equipmentNum == 2)
        //{
        //    EquipWeapon_back.SetActive(false);
        //    EquipWeapon_hand.SetActive(false);
        //}
        //else
        //{
        //    EquipShiled_back.SetActive(true);
        //    EquipShiled_hand.SetActive(true);
        //}

    }

    #region 애니메이션에서 실행 
    public void UnEquip()
    {
        EquipWeapon_back.SetActive(isEquip);
        EquipWeapon_hand.SetActive(!isEquip);
    }

    public void Equip()
    {
        EquipWeapon_back.SetActive(isEquip);
        EquipWeapon_hand.SetActive(!isEquip);
    }
    #endregion
    private void Update()
    {
        
        //이렇게 바꾸면 될
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //ChangeWeapon();
            //EquipWeapon_back = WeaponList[0];
            //EquipWeapon_hand = WeaponList[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            EquipWeapon_back = WeaponList[1];
            EquipWeapon_hand = WeaponList[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            EquipWeapon_back = WeaponList[2];
            EquipWeapon_hand = WeaponList[2];
        }
    }
}
