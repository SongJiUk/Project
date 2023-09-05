using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreath : MonoBehaviour
{
    [SerializeField]
    GameObject attackEffectPrefab;
    [SerializeField]
    Transform EffectPosition;

    ParticleSystem particle;
    private void Start()
    {
        GameObject obj = Instantiate(attackEffectPrefab);
        obj.transform.SetParent(EffectPosition);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        particle = obj.GetComponent<ParticleSystem>();
    }
    public void DragonAttack()
    {
        particle.Play();
    }
}
