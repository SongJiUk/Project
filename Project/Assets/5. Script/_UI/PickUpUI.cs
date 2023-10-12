using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


        _pickUpUIList.Add(item);
        var slotRT = CloneList();
        slotRT.pivot = new Vector2(0f, 1f); // Left Top
        slotRT.gameObject.SetActive(true);
        int idx = _pickUpUIList.FindIndex(a=>(item));
        slotRT.gameObject.name = $"Item Slot [{idx}]";


    }

    public void RemoveList(GameObject item)
    {
        
        int idx = _pickUpUIList.FindIndex(a => (item));
        Destroy(_contentAreaRT.FindChild(item.name));
        _pickUpUIList.Remove(item);

    }

    // Update is called once per frame
    void UpdateList()
    {
        
    }

    RectTransform CloneList()
    {
        GameObject slotGo = Instantiate(_pickUpUIPrefab);
        RectTransform rt = slotGo.GetComponent<RectTransform>();
        rt.SetParent(_contentAreaRT);
        slotGo.SetActive(true);

        return rt;
    }
}
