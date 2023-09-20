using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent nav;

    [SerializeField]
    GameObject TextBox;

    bool textTrue = false;

    [SerializeField]
    GameObject QuestText;

    bool QuestActive = false;
    bool Quest1 = false;

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
            if (!Quest1)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    textTrue = true;
                    TextBox.SetActive(false);
                    QuestText.SetActive(true);
                    QuestActive = true;
                }
            }

            if (QuestActive)
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    Debug.Log("Äù½ºÆ® ¼ö¶ô");
                    Quest1 = true;
                    TextBox.GetComponent<UnityEngine.UI.Text>().text = "»¡¸® ÇØ°áÇØ Áà!";
                    QuestText.SetActive(false);
                    QuestActive = false;
                    TextBox.SetActive(true);
                } else if (Input.GetKeyDown(KeyCode.B))
                {
                    Debug.Log("Äù½ºÆ® °ÅÀý");
                    QuestText.SetActive(false);
                    QuestActive = false;
                    TextBox.SetActive(true);
                }
            }
        }else
        {
            if (!textTrue)
            {
                TextBox.SetActive(false);
                QuestText.SetActive(false);
                QuestActive = false;
            }
            textTrue = false;
        }
    }
}
