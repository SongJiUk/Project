using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent nav;

    [SerializeField]
    GameObject TextBox;

    UnityEngine.UI.Text QuestText;
    bool textTrue = false;

    Player player;
    void Start()
    {
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
            transform.LookAt(player.transform);
            if (!textTrue)
            {
                TextBox.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Äù½ºÆ® ¹Þ±â");
                textTrue = true;
                TextBox.SetActive(false);
            }
        }else
        {
            if (!textTrue)
            {
                TextBox.SetActive(false);
                textTrue = false;
            }
        }
    }
}
