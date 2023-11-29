using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DicKey
{
    public string key;
    public AudioClip audio;
}

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioClip StartBGM;
    [SerializeField] AudioClip TownBGM;
    [SerializeField] AudioClip DungeonBGM;
    [SerializeField] AudioClip BossRoomBGM;

    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource Monster;
    [SerializeField] AudioSource UI;


    public List<DicKey> sfxList = new List<DicKey>();
    public List<DicKey> UIList = new List<DicKey>();
    public List<DicKey> MonsterList = new List<DicKey>();

    private void Awake()
    {
        PlayBgm(0);
    }

    public void PlayBgm(int _num)
    {
        switch(_num)
        {
            case 0:
                bgm.clip = StartBGM;
                break;

            case 1:
                bgm.clip = TownBGM;
                break;

            case 2:
                bgm.clip = DungeonBGM;
                break;

            case 3:
                bgm.clip = BossRoomBGM;
                break;

        }

        bgm.Play();
    }

    public void StopBgm()
    {
        bgm.Stop();
    }

    public void PlaySound_PlayerAttack(string _key)
    {
        for(int i = 0; i< sfxList.Count; i++)
        {
            if(sfxList[i].key == _key)
            {
                sfx.clip = sfxList[i].audio;
                sfx.Play();
                break;
            }
        }
    }

    public void PlayerSound(string _key)
    {
        for (int i = 0; i < sfxList.Count; i++)
        {
            if (sfxList[i].key == _key)
            {
                sfx.clip = sfxList[i].audio;
                sfx.Play();
                break;
            }
        }
    }

    public void UISound(string _key)
    {
        for (int i = 0; i < UIList.Count; i++)
        {
            if (UIList[i].key == _key)
            {
                UI.clip = UIList[i].audio;
                UI.Play();
                break;
            }
        }
    }

    public void MonsterSound(string _key)
    {
        for (int i = 0; i < MonsterList.Count; i++)
        {
            if (MonsterList[i].key == _key)
            {
                Monster.clip = MonsterList[i].audio;
                Monster.Play();
                break;
            }
        }
    }

}
