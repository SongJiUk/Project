using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerPickupOrUse : MonoBehaviour
{
    public bool Around = false;

    [SerializeField] Collider _collider;

    [SerializeField] PlayerAround _playeraround;

    [SerializeField] PickUpUI _pickUpUI;

    List<GameObject> AroundItemList = new List<GameObject>();

    [SerializeField] Inventory _inventory;

    int numList = 0;

    void Awake()
    {
        if(_playeraround != null) _playeraround.SettingStart(this);
        if(_pickUpUI!= null) _pickUpUI.SettingStart(this);
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
            _pickUpUI.RemoveList(item);
            AroundItemList.Remove(item);
        }
        if (AroundItemList.Count == numList)
        {
            PickUpNow(numList);
        }

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

    private void PickUpNow(int num)
    {
        for (int i = 0; i < AroundItemList.Count; i++)
        {
            if (num == i)
            {
                _pickUpUI.PickUpNow(i);
            }
            else
            {
                _pickUpUI.PickUpNotNow(i);
            }
        }
    }
    private void PickUpNum()
    {
        if (Around)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
               
            }
            else
            {
                float wheelInput = Input.GetAxis("Mouse ScrollWheel");
                numList -= (int)(wheelInput * 10);
            }
        }
        numList = Mathf.Clamp(numList, 0, AroundItemList.Count - 1);
    }
    
    private void Update()
    {
        CheckAround();

        if (Around)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (true)
                {
                    numList = Mathf.Clamp(numList, 0, AroundItemList.Count - 1);
                    Debug.Log(numList);
                    GameObject item = AroundItemList[numList];
                    ItemData a = item.GetComponent<ItemDataPickup>().PickUp();
                    _inventory.Add(a);
                    RemoveList(item);
                    Destroy(item);
                }
            }
            PickUpNum();
            PickUpNow(numList);
        }
        else
        {
            numList = 0;
        }
    }


}
