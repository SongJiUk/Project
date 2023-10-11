using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
{
    [SerializeField]
    float spwanTime = 4f;
    float spwanTimer = 0f;
    int count = 0;
    int ran = 2;

    [SerializeField]
    GameObject[] EnemyAarray;
    void Start()
    {
        count = 0;
    }

    void Update()
    {
        spwanTimer += Time.deltaTime;
        if (spwanTimer >= spwanTime)
        {
            if (count > 20)
            {
                ran++;
                count = 0;
            }
            count++;
            int num = Random.Range(0, ran);
            spwanTimer = 0f;
            Instantiate(EnemyAarray[num], gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
