using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{

    [SerializeField] Slider hpBar;
    [SerializeField] Slider hpBarfollow;
    int MaxHp = 0;
    float NowHp = 0;
    float value = 0;
    float followtimeMax = 2;
    float followtime = 0;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (followtime >= 0)
            followtime -= Time.deltaTime;
        else
        {
            SetHpBarFollow();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SetMaxHP(100);
        }
    }

    private void CheckHp()
    {
        if (NowHp <= 0 || MaxHp <= 0)
        {
            value = 0;
        }
        else
        {
            value = ((float)NowHp / (float)MaxHp);
        }
    }

    public void SetMaxHP(int _MaxHP) 
    {
        MaxHp = _MaxHP;
        NowHp = MaxHp;
        SetHpBar();
    }

    public void GetDamage(float nowHP, int damage, Transform _transformHit, bool _iscritical)
    {
        NowHp = nowHP;

        SetHpBarFollowTime();
        SetHpBar();
        DamageNum.instance.Damage(damage, 1, _transformHit, _iscritical);
    }

    public void GetHeel(int heel)
    {
        NowHp += heel;
        if (NowHp > MaxHp)
        {
            NowHp = MaxHp;
        }
        SetHpBar();
    }

    private void SetHpBar()
    {
        CheckHp();
        hpBar.value = value;
    }
    private void SetHpBarFollowTime()
    {
        followtime = followtimeMax;
    }
    private void SetHpBarFollow()
    {
        hpBarfollow.value = value;
    }
}
