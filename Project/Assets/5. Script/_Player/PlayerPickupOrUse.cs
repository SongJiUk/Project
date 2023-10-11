using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupOrUse : MonoBehaviour
{
    public bool Around = false;

    [SerializeField] Collider _collider;

    [SerializeField] PlayerAround _playeraround;

    void Awake()
    {
        _playeraround.SettingStart(this);
    }

    public void AroundIn()
    {

    }

    public void AroundOut()
    {

    }

    private void CountAround()
    {

    }

    private void Update()
    {
        if (Around) 
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
            }
        }
    }


}
