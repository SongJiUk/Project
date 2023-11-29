using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Popup : MonoBehaviour
{


    public void LevelUP()
    {
        if( PlayerStat.GetInstance != null) PlayerStat.GetInstance.LevelUp();
    }

    public void GiveGold()
    {
        if (UIManager.GetInstance != null) UIManager.GetInstance.inventory.GetGold(1000);
    }

}
