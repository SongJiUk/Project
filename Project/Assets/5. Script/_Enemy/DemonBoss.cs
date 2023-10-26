using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour
{
    Player player;
    Vector3 Dir;

    float attckTimer = 7f;

    Animator anime;

    [SerializeField]
    Transform Point;
    [SerializeField]
    Transform Attack3Point;
    [SerializeField]
    GameObject ChargePrefab;
    [SerializeField]
    GameObject LazerChargePrefab;
    [SerializeField]
    GameObject ShockWavePrefab;
    [SerializeField]
    string BossName;
    [SerializeField]
    float maxHP;
    float nowHP;

    bool isSkillHit = false;


    BossHPUIManager _bossHPUIManager;


    ParticleSystem Charge;
    ParticleSystem Lazer;
    void Awake()    
   {
        if(_bossHPUIManager == null)
        _bossHPUIManager = BossHPUIManager.instance;
        _bossHPUIManager.AwakeBoss(BossName, 100);
        nowHP = maxHP;
        player = Player.GetInstance;
        anime = GetComponent<Animator>();
        Attack1Position();
    }

    void Update()
    {
        attckTimer -= Time.deltaTime;
        if (attckTimer <= 0f)
        {
            float ran = Random.Range(0, 91);
            transform.LookAt(player.transform);
            if (ran <= 30)
            {
                anime.SetTrigger("Attack1");
                DemonCharge();
                attckTimer = 12f;
            }else if (ran > 30 && ran <= 60)
            {
                anime.SetTrigger("Attack2");
                attckTimer = 15f;
            }
            else
            {
                anime.SetTrigger("Attack3");
                attckTimer = 12f;
            }
        }
    }

    void Attack1Position()
    {
        GameObject obj;
        obj = Instantiate(ChargePrefab);
        obj.transform.SetParent(Point);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        Charge = obj.GetComponent<ParticleSystem>();

        obj = Instantiate(LazerChargePrefab);
        obj.transform.SetParent(Point);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        Lazer = obj.GetComponent<ParticleSystem>();
    }

    //Dir = (player.transform.position) - (transform.position);
    void DemonCharge()
    {
        Charge.Play();
    }

    public void DemonLazer()
    {
        Lazer.Play();
    }

    [SerializeField]
    GameObject DemonMeteorPrefab;
    int meteorMaxCount = 5;
    int meteorCount = 0;
    public void DemonMeteor()
    {
        InvokeRepeating("MeteorInvoke", 0f, 0.2f);
    }

    void MeteorInvoke()
    {
        Vector3 playerPosi = player.transform.position;
        Instantiate(DemonMeteorPrefab, new Vector3(Random.Range(playerPosi.x - 10, playerPosi.x + 10), 2f, Random.Range(playerPosi.z - 10, playerPosi.z + 10)), Quaternion.identity);
        meteorCount++;
        if (meteorCount >= meteorMaxCount)
        {
            CancelInvoke("MeteorInvoke");
            meteorCount = 0;
        }
    }

    public void DemonShockWave()
    {
        Instantiate(ShockWavePrefab, Attack3Point.transform.position, Quaternion.identity);
    }

    void BossHit(int value)
    {
        nowHP -= value;
        if (nowHP <= 0)
        {
            BossDie();
        }
    }

    void BossDie()
    {

    }

    public void SkillHit()
    {
        if (!isSkillHit)
        {
            isSkillHit = true;

            BossHit(10);
            Debug.Log("¾ÆÇÁ´Ù : " + this.name + nowHP);
            Invoke("HitDelay", 0.5f);
        }

    }

    public void HitDelay()
    {
        isSkillHit = false;
    }
}
