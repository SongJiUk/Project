using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{

    [SerializeField] Slider hpBar;
    [SerializeField] Slider hpBarfollow;
    float MaxHp = 0;
    float NowHp = 0;
    float value = 0;
    float followtimeMax = 2;
    float followtime = 0;

    // Start is called before the first frame update
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

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    SetMaxHP(100);
        //}
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

    public void SetMaxHP(float _MaxHP)
    {
        MaxHp = _MaxHP;
        NowHp = MaxHp;
        SetHpBar();
    }

    public void GetDamage(float nowHP,float damage, Transform _transformHit)
    {
        NowHp = nowHP;
        
        SetHpBarFollowTime();
        SetHpBar();
        DamageNum.instance.Damage(damage, 1, _transformHit);
    }

    public void GetHeel(float nowHP, float heel)
    {
        NowHp = nowHP;
        
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
