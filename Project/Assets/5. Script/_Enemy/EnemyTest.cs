using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyTest : MonoBehaviour
{
    Player player;    // 부채꼴에 포함되는지 판별할 타겟
    [SerializeField]
    Transform target;
    [SerializeField]
    float angleRange = 55f;
    [SerializeField]
    float radius = 21f;

    Color _blue = new Color(0f, 0f, 1f, 0.2f);
    Color _red = new Color(1f, 0f, 0f, 0.2f);

    bool isCollision = false;

    private void Start()
    {
        player = Player.GetInstance;
    }

    void Update()
    {
        Vector3 interV = player.transform.position - target.position;

        // target과 나 사이의 거리가 radius 보다 작다면
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
                isCollision = true;
            else
                isCollision = false;

        }
        else
            isCollision = false;
    }

    // 유니티 에디터에 부채꼴을 그려줄 메소드
    private void OnDrawGizmos()
    {
        Handles.color = isCollision ? _red : _blue;
        // DrawSolidArc(시작점, 노멀벡터(법선벡터), 그려줄 방향 벡터, 각도, 반지름)
        Handles.DrawSolidArc(target.position, Vector3.up, transform.forward, angleRange / 2, radius);
        Handles.DrawSolidArc(target.position, Vector3.up, transform.forward, -angleRange / 2, radius);
    }
}
