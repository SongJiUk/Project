using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBarManager : MonoBehaviour
{

    [SerializeField] Slider hpBar;
    [SerializeField] Slider hpBarfollow;
    [SerializeField] Text hptext;
    [SerializeField] Slider mpBar;
    [SerializeField] Text mptext;
    [SerializeField] Slider expBar;
    [SerializeField] Text exptext;

    int MaxHp = 0;
    int NowHp = 0;
    int MaxMp = 0;
    int NowMp = 0;
    int MaxExp = 0;
    int NowExp = 0;
    float Hpvalue = 0;
    float Mpvalue = 0;
    float Expvalue = 0;
    float HpfollowtimeMax = 2;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            SetMaxHP(100);
            SetMaxMP(100);
            SetMaxEXP(100);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDamage(10);
            UseMp(10);
            GetExp(10);
        }

        Debug.Log(followtime);

    }

    private void CheckHp()
    {
        if (NowHp <= 0 || MaxHp <= 0)
        {
            Hpvalue = 0;
        }
        else
        {
            Hpvalue = ((float)NowHp / (float)MaxHp);
        }
    }

    private void CheckMp()
    {
        if (NowMp <= 0 || MaxMp <= 0)
        {
            Mpvalue = 0;
        }
        else
        {
            Mpvalue = ((float)NowMp / (float)MaxMp);
        }
    }

    private void CheckExp()
    {
        if (NowExp <= 0 || MaxExp <= 0)
        {
            Expvalue = 0;
        }
        else
        {
            Expvalue = ((float)NowExp / (float)MaxExp);
        }
    }

    public void SetMaxHP(int _MaxHP)
    {
        MaxHp = _MaxHP;
        NowHp = MaxHp;
        SetHpBar();
    }

    public void SetMaxMP(int _MaxMP)
    {
        MaxMp = _MaxMP;
        NowMp = MaxMp;
        SetMpBar();
    }

    public void SetMaxEXP(int _MaxEXP)
    {
        MaxExp = _MaxEXP;
        NowExp = 0;
        SetExpBar();
    }

    public void GetDamage(int damage)
    {
        NowHp -= damage;
        if (NowHp < 0)
        {
            NowHp = 0;
        }
        SetHpBarFollowTime();
        SetHpBar();
        DamageNum.instance.Damage(damage, 1);
    }

    public void UseMp(int num)
    {
        NowMp -= num;
        if (NowMp < 0)
        {
            NowMp = 0;
        }
        SetMpBar();
    }

    public void GetExp(int num)
    {
        NowExp += num;
        if (NowExp > MaxExp)
        {
            NowExp = MaxExp;
        }
        SetExpBar();
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
        hpBar.value = Hpvalue;
        hptext.text = $"{NowHp} / {MaxHp}";
    }
    private void SetHpBarFollowTime()
    {
        followtime = HpfollowtimeMax;
    }
    private void SetHpBarFollow()
    {
        hpBarfollow.value = Hpvalue;
    }

    private void SetMpBar()
    {
        CheckMp();
        mpBar.value = Mpvalue;
        mptext.text = $"{NowMp} / {MaxMp}";
    }

    private void SetExpBar()
    {
        CheckExp();
        expBar.value = Expvalue;
        exptext.text = $"EXP : {((float)((int)(Expvalue * 10000))/100)}%";
    }
}
