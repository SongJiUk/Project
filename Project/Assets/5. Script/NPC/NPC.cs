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

    [SerializeField]
    GameObject InteretionText;
    bool interection = false;
    void Start()
    {
        manager = GameManager.GetInstance;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        interection = false;
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
            if (!interection && scanObj != null)
            {
                interection = true;
                InteretionText.SetActive(true);
            }
            Vector3 dir = player.transform.position - transform.position;
            dir.y = 0f;
            Quaternion rot = Quaternion.LookRotation(dir.normalized);
            transform.rotation = rot;

            scanObj = gameObject;
            if (Input.GetKeyDown(KeyCode.C) && scanObj != null)
            {
                InteretionText.SetActive(false);
                manager.Action(scanObj);
            }
        }
        else
        {
            if (interection)
            {
                interection = false;
                InteretionText.SetActive(false);
            }
            scanObj = null;
        }
    }
}
