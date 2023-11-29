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

    public AudioSource sfx;
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
        if(sfx != null) sfx.Play();

        Debug.Log(this.name);

        if (other.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<Enemy>().SkillHit();
        }

        if (other.layer == LayerMask.NameToLayer("Boss"))
        {
            other.GetComponent<DemonBoss>().SkillHit();
        }



        if (isDestory)
        {
            Destroy(this);
        }


    }
}