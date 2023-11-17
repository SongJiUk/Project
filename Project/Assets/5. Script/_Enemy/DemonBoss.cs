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
    int EXP;


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
   int maxHP;
    float nowHP;
    float nowEnemyHP;
    public int Damage;

    bool isSkillHit = false;


    BossHPUIManager _bossHPUIManager;
    [SerializeField]
    BossHPBar _bossHpBar;

    ParticleSystem Charge;
    ParticleSystem Lazer;

    BoxCollider collider;
    bool die = false;
    void Awake()    
   {
        if(_bossHPUIManager == null)
        _bossHPUIManager = BossHPUIManager.instance;
        _bossHPUIManager.AwakeBoss(BossName, maxHP);
        nowHP = maxHP;
        player = Player.GetInstance;
        anime = GetComponent<Animator>();
        nowEnemyHP = maxHP;
        Attack1Position();
    }

    void Update()
    {
        if(!die)
        {
            transform.LookAt(player.transform);
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

                }
                else if (ran > 30 && ran <= 60)
                {
                    anime.SetTrigger("Attack2");
                    attckTimer = 15f;
                    Damage *= 2;
                }
                else
                {
                    anime.SetTrigger("Attack3");
                    attckTimer = 12f;
                    Damage *= 2;
                }
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


   

    void BossDie()
    {
        DropItem();
        //콜라이더 제거
        if (null == collider) collider = GetComponent<BoxCollider>();
        if (collider != null) collider.enabled = false;
        //타겟 제거
        player = null;
        die = true;
        anime.SetTrigger("IsDie");
        
        Invoke("WaitDie", 2f);
        PlayerStat.GetInstance.GetExp(EXP);

        //objectPoolManager.ObjectDie(gameObject);
        //Anime.enabled = true;
    }

    public void WaitDie()
    {
        gameObject.SetActive(false);
    }

    public void DropItem()
    {
        //여기 해야됨 !!!!

        //var dropitem = Instantiate(DropItemPrefab);
        //dropitem.ITEMDATA = ItemManager.GetInstance.DropItem();
        //dropitem.CreatePrefab();
        //dropitem.transform.position = this.transform.position;


    }
    public void SkillHit()
    {
        if (!isSkillHit)
        {
            isSkillHit = true;

            BossHit(true);
            Invoke("HitDelay", 0.5f);
        }

    }

    public void HitDelay()
    {
        isSkillHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack"))
        {
            BossHit(false);
        }
    }

    void BossHit(bool _isSkill)
    {

        float value;
        bool isCritical = PlayerStat.GetInstance.PlayerAttackCriticalCheck();
        if (_isSkill)
        {
            value = (PlayerStat.GetInstance.Damage + PlayerStat.GetInstance.WeaponDamage) * PlayerSkill.GetInstance.Skillmul;
        }
        else
        {
            value = PlayerStat.GetInstance.Damage + PlayerStat.GetInstance.WeaponDamage;
        }


        if (isCritical)
        {
            value *= 2;
        }

        nowEnemyHP -= value;
        if (nowEnemyHP <= 0)
        {
            BossDie();
        }

        _bossHpBar.GetDamage(nowEnemyHP, value, transform, isCritical);
    }

}
