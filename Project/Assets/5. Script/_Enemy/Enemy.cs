using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float maxEnemyHP = 50; // ???????? ????HP
    float nowEnemyHP; // ???????? ????HP

    [SerializeField]
    HPBar _hpBarUI;

    ObjectPoolManager objectPoolManager;

    [SerializeField]
    Player player; // ?????????? ?????? ???????? ???? ????
    [SerializeField]
    float detectionRange = 10.0f; // ???????? ?????????? ?????? ????

    Animator Anime;
    Transform target;
    UnityEngine.AI.NavMeshAgent nav;

    [SerializeField]
    GameObject attackEffectPrefab;

    [SerializeField]
    float attackTime = 4f;
    float timer = 0f;

    [SerializeField]
    float attackRange = 3f;
    int playerLayer; // 플레이어 레이어 마스크 설정

    public int damage;
    [SerializeField]
    int enemyID;
    [SerializeField]
    int EXP;

    float originalSpeed;

    bool isSkillHit = false;

    BoxCollider collider;


    [SerializeField] ItemDataPickup DropItemPrefab;
    [SerializeField] ItemDataPickup[] DropGoldPrefab;
    void Awake()
    {
        timer = attackTime;
        nowEnemyHP = maxEnemyHP;
        Anime = GetComponent<Animator>();
        //GameObject obj = GameObject.FindGameObjectWithTag("Player");
        //target = obj.transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //playerLayer = 1 << 5;
        playerLayer = 1 << LayerMask.NameToLayer("Player");
        // nav.acceleration = Mathf.Infinity;
        originalSpeed = nav.speed;
        objectPoolManager = ObjectPoolManager.GetInstance;
        _hpBarUI.SetMaxHP(maxEnemyHP);
    }

    bool die = false;
    void Update()
    {
        if (player == null)
        {
            player = Player.GetInstance;
        }
        else
        {
            if (!die)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (nav.enabled == true)
                {
                    // ?????????? ???? ???? ???? ?????? ?????????? ???? ????
                    timer += Time.deltaTime;
                    if (distanceToPlayer <= detectionRange)
                    {
                        Anime.SetBool("IsChasing", true);
                        nav.SetDestination(player.transform.position);
                        if (nav.remainingDistance <= nav.stoppingDistance)
                        {
                            if (timer >= attackTime)
                            {
                                transform.LookAt(player.transform);
                                Anime.SetTrigger("IsAttack");
                                timer = 0f;
                                nav.speed = 0f;
                            }
                        }
                    }
                    else
                    {
                        nav.SetDestination(transform.position);
                        Anime.SetBool("IsChasing", false);
                    }
                }
            }
        }

        // ?????????? ?????? ?????? ???? ????
    }

    public void StopRelease()
    {
        nav.speed = originalSpeed;
    }


    public void ActivateAttackEffect()
    {
        //playerLayer
        if (Vector3.Distance(transform.position, player.transform.position) <= 2f)
        {
            //Debug.LogWarning("왑왑 깨물기");
            // PlayerAttack();
        }
    }


    void EnemyHit(bool _isSkill)
    {

        float value;
        bool isCritical = PlayerStat.GetInstance.PlayerAttackCriticalCheck();
        if(_isSkill)
        {
            value = (PlayerStat.GetInstance.Damage + PlayerStat.GetInstance.WeaponDamage)* PlayerSkill.GetInstance.Skillmul;
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
            EnemyDie();
        }
        else
        {
            Anime.SetTrigger("IsHit");
        }
        _hpBarUI.GetDamage(nowEnemyHP, value, transform, isCritical);
    }

    public int GetEnemyID()
    {
        return enemyID;
    }

    private void OnDestroy()
    {
        QuestManager questManager = QuestManager.GetInstance;
        //quest.QuestCountUp(enemyID);
    }

    public void SkillHit()
    {
        if (!isSkillHit)
        {
            isSkillHit = true;

            EnemyHit(true);
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
            EnemyHit(false);
        }
    }

    void EnemyDie()
    {
        DropItem();

        if(QuestManager.GetInstance.QUESTID == 20) QuestManager.GetInstance.CheckKillCount();
        //콜라이더 제거
        if (null == collider) collider = GetComponent<BoxCollider>();
        if (collider != null) collider.enabled = false;
        //타겟 제거
        player = null;
        die = true;
        Anime.SetTrigger("IsDie");
        gameObject.SetActive(false);

        PlayerStat.GetInstance.GetExp(EXP);
        
        //objectPoolManager.ObjectDie(gameObject);
        //Anime.enabled = true;
    }

    public void DropItem()
    {
        //여기 해야됨 !!!!
        
        var dropitem = Instantiate(DropItemPrefab);
        dropitem.ITEMDATA = ItemManager.GetInstance.DropItem();
        dropitem.CreatePrefab();
        dropitem.transform.position = this.transform.position;


    }

    private void OnEnable() // 오브젝트 풀링에의해 다시 활성화될시 정보 초기화
    {
        if (null == collider) collider = GetComponent<BoxCollider>();
        if (collider != null) collider.enabled = true;
        die = false;
    }
}





//// ?????????? ???? ???? ???? ?????? ?????????? ???? ????
//if (distanceToPlayer <= detectionRange)
//{
//    isChasingPlayer = true;
//    Anime.SetBool("IsChasing", true);
//}
//else
//{
//    isChasingPlayer = false;
//    Anime.SetBool("IsChasing", false);
//}

// ?????????? ???? ?????? ?????????? ???? ????
//if (isChasingPlayer)
//{
//    // ???????? ???????? ????
//    transform.LookAt(player);

//    // ?????????? ?????????? ?????? ????
//    if (distanceToPlayer <= attackDetectionRange)
//    {
//        Anime.SetBool("IsAttack", true);
//    }
//    else
//    {
//        // ???????? ???????? ?????? ????
//        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
//        Anime.SetBool("IsAttack", false);
//    }
//}
