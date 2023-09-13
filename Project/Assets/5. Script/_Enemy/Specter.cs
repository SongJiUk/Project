using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specter : MonoBehaviour
{
    [SerializeField]
    Material DefultMaterial;
    [SerializeField]
    Material StealthMaterial;
    [SerializeField]
    GameObject Sword;
    [SerializeField]
    GameObject Body;
    SkinnedMeshRenderer bodyRd;
    SkinnedMeshRenderer swordRd;

    [SerializeField]
    GameObject StelthParticlePrefab;
    ParticleSystem StelthParticle;

    [SerializeField]
    Transform StelthPosi;
    void Start()
    {
        bodyRd = Body.GetComponent<SkinnedMeshRenderer>();
        swordRd = Sword.GetComponent<SkinnedMeshRenderer>();
        bodyRd.material = StealthMaterial;
        swordRd.material = StealthMaterial;
        GameObject obj = Instantiate(StelthParticlePrefab);
        obj.transform.SetParent(StelthPosi);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        StelthParticle = obj.GetComponent<ParticleSystem>();
    }

    public void StealthRelease()
    {
        StelthParticle.Play();
        bodyRd.material = DefultMaterial;
        swordRd.material = DefultMaterial;
    }

    public void Stealth()
    {
        StelthParticle.Play();
        bodyRd.material = StealthMaterial;
        swordRd.material = StealthMaterial;
    }
}
