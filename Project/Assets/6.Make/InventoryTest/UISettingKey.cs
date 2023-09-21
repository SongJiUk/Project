using System;
using FreeNet;
using Rito.InventorySystem;
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
        Inventory.gameObject.SetActive(false);
        Debug.Log("00000000");
    }

    public void Equipmentend()
    {
        Equipment.gameObject.SetActive(false);
    }

    public void Skillend()
    {
        Skill.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.gameObject.SetActive(!Inventory.gameObject.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Equipment.gameObject.SetActive(!Equipment.gameObject.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Skill.gameObject.SetActive(!Skill.gameObject.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {

        }


    }
}
