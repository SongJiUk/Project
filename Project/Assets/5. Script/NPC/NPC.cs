using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent nav;

    Player player;

    GameManager manager;

    [SerializeField]
    GameObject scanObj;
    void Start()
    {
        manager = GameManager.GetInstance;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Update()
    {
        if (player == null)
        {
            player = Player.GetInstance;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= nav.stoppingDistance)
        {
            Vector3 dir = player.transform.position - transform.position;
            dir.y = 0f;
            Quaternion rot = Quaternion.LookRotation(dir.normalized);
            transform.rotation = rot;

            scanObj = gameObject;
            if (Input.GetKeyDown(KeyCode.C) && scanObj != null)
            {
                manager.Action(scanObj);
            }
        }
        else
        {
            scanObj = null;
        }
    }
}
