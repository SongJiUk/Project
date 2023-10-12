using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerPickupOrUse : MonoBehaviour
{
    public bool Around = false;

    [SerializeField] Collider _collider;

    [SerializeField] PlayerAround _playeraround;

    [SerializeField] PickUpUI _pickUpUI;

    List<GameObject> AroundItemList = new List<GameObject>();

    void Awake()
    {
        _playeraround.SettingStart(this);
        _pickUpUI.SettingStart(this);
    }

    public void AroundIn(GameObject item)
    {
        ItemData sc = item.GetComponent<ItemDataPickup>().PickUp();
        AddList(item);
        


    }

    public void AroundOut(GameObject item)
    {
        ItemData sc = item.GetComponent<ItemDataPickup>().PickUp();
        RemoveList(item);
    }

    private void AddList(GameObject item)
    {
        if (!AroundItemList.Contains(item))
        {
            AroundItemList.Add(item);
            _pickUpUI.AddList(item);
        }
    }

    private void RemoveList(GameObject item)
    {
        if (AroundItemList.Contains(item))
        {
            AroundItemList.Remove(item);
            _pickUpUI.RemoveList(item);
        }
    }

    

    private void CountAround()
    {

    }

    private void CheckAround() 
    {
        if (AroundItemList.Count==0)
        {
            Around = false;
        }
        else
        {
            Around = true;
        }
    }

    private void Update()
    {
        CheckAround();

        if (Around) 
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("sdf");
                
            }
        }
    }


}
