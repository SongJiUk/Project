using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAround : MonoBehaviour
{
    private PlayerPickupOrUse _playerpickuporuse;

    public void SettingStart(PlayerPickupOrUse PlayerPickupOrUse)
    {
        _playerpickuporuse = PlayerPickupOrUse;
    }

    private void OnTriggerEnter(Collider target)
    {
        ItemDataPickup sc;
        if (target.GetComponent<ItemDataPickup>() != null)
        {
            sc = target.GetComponent<ItemDataPickup>();

            GameObject targetObject = target.gameObject;

            _playerpickuporuse.AroundIn(targetObject);
        }

    }

    private void OnTriggerStay(Collider target)
    {

    }

    private void OnTriggerExit(Collider target)
    {
        ItemDataPickup sc;
        if (target.GetComponent<ItemDataPickup>() != null)
        {
            sc = target.GetComponent<ItemDataPickup>();

            GameObject targetObject = target.gameObject;

            _playerpickuporuse.AroundOut(targetObject);
        }
    }
}
