using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCharacter : MonoBehaviour
{
    [SerializeField] List<GameObject> HandWeapon;
    [SerializeField] List<GameObject> BackWeapon;

    [SerializeField] GameObject[] Archer_Bow_Skill;
    [SerializeField] GameObject[] Archer_Bow_Cast;
    [SerializeField] GameObject[] Archer_CrossBow_Skill;
    [SerializeField] GameObject[] Archer_CrossBow_Cast;

    Animator anim;
    int num;
    private void Start()
    {
        if (null == anim) anim = GetComponent<Animator>();
    }

    public void ShowPlay(int _num)
    {
        num = _num;
        anim.SetInteger("ClickNum", _num);
    }


    public void Equip()
    {
        
    }


    public void UnEquip()
    {
        anim.SetInteger("ClickNum", 0);
    }


    public void ArcherQSkill()
    {
        switch(num)
        {
            case 1:
                
                Archer_CrossBow_Cast[0].GetComponent<ParticleSystem>().Play();
                Archer_CrossBow_Cast[1].GetComponent<ParticleSystem>().Play();
                StartCoroutine(InstantSkill(1));
                break;

            case 2:
               
                StartCoroutine(InstantSkill(0));
                Archer_Bow_Cast[0].GetComponent<ParticleSystem>().Play();
                break;

        }
    }

    public void ArcherESkill()
    {
        switch (num)
        {
            case 1:
                //crossbow e
                StartCoroutine(CastSkill(EffectCastType.PreCast, 4));
                break;

            case 2:
                //bow e
                StartCoroutine(CastSkill(EffectCastType.Front, 1));
                
                break;

        }
    }

    public void ArcherRSkill()
    {
        switch (num)
        {
            case 1:
                //crossbow r
                StartCoroutine(CastSkill(EffectCastType.Front, 3));
                break;

            case 2:
                //bow r
                StartCoroutine(CastSkill(EffectCastType.PreCast, 3));
                
                break;

        }
    }

    public void WaitEndSkill()
    {

        Invoke("Waittime", 1f);
    }

    public void Waittime()
    {

    }
      
     

    IEnumerator InstantSkill(int _effectNum)
    {
        while (true)
        {
            if (_effectNum == 0)
            {

                yield return new WaitForSeconds(0.3f);
                Archer_Bow_Skill[_effectNum].GetComponent<ParticleSystem>().Play();
                yield return new WaitForSeconds(0.3f);
            }
            else if (_effectNum == 1)
            {

                //secondLayerWeight = Mathf.Lerp(secondLayerWeight, 1f, Time.deltaTime * 60);
                yield return new WaitForSeconds(1.2f);
                Archer_CrossBow_Skill[0].GetComponent<ParticleSystem>().Play();
                //if (Archer_CrossBow_Skill[0].GetComponent<AudioSource>())
                //{
                //    soundComponent = Prefabs[EffectNumber].GetComponent<AudioSource>();
                //    clip = soundComponent.clip;
                //    soundComponent.PlayOneShot(clip);
                //}
                //StartCoroutine(cameraShaker.Shake(0.3f, 8, 1.1f, 0.2f));
                yield return new WaitForSeconds(1.5f);
            }
            yield break;

        }
    }

    IEnumerator CastSkill(EffectCastType _markerNum = EffectCastType.None,
        int _effectNum = 999)
    {
 
        var forwardCamera = Vector3.zero;
        while (true)
        {
            yield return null;

            //if (rotateState == false)
            //{
            //    StartCoroutine(RotateToTarget(0.5f, vecPos));
            //}

            if (_markerNum == EffectCastType.Front)
            {
                if (_effectNum == 1)
                {
                    Archer_Bow_Cast[1].GetComponent<ParticleSystem>().Play();
                    //    //soundComponentCast = PrefabsCast[4].GetComponent<AudioSource>();
                    //    //clip = soundComponentCast.clip;
                    //    //soundComponentCast.PlayOneShot(clip);
                }
                else if (_effectNum == 2)
                {
                    Archer_Bow_Cast[2].GetComponent<ParticleSystem>().Play();
                }
                else if (_effectNum == 3)
                {

                    //if (Archer_CrossBow_Cast[4].GetComponent<AudioSource>())
                    //{
                    //    soundComponentCast = Archer_CrossBow_Cast[4].GetComponent<AudioSource>();
                    //    clip = soundComponentCast.clip;
                    //    soundComponentCast.PlayOneShot(clip);
                    //}
                    Archer_CrossBow_Cast[4].GetComponent<ParticleSystem>().Play();
                    yield return new WaitForSeconds(0.15f); //0.15s

                }

                if (_effectNum == 1) //위에가 Bow 밑이 CrossBow /
                {
                    Archer_Bow_Skill[1].transform.rotation = Quaternion.LookRotation(forwardCamera);
                    var effect = Archer_Bow_Skill[1].GetComponent<ParticleSystem>();
                    effect.Play();
                    //StartCoroutine(cameraShaker.Shake(0.5f, 7, 0.6f, 0.26f));
                    yield return new WaitForSeconds(1.3f);
                    Archer_Bow_Skill[1].transform.localPosition = new Vector3(0, 1, 0);
                    Archer_Bow_Skill[1].transform.localRotation = Quaternion.identity;

                }
                else if (_effectNum == 3)
                {
                    //StartCoroutine(cameraShaker.Shake(0.5f, 6, 1.3f, 0.0f));

                    foreach (var component in Archer_CrossBow_Skill[2].GetComponentsInChildren<FrontAttack>())
                    {
                        component.playMeshEffect = true;
                    }
                    yield return new WaitForSeconds(1f);
                    Archer_CrossBow_Skill[2].transform.localPosition = new Vector3(0, 0, 0);
                    Archer_CrossBow_Skill[2].transform.localRotation = Quaternion.identity;

                }
            }
            else if (_markerNum == EffectCastType.PreCast)
            {
                if (_effectNum == 3)
                {

                    //if (PrefabsCast[5].GetComponent<AudioSource>())
                    //{
                    //    soundComponentCast = PrefabsCast[5].GetComponent<AudioSource>();
                    //    clip = soundComponentCast.clip;
                    //    soundComponentCast.PlayOneShot(clip);
                    //}
                    //StartCoroutine(cameraShaker.Shake(0.4f, 9, 0.4f, 0.2f));
                    for (int i = 2; i <= 3; i++)
                    {
                        Archer_Bow_Cast[i].GetComponent<ParticleSystem>().Play();
                    }
                    yield return new WaitForSeconds(0.8f);
                    //StartCoroutine(cameraShaker.Shake(0.5f, 7, 1.4f, 0));

                    Archer_Bow_Skill[2].transform.position = transform.position;
                    Archer_Bow_Skill[2].transform.rotation = Quaternion.LookRotation(forwardCamera);
                    Archer_Bow_Skill[2].GetComponent<ParticleSystem>().Play();

                    //if (Archer_Bow_Cast[3].GetComponent<AudioSource>())
                    //{
                    //    soundComponent = Prefabs[3].GetComponent<AudioSource>();
                    //    clip = soundComponent.clip;
                    //    soundComponent.PlayOneShot(clip);
                    //}
                }
                else if (_effectNum == 4)
                {
                    //StartCoroutine(cameraShaker.Shake(0.4f, 8, 0.4f, 0.2f));
                    Archer_CrossBow_Cast[2].GetComponent<ParticleSystem>().Play();
                    //if (Archer_CrossBow_Cast[2].GetComponent<AudioSource>())
                    //{
                    //    soundComponentCast = Archer_CrossBow_Cast[2].GetComponent<AudioSource>();
                    //    clip = soundComponentCast.clip;
                    //    soundComponentCast.PlayOneShot(clip);
                    //}
                    Archer_CrossBow_Cast[3].GetComponent<ParticleSystem>().Play();
                    yield return new WaitForSeconds(0.8f);
                    //StartCoroutine(cameraShaker.Shake(0.3f, 7, 0.4f, 0));

                    Archer_CrossBow_Skill[1].transform.position = transform.position;
                    Archer_CrossBow_Skill[1].transform.rotation = Quaternion.LookRotation(forwardCamera);
                    Archer_CrossBow_Skill[1].transform.parent = null;
                    Archer_CrossBow_Skill[1].GetComponent<ParticleSystem>().Play();
                    //if (Archer_CrossBow_Skill[1].GetComponent<AudioSource>())
                    //{
                    //    soundComponent = Archer_CrossBow_Skill[1].GetComponent<AudioSource>();
                    //    clip = soundComponent.clip;
                    //    soundComponent.PlayOneShot(clip);
                    //}
                }

                if (_effectNum == 4)
                {
                    yield return new WaitForSeconds(2f);
                    Archer_CrossBow_Skill[1].transform.localPosition = new Vector3(0, 1, 0);
                    Archer_CrossBow_Skill[1].transform.localRotation = Quaternion.identity;
                }
            }


            yield break;

        }
    }
}
