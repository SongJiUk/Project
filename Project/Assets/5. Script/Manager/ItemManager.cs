using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{

    [SerializeField] List<WeaponItemData> WeaponLists = new List<WeaponItemData>();

    Dictionary<string, WeaponItemData> WeaponData = new Dictionary<string, WeaponItemData>();


    private void Awake()
    {
        for (int i = 0; i < WeaponLists.Count; i++)
        {
            if (WeaponLists[i] != null)
            {
                WeaponData.Add(WeaponLists[i].Name, WeaponLists[i]);
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


    //UI로 장착해주면
    public void equip()
    {
        
        //WeaponManager.GetInstance.ChangeWeapon();
    }
    public void DefaultWeapon()
    {

    }
}
