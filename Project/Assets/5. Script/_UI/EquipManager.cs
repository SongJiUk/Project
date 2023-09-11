using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    public GameObject inventory;
    public Image weapon;
    public Image toparmor;
    public Image bottomarmor;
    public Image shoesarmor;
    public GameObject uesitemslot;


    List<DroppableUI> listinventory = new List<DroppableUI>();
    List<DroppableUI> listuesitem = new List<DroppableUI>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventory.transform.childCount; ++i)
        {
            listinventory.Add(inventory.transform.GetChild(i).GetComponent<DroppableUI>());
        }
        for (int i = 0; i < uesitemslot.transform.childCount; ++i)
        {
            listuesitem.Add(inventory.transform.GetChild(i).GetComponent<DroppableUI>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
