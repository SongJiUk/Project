using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{

    [SerializeField]
    List<ItemData> itemList;

    public static ItemDataManager current;
    void Awake()
    {
        if(current == null)
            current = this;
    }

    public ItemData GetItemData(int index)
    {
        return itemList[index];
    }


}
