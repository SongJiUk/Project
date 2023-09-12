using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    public GameObject inventory;
    public GameObject weapon;
    public GameObject toparmor;
    public GameObject bottomarmor;
    public GameObject shoesarmor;
    public GameObject uesitemslot;


    List<DroppableUI> listinventory = new List<DroppableUI>();
    List<DroppableUI> listequip = new List<DroppableUI>();
    List<DroppableUI> listuesitem = new List<DroppableUI>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventory.transform.childCount; ++i)
        {
            listinventory.Add(inventory.transform.GetChild(i).GetComponent<DroppableUI>());
            listinventory[i].GetComponent<DroppableUI>().setting(0, i);
        }
        for (int i = 0; i < uesitemslot.transform.childCount; ++i)
        {
            Debug.Log("dsgdsgsdg");
            listuesitem.Add(uesitemslot.transform.GetChild(i).GetComponent<DroppableUI>());
            listuesitem[i].GetComponent<DroppableUI>().setting(2, i);
        }
        listequip.Add(weapon.GetComponent<DroppableUI>());
        listequip.Add(toparmor.GetComponent<DroppableUI>());
        listequip.Add(bottomarmor.GetComponent<DroppableUI>());
        listequip.Add(shoesarmor.GetComponent<DroppableUI>());
        for (int i = 0; i < 4; ++i)
        {
            listuesitem[i].GetComponent<DroppableUI>().setting(1, i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
