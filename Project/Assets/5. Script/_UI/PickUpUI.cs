using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickUpUI : MonoBehaviour
{
    [SerializeField] private GameObject _pickUpUIPrefab;

    [SerializeField] private RectTransform _contentAreaRT;

    private List<GameObject> _pickUpUIList = new List<GameObject>();

    private PlayerPickupOrUse _playerpickuporuse;

    public void SettingStart(PlayerPickupOrUse PlayerPickupOrUse)
    {
        _playerpickuporuse = PlayerPickupOrUse;
    }

    public void AddList(GameObject item)
    {

        GameObject slotGo = Instantiate(_pickUpUIPrefab);
        Sprite _iconImage = item.GetComponent<ItemDataPickup>().PickUp().IconSprite;
        string _text = item.GetComponent<ItemDataPickup>().PickUp().Name;

        slotGo.GetComponent<PickUpUIPrefab>().SetIconImage(_iconImage);
        slotGo.GetComponent<PickUpUIPrefab>().SetText(_text);
        slotGo.GetComponent<PickUpUIPrefab>().SetObj(item);


        _pickUpUIList.Add(slotGo);
        RectTransform rt = slotGo.GetComponent<RectTransform>();
        rt.SetParent(_contentAreaRT);
        slotGo.SetActive(true);


        var slotRT = rt;
        slotRT.pivot = new Vector2(0f, 1f); // Left Top
        slotRT.gameObject.SetActive(true);
        int idx = _pickUpUIList.FindIndex(a=>(item));
        slotRT.gameObject.name = $"Item Slot [{idx}]";

    }

    public void RemoveList(GameObject item)
    {
        for(int i=0; i< _pickUpUIList.Count; i++)
        {
            if(_pickUpUIList[i].GetComponent<PickUpUIPrefab>().FindObj(item)!=null)
            {
                Destroy(_pickUpUIList[i]);
                _pickUpUIList.RemoveAt(i);
            }
        }
    }

    public void PickUpItem(int num)
    {
        Destroy(_pickUpUIList[num]);
        _pickUpUIList.RemoveAt(num);

    }



    // Update is called once per frame  
    void UpdateList()
    {
        
    }

}
