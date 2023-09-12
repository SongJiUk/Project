using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonLazerCollider : MonoBehaviour
{
    BoxCollider box;
    bool boxOn = true;
    ParticleSystem lazerParticel;
    void Start()
    {
        box = GetComponent<BoxCollider>();
        lazerParticel = GetComponent<ParticleSystem>();
        box.enabled = false;
    }

    void Update()
    {
        if (lazerParticel.isPlaying)
        {
            if (boxOn)
            {
                Invoke("boxColliderOn", 0.3f);
                boxOn = false;
            }
        }
        else
        {
            boxOn = true;
        }
    }

    void boxColliderOn()
    {
        box.enabled = true;
        Invoke("boxColliderDown", 0.7f);
    }

    void boxColliderDown()
    {
        box.enabled = false;
    }
}
