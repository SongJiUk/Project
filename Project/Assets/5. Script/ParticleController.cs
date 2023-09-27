using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    ParticleSystem ParticleSystem;
    public float DAMAGE;
    public bool CheckScriptLoad;
    public bool isDestory;
    public bool isHit = false;
    private void Awake()
    {
        if(!CheckScriptLoad)
        {
            if (null == ParticleSystem) ParticleSystem = this.GetComponent<ParticleSystem>();
            ParticleSystem.Stop();
        }
        
    }

    private void OnEnable()
    {

    }

    public void PlayEffect()
    {
        ParticleSystem.Play();
    }

    void OnParticleCollision(GameObject other)
    {

        Debug.Log("아야아");

        if (other.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<Enemy>().SkillHit();
        }
        
        

        if(isDestory)
        {
            Destroy(this);
        }


    }
}