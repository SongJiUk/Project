using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float maxEnemyHP = 50; // ???????? ????HP
    float nowEnemyHP; // ???????? ????HP

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

    float originalSpeed;
    void Start()
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
    }

    void Update()
    {
        if (player == null)
        {
            player = Player.GetInstance;
        }else
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
            // Debug
            if (Input.GetKeyDown(KeyCode.B))
            {
                EnemyHit(10);
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


    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.gameObject) ;
    //}

    void EnemyHit(int value)
    {
        nowEnemyHP -= value;
        Anime.SetTrigger("IsHit");
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