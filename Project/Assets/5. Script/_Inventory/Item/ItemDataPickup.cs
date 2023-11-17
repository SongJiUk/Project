using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDataPickup : MonoBehaviour
{
    

    [SerializeField] ItemData _itemdata; // ?????? ??????
    public ItemData ITEMDATA { get { return _itemdata; } set { _itemdata = value; } }

    [SerializeField] bool isOrb = false;

    [SerializeField] MeshRenderer _ratingColor;

    int ItemCode = 0;

    float rotationSpeed = 100f;

    private void Awake()
    {
        if (_itemdata != null)
        {
            if(_itemdata.ItemType != ItemType.Gold)
            {
                ItemCode = _itemdata.ItemCode;
                if (_itemdata.Rating == Ratings.Common)
                {
                    _ratingColor.material.color = Color.white;
                }
                else if (_itemdata.Rating == Ratings.Rare)
                {
                    _ratingColor.material.color = Color.gray;
                }
                else if (_itemdata.Rating == Ratings.Unique)
                {
                    _ratingColor.material.color = Color.blue;
                }
                else if (_itemdata.Rating == Ratings.Legendary)
                {
                    _ratingColor.material.color = Color.magenta;
                }
                else if (_itemdata.Rating == Ratings.Mythic)
                {
                    _ratingColor.material.color = Color.yellow;
                }
            }
            
        }
    }


    public void CreatePrefab()
    {
        if (_itemdata != null)
        {
            if (_itemdata.ItemType != ItemType.Gold)
            {
                ItemCode = _itemdata.ItemCode;
                if (_itemdata.Rating == Ratings.Common)
                {
                    _ratingColor.material.color = Color.white;
                }
                else if (_itemdata.Rating == Ratings.Rare)
                {
                    _ratingColor.material.color = Color.gray;
                }
                else if (_itemdata.Rating == Ratings.Unique)
                {
                    _ratingColor.material.color = Color.blue;
                }
                else if (_itemdata.Rating == Ratings.Legendary)
                {
                    _ratingColor.material.color = Color.magenta;
                }
                else if (_itemdata.Rating == Ratings.Mythic)
                {
                    _ratingColor.material.color = Color.yellow;
                }
            }

        }
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
