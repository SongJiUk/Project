using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonShockWave : MonoBehaviour
{
    Player player;    // ��ä�ÿ� ���ԵǴ��� �Ǻ��� Ÿ��
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
            // 'Ÿ��-�� ����'�� '�� ���� ����'�� ����
            float dot = Vector3.Dot(interV.normalized, transform.forward);
            // �� ���� ��� ���� �����̹Ƿ� ���� ����� cos�� ���� ���ؼ� theta�� ����
            float theta = Mathf.Acos(dot);
            // angleRange�� ���ϱ� ���� degree�� ��ȯ
            float degree = Mathf.Rad2Deg * theta;

            // �þ߰� �Ǻ�
            if (degree <= angleRange / 2f)
            {
                Debug.LogWarning("충격파파파파");
            }
        }
    }
}
