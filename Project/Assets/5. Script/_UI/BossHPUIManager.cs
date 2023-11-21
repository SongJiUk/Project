using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHPUIManager : MonoBehaviour
{
    [SerializeField] Text BossName;
    [SerializeField] GameObject BossHPUI;
    [SerializeField] BossHPBar BossHPBar;

    public static BossHPUIManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AwakeBoss(string name,int HPMax)
    {
        BossHPUI.SetActive(true);
        BossName.text = name;
        BossHPBar.SetMaxHP(HPMax);
    }



    public void DeadBoss()
    {
        BossHPUI.SetActive(false);
    }

    BossHPBar ReturnBossHPBar() 
    {
        return BossHPBar;
    } 
}
