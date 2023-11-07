using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{

    [SerializeField] List<WeaponItemData> WeaponLists = new List<WeaponItemData>();

    Dictionary<string, WeaponItemData> WeaponData = new Dictionary<string, WeaponItemData>();

    [SerializeField] List<ArmorItemData> ArmorLists = new List<ArmorItemData>();
    Dictionary<string, ArmorItemData> ArmorData = new Dictionary<string, ArmorItemData>();

    [SerializeField] List<PortionItemData> PortionLists = new List<PortionItemData>();
    Dictionary<string, PortionItemData> PortionData = new Dictionary<string, PortionItemData>();


    public List<Item> items;

    private void Awake()
    {
        for (int i = 0; i < WeaponLists.Count; i++)
        {
            if (WeaponLists[i] != null)
            {
                WeaponData.Add(WeaponLists[i].ItemCodeName, WeaponLists[i]);
            }
        }

        for (int i = 0; i < ArmorLists.Count; i++)
        {
            if (ArmorLists[i] != null)
            {
                ArmorData.Add(ArmorLists[i].ItemCodeName, ArmorLists[i]);
            }
        }

        for (int i = 0; i < PortionLists.Count; i++)
        {
            if (PortionLists[i] != null)
            {
                PortionData.Add(PortionLists[i].ItemCodeName, PortionLists[i]);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //WeaponManager.GetInstance.ChangeWeapon(WeaponData["Hand"]);
    }

    public WeaponItemData GetWeaponData(string _name)
    {
        if(WeaponData.ContainsKey(_name))
        {
            return WeaponData[_name];
        }

        return null;
    }


    public ArmorItemData GetArmorData(string _name)
    {
        if (ArmorData.ContainsKey(_name))
        {
            return ArmorData[_name];
        }

        return null;
    }

    public PortionItemData GetPortionData(string _name)
    {
        if (PortionData.ContainsKey(_name))
        {
            return PortionData[_name];
        }
        return null;
    }

    public WeaponItemData GetWeaponItemData(int _value)
    {
        for(int i =0; i<WeaponLists.Count; i++)
        {
            if (WeaponLists[i].ItemCode == _value)
            {
                return WeaponLists[i];
            }
        }
        return null;
    }

    public ArmorItemData GetArmorItemData(int _value)
    {
        for (int i = 0; i < ArmorLists.Count; i++)
        {
            if (ArmorLists[i].ItemCode == _value)
            {
                return ArmorLists[i];
            }
        }
        return null;
    }

    public PortionItemData GetPortionItemData(int _value)
    {
        for (int i = 0; i < PortionLists.Count; i++)
        {
            if (PortionLists[i].ItemCode == _value)
            {
                return PortionLists[i];
            }
        }
        return null;
    }

    //public EquipmentItem GetEquipmentData(int _value)
    //{

    //}


    //UI로 장착해주면
    public void equip()
    {
        
        //WeaponManager.GetInstance.ChangeWeapon();
    }
    public void DefaultWeapon()
    {

    }
}
