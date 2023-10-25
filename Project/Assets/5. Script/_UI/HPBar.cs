using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{

    [SerializeField] Slider hpBar;
    [SerializeField] Slider hpBarfollow;
    int MaxHp = 0;
    int NowHp = 0;
    float value = 0;
    float followtimeMax = 2;
    float followtime = 0;

    [SerializeField]
    Transform target;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            MaxHp = 100;
            NowHp = MaxHp;
            SetHpBar();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDamage(10);
        }

        Debug.Log(followtime);

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

    public void GetDamage(int damage)
    {
        NowHp -= damage;
        if(NowHp<0)
        {
            NowHp = 0;
        }
        SetHpBarFollowTime();
        SetHpBar();
        DamageNum.instance.Damage(damage, 1);
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
