using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float maxEnemyHP = 50; // 몬스터의 최대HP
    float nowEnemy; // 몬스터의 현재HP

    [SerializeField]
    Transform player; // 플레이어의 위치를 추적하기 위한 변수
    [SerializeField]
    float detectionRange = 10.0f; // 몬스터가 플레이어를 감지할 범위

    Animator Anime;
    Transform target;
    UnityEngine.AI.NavMeshAgent nav;

    [SerializeField]
    GameObject attackEffectPrefab;
    void Start()
    {
        nowEnemy = maxEnemyHP;
        Anime = GetComponent<Animator>();
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        target = obj.transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
       // nav.acceleration = Mathf.Infinity;
    }

    void Update()
    {
        // 플레이어와 몬스터 사이의 거리 계산
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (nav.enabled == true)
        {
            // 플레이어가 감지 범위 내에 있으면 플레이어를 향해 이동
            if (distanceToPlayer <= detectionRange)
            {
                Anime.SetBool("IsChasing", true);
                nav.SetDestination(target.position);
                if (nav.remainingDistance <= nav.stoppingDistance)
                {
                    Anime.SetBool("IsAttack", true);
                    transform.LookAt(target);
                }
                else
                {
                    Anime.SetBool("IsAttack", false);
                }
            }else
            {
                nav.SetDestination(transform.position);
                Anime.SetBool("IsChasing", false);
            }
        }
    }

    public void ActivateAttackEffect()
    {
        // 이펙트를 생성하고 플레이어 방향으로 위치를 조정합니다.
        Vector3 effectPosition = player.position + Vector3.forward; // 플레이어 앞쪽에 생성
        Instantiate(attackEffectPrefab, effectPosition, Quaternion.identity);

        // 여기에서 필요한 공격 로직을 추가할 수 있습니다.
    }
}




//// 플레이어가 감지 범위 내에 있으면 플레이어를 향해 이동
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

// 플레이어를 추적 중이면 플레이어를 향해 이동
//if (isChasingPlayer)
//{
//    // 플레이어 방향으로 회전
//    transform.LookAt(player);

//    // 플레이어와 가까워지면 멈춰서 공격
//    if (distanceToPlayer <= attackDetectionRange)
//    {
//        Anime.SetBool("IsAttack", true);
//    }
//    else
//    {
//        // 몬스터를 플레이어 쪽으로 이동
//        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
//        Anime.SetBool("IsAttack", false);
//    }
//}