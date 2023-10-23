using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [SerializeField]
    float spwanTime = 4f;

    [SerializeField]
    GameObject[] Enemy;
    Queue<GameObject> m_queue = new Queue<GameObject>();

    [SerializeField]
    Transform[] SpawnPoint;

    void Start()
    {
        instance = this;

        for (int i = 0; i < Enemy.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int ran = Random.Range(0, Enemy.Length);
                GameObject t_object = Instantiate(Enemy[ran], this.gameObject.transform);
                m_queue.Enqueue(t_object);
                t_object.SetActive(false);
            }
        }

        StartCoroutine(MonsterSpawn());
    }

    public void InsertQueue(GameObject p_object)
    {
        m_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);

        return t_object;
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            if (m_queue.Count != 0)
            {
                GameObject t_object = GetQueue();
                int ran = Random.Range(0, SpawnPoint.Length);
                t_object.transform.position = SpawnPoint[ran].position;
            }
            yield return new WaitForSeconds(spwanTime);
        }
    }
    public void ObjectDie(GameObject EnemyObject)
    {
        instance.InsertQueue(EnemyObject);
        //MonsterSpawner.instance.InsertQueue(gameObject);
    }
}
