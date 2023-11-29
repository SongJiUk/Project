using System;
using FreeNet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISettingKey : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject Equipment;
    [SerializeField] private GameObject Skill;
    
    [SerializeField] private Button InventoryButton;
    [SerializeField] private Button EquipmentButton;
    [SerializeField] private Button SkillButton;

    // Start is called before the first frame update
    void Start()
    {
        InitButtonEvents();
    }

    private void InitButtonEvents()
    {
        InventoryButton.onClick.AddListener(() => Inventoryend());
        EquipmentButton.onClick.AddListener(() => Equipmentend());
        SkillButton.onClick.AddListener(() => Skillend());
    }

    public void Inventoryend()
    {
        UIManager.GetInstance.UISound("UI_ONOFF");
        Inventory.gameObject.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;
    }

    public void Equipmentend()
    {
        UIManager.GetInstance.UISound("UI_ONOFF");
        Equipment.gameObject.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;
    }

    public void Skillend()
    {
        UIManager.GetInstance.UISound("UI_ONOFF");
        Skill.gameObject.SetActive(false);
        CameraManager.GetInstance.ISUIOFF = true;
        UIManager.GetInstance.isOnPopupCount--;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.gameObject.SetActive(!Inventory.gameObject.activeSelf);
            UIManager.GetInstance.UISound("UI_ONOFF");
            if (Inventory.gameObject.activeSelf)
            {
                CameraManager.GetInstance.ISUIOFF = false;
                UIManager.GetInstance.isOnPopupCount++;
            }
            else
            {
                CameraManager.GetInstance.ISUIOFF = true;
                UIManager.GetInstance.isOnPopupCount--;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Equipment.gameObject.SetActive(!Equipment.gameObject.activeSelf);
            UIManager.GetInstance.UISound("UI_ONOFF");
            if (Equipment.gameObject.activeSelf)
            {
                CameraManager.GetInstance.ISUIOFF = false;
                UIManager.GetInstance.isOnPopupCount++;

            }
            else
            {
                CameraManager.GetInstance.ISUIOFF = true;
                UIManager.GetInstance.isOnPopupCount--;
            }
        }
        
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    Skill.gameObject.SetActive(!Skill.gameObject.activeSelf);

        //    if (Skill.gameObject.activeSelf)
        //    {
        //        CameraManager.GetInstance.ISUIOFF = false;
        //        UIManager.GetInstance.isOnPopupCount++;

        //    }
        //    else
        //    {
        //        CameraManager.GetInstance.ISUIOFF = true;
        //        UIManager.GetInstance.isOnPopupCount--;
        //    }
        //}

        


        /*
        if (Input.GetKeyDown(KeyCode.O))
        {

        }
        */

    }
}
