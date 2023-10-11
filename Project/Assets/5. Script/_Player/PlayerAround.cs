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

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {

    }
}
