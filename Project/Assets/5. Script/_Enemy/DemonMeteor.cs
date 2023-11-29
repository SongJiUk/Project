using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMeteor : MonoBehaviour
{
    [SerializeField]
    GameObject magicCircleObj;
    [SerializeField]
    GameObject MeteorObj;

    void Start()
    {
        Invoke("Meteor", 5f);
        Invoke("MeteorDemege", 5.6f);
        Invoke("DestroyMeteor", 7f);
    }

    void Meteor()
    {
        magicCircleObj.SetActive(false);
        MeteorObj.SetActive(true);
    }

    void MeteorDemege()
    {
        MeteorObj.transform.GetComponent<SphereCollider>().enabled = true;
    }

    void DestroyMeteor()
    {
        Destroy(gameObject);
    }
}
