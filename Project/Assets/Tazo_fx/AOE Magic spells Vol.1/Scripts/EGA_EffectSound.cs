using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGA_EffectSound : MonoBehaviour
{
    public bool Repeating = true;
    public float RepeatTime = 2.0f;
    public float StartTime = 0.0f;
    public bool RandomVolume;
    public float minVolume = .4f;
    public float maxVolume = 1f;
    private AudioClip clip;
    public bool isStart = false;
    private AudioSource soundComponent;

    [SerializeField] List<GameObject> effect = new List<GameObject>();

    void Start ()
    {
        soundComponent = GetComponent<AudioSource>();
        clip = soundComponent.clip;
        if (RandomVolume == true)
        {
            soundComponent.volume = Random.Range(minVolume, maxVolume);
            RepeatSound();
        }
        if (Repeating == true)
        {
            InvokeRepeating("RepeatSound", StartTime, RepeatTime);
        }
    }

    void RepeatSound()
    {
        soundComponent.PlayOneShot(clip);
    }

    void RepeatEffect()
    {
        for(int i=0; i< effect.Count; i++)
        {
            if (effect[i] != null) effect[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (isStart == true)
        {
            isStart = false;
            RepeatSound();
            RepeatEffect();
        }
    }
}
