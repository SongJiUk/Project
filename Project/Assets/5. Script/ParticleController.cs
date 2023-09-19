using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    ParticleSystem ParticleSystem;

    private void Awake()
    {
        if (null == ParticleSystem) ParticleSystem = this.GetComponent<ParticleSystem>();
        ParticleSystem.Stop();
    }

    private void OnEnable()
    {
        
    }

    public void PlayEffect()
    {
        ParticleSystem.Play();
    }
}
