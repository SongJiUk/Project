using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDataPickup : MonoBehaviour
{
    [SerializeField] ItemData _itemdata; // 아이템 데이터

    [SerializeField] bool isOrb = false;

    int ItemCode = 0;

    float rotationSpeed = 100f;

    private void Awake()
    {
        ItemCode = _itemdata.ItemCode;
    }

    void Update()
    {
        if (isOrb)
            if (WeaponManager.GetInstance.ISEQUIP)
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }



    public ItemData PickUp()
    {
        return _itemdata;
    }

    public void Drop()
    {

    }
}
