using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonShockWave : MonoBehaviour
{
    Player player;    // 부채꼴에 포함되는지 판별할 타겟
    [SerializeField]
    Transform target;
    [SerializeField]
    float angleRange = 55f;
    [SerializeField]
    float radius = 21f;

    Vector3 interV;

    void Start()
    {
        player = Player.GetInstance;
        interV = player.transform.position - target.position;
        Invoke("ShockWaveDestroy", 2.5f);
        Invoke("ShockWaveAttack", 1.5f);
    }

    void ShockWaveDestroy()
    {
        Destroy(gameObject);
    }
    void ShockWaveAttack()
    {
        if (interV.magnitude <= radius)
        {
            // '타겟-나 벡터'와 '내 정면 벡터'를 내적
            float dot = Vector3.Dot(interV.normalized, transform.forward);
            // 두 벡터 모두 단위 벡터이므로 내적 결과에 cos의 역을 취해서 theta를 구함
            float theta = Mathf.Acos(dot);
            // angleRange와 비교하기 위해 degree로 변환
            float degree = Mathf.Rad2Deg * theta;

            // 시야각 판별
            if (degree <= angleRange / 2f)
            {
                Debug.LogWarning("충격파파파파파");
            }
        }
    }
}
