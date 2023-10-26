using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;


public class PlayerBarManager : MonoBehaviour
{

    [SerializeField] Slider hpBar;
    [SerializeField] Slider hpBarfollow;
    [SerializeField] Text hptext;
    [SerializeField] Slider mpBar;
    [SerializeField] Text mptext;
    [SerializeField] Slider expBar;
    [SerializeField] Text exptext;

    float HpfollowtimeMax = 2;
    float followtime = 0;

    float savevalue = 0;

    public static PlayerBarManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
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

        }
    }

    public void SetMax(int maxHp,float maxMp)
    {
        hpBar.value = 1;
        hpBarfollow.value = 1;
        mpBar.value = 1;
        expBar.value = 1;
        hptext.text = $"{maxHp} / {maxHp}";
        mptext.text = $"{maxMp} / {maxMp}";
        exptext.text = $"EXP : {((float)((int)(0 * 10000)) / 100)}%";
    }


    public void SetHpBar(float value, float nowMp, int maxMp)
    {
        hpBar.value = value;
        savevalue = value;
        SetHpBarFollowTime();
        hptext.text = $"{nowMp} / {maxMp}";
    }
    private void SetHpBarFollowTime()
    {
        followtime = HpfollowtimeMax;
    }
    private void SetHpBarFollow()
    {
        hpBarfollow.value = savevalue;
    }

    public void SetMpBar(float value, float nowMp, float maxMp)
    {
        mpBar.value = value;
        mptext.text = $"{nowMp} / {maxMp}";
    }

    public void SetExpBar(float value)
    {
        expBar.value = value;
        exptext.text = $"EXP : {((float)((int)(value * 10000))/100)}%";
    }
}
