using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreath : MonoBehaviour
{
    [SerializeField]
    GameObject attackEffectPrefab;
    [SerializeField]
    Transform EffectPosition;
    public void DragonAttack()
    {
        Instantiate(attackEffectPrefab, EffectPosition.position, Quaternion.Euler( new Vector3 (EffectPosition.rotation.x, EffectPosition.rotation.y, EffectPosition.rotation.z))).transform.parent = EffectPosition;
    }
}
