using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{


    public Customizing customizing;
    public WeaponManager weaponManger;
    public bool isNoEquip = false;
    void Start()
    {
        if (customizing == null) customizing = Player.GetInstance.GetComponent<Customizing>();
        if (null == weaponManger) weaponManger = Player.GetInstance.GetComponent<WeaponManager>();
    }
}
