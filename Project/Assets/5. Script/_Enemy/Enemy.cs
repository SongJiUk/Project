using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float maxEnemyHP = 50; // ������ �ִ�HP
    float nowEnemy; // ������ ����HP

    [SerializeField]
    Transform player; // �÷��̾��� ��ġ�� �����ϱ� ���� ����
    [SerializeField]
    float detectionRange = 10.0f; // ���Ͱ� �÷��̾ ������ ����

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
        // �÷��̾�� ���� ������ �Ÿ� ���
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (nav.enabled == true)
        {
            // �÷��̾ ���� ���� ���� ������ �÷��̾ ���� �̵�
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
        // ����Ʈ�� �����ϰ� �÷��̾� �������� ��ġ�� �����մϴ�.
        Vector3 effectPosition = player.position + Vector3.forward; // �÷��̾� ���ʿ� ����
        Instantiate(attackEffectPrefab, effectPosition, Quaternion.identity);

        // ���⿡�� �ʿ��� ���� ������ �߰��� �� �ֽ��ϴ�.
    }
}




//// �÷��̾ ���� ���� ���� ������ �÷��̾ ���� �̵�
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

// �÷��̾ ���� ���̸� �÷��̾ ���� �̵�
//if (isChasingPlayer)
//{
//    // �÷��̾� �������� ȸ��
//    transform.LookAt(player);

//    // �÷��̾�� ��������� ���缭 ����
//    if (distanceToPlayer <= attackDetectionRange)
//    {
//        Anime.SetBool("IsAttack", true);
//    }
//    else
//    {
//        // ���͸� �÷��̾� ������ �̵�
//        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
//        Anime.SetBool("IsAttack", false);
//    }
//}