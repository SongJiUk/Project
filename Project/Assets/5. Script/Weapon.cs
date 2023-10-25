using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponItemData data;
    public WeaponItemData DATA { get { return data; } }
    bool isOrb = false;
    private void OnEnable()
    {
        if(data != null)
        {
            if (data.Type == Types.Orb) isOrb = true;
            else isOrb = false;
        }
        
    }

    float rotationSpeed = 100f;
    void Update()
    {
        if (isOrb)
            if (WeaponManager.GetInstance.ISEQUIP)
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

    }

    public WeaponItemData UseItemData()
    {
        return data;
    }
}
