using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwonMap_DungeonMove : MonoBehaviour
{
    [SerializeField] BoxCollider collider;
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PopupManager.GetInstance.TownMap_MoveDungeon_Popup.SetActive(true);
            CameraManager.GetInstance.ISUIOFF = false;
            UIManager.GetInstance.isOnPopupCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PopupManager.GetInstance.TownMap_MoveDungeon_Popup.SetActive(false);
            CameraManager.GetInstance.ISUIOFF = true;
            UIManager.GetInstance.isOnPopupCount--;
        }
    }
}
