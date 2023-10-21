using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentItemData : MonoBehaviour
{
    [SerializeField] private Types _type;

    [SerializeField] private ClassPrivateItems _classPrivateItems;

    [SerializeField] private int _num;

    public Types ReturnType()
    {
        return _type;
    }

    public ClassPrivateItems ReturnClassPrivateItems()
    {
        return _classPrivateItems;
    }

    public int ReturnNum()
    {
        return _num;
    }

    public void dfdfdf()
    {
        
    }
}
