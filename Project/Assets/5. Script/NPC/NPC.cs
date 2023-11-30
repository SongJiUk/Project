using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent nav;

    Player player;

    GameManager manager;

    [SerializeField]
    GameObject scanObj;

    [SerializeField]
    GameObject InteretionText;

    [SerializeField]
    int npcid;

    public int NPCID { get { return npcid; } }

    [SerializeField] Quest_NPCUP NPCUP_ICON;

    [SerializeField] string NPCNAME;
    [SerializeField] string[] NPCTALK;
    [SerializeField] bool isSellNPC;
    [SerializeField] bool isQuestNPC;
    [SerializeField] GameObject npc_Name;
    [SerializeField] GameObject npc_Talk;

    TextMeshPro npc_name_txt;
    TextMeshPro npc_talk_txt;

    BoxCollider boxCollider;
    bool interection = false;

    public Vector3 startPosition;
    public float speed;

    private float distance;

    // 사각형의 크기
    private float width;
    private float height;

    // 사각형의 중심 위치
    private Vector3 centerPosition;

    public GameObject SellNPCPopup;
    public GameObject QuestNPCPopup;

    public Transform[] Waypoint;
    private NavMeshAgent navMeshAgent;
    Animator anim;
    private int currentWaypointIndex = 0;
    void Start()
    {
        
        if (player == null)
        {
            player = Player.GetInstance;
        }

        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (Waypoint.Length > 0)
        {
            SetDestination();
        }


        if (!isSellNPC && !isQuestNPC)
        {
            anim.SetBool("IsWalk", true);
            SetNextWaypoint();
        }




        manager = GameManager.GetInstance;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        boxCollider = GetComponent<BoxCollider>();
        interection = false;

        npc_name_txt = npc_Name.GetComponent<TextMeshPro>();

        if (npc_name_txt == null)
        {
            Debug.Log("npc_name_txt is null.");
        }

        npc_talk_txt = npc_Talk.GetComponent<TextMeshPro>();

        if (npc_talk_txt == null)
        {
            Debug.Log("npc_name_txt is null.");
        }


        if(isQuestNPC)
        {
            if (npcid == QuestManager.GetInstance.NPCID)
            {
                QuestManager.GetInstance.NPCUP_ICON = NPCUP_ICON;
                
                if (QuestManager.GetInstance.isQuestClear)
                {
                    if (NPCUP_ICON != null) NPCUP_ICON.ClearQuest();
                    
                }
                else if (QuestManager.GetInstance.isQuesting)
                {
                    if (NPCUP_ICON != null) NPCUP_ICON.IsQuesting();
                }
                else
                {
                    if (NPCUP_ICON != null) NPCUP_ICON.NOAcceptQuest();
                }

            }
        }
        
    }
    float distanceToPlayer;
    void Update()
    {

        if (isSellNPC)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= nav.stoppingDistance)
            {
                if (!interection && scanObj != null)
                {
                    interection = true;
                    InteretionText.SetActive(true);
                }
                
                scanObj = gameObject;
                if (Input.GetKeyDown(KeyCode.C) && scanObj != null)
                {
                    InteretionText.SetActive(false);
                    //manager.Action(scanObj);

                    if (SellNPCPopup != null) SellNPCPopup.SetActive(true);

                    anim.SetBool("Isconversation", true);
                }

                if (SellNPCPopup.activeSelf == false) anim.SetBool("Isconversation", false);
            }
            else
            {
                if (SellNPCPopup.activeSelf == false) anim.SetBool("Isconversation", false);

                if (interection)
                {
                    interection = false;
                    InteretionText.SetActive(false);
                }
                scanObj = null;

            }
        }
        else if (isQuestNPC)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);


            if (distanceToPlayer <= nav.stoppingDistance)
            {
                if(npcid == QuestManager.GetInstance.NPCID)
                {
                    if (!interection && scanObj != null)
                    {
                        interection = true;
                        InteretionText.SetActive(true);
                    }
                    
                    //if (QuestManager.GetInstance.QuestCheck())
                    //{
                    //    if(QuestManager.GetInstance.isQuesting)
                    //    {
                    //        NPCUP_ICON.ClearQuest();
                    //    }
                    //    else
                    //    {
                    //        NPCUP_ICON.ALLCLEAR();
                    //        QuestManager.GetInstance.NPCUP_ICON = NPCUP_ICON;
                    //    }
                        
                    //}
                    //else
                    //{
                    //    if(QuestManager.GetInstance.isQuesting)
                    //    {
                    //        NPCUP_ICON.IsQuesting();
                    //    }
                    //    else
                    //    {
                    //        NPCUP_ICON.NOAcceptQuest();
                    //        QuestManager.GetInstance.NPCUP_ICON = NPCUP_ICON;
                    //    }
                    //}

                    scanObj = gameObject;
                    if (Input.GetKeyDown(KeyCode.C) && scanObj != null)
                    {
                        InteretionText.SetActive(false);
                        if (QuestNPCPopup != null) QuestNPCPopup.SetActive(true);

                        

                        

                        anim.SetBool("Isconversation", true);
                    }

                    if (QuestNPCPopup.activeSelf == false) anim.SetBool("Isconversation", false);
                }
                else
                {

                }
                
            }
            else
            {
                if (QuestNPCPopup.activeSelf == false) anim.SetBool("Isconversation", false);

                if (interection)
                {
                    interection = false;
                    InteretionText.SetActive(false);
                }
                scanObj = null;

            }
        }
        else
        {

            if (navMeshAgent.remainingDistance < 0.1f && navMeshAgent.pathPending == false)
            {
                anim.SetBool("IsWalk", true);
                SetNextWaypoint();
            }
        }
    }

    public bool QuestCheck()
    {
        return QuestManager.GetInstance.isQuestClear;
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(!isSellNPC && !isQuestNPC)
            {
                anim.SetBool("IsWalk", false);
                int Rand1 = Random.Range(0, 3);
                anim.SetBool("Isinterection", true);
                anim.SetInteger("CheerNum", Rand1);
                navMeshAgent.isStopped = true;

            }


            int Rand = Random.Range(0, 2); 
            npc_Name.SetActive(true);
            npc_Talk.SetActive(true);

            string npcText = $"<color=orange>NPC</color><color=white>{NPCNAME}</color>";
            npc_name_txt.text = npcText;
            //npc_name_txt.colorGradient = new VertexGradient(new Color(1f, 0.5f, 0f), Color.white, Color.white, Color.white);
            // if (string.IsNullOrEmpty(npc_name_txt.text)) npc_name_txt.text = $"NPC[{NPCNAME}]";
            if (string.IsNullOrEmpty(npc_talk_txt.text)) npc_talk_txt.text = $"{NPCTALK[Rand]}";

            npc_Name.GetComponent<Transform>().position = transform.position + Vector3.up * 2.5f;
            npc_Talk.GetComponent<Transform>().position = transform.position + Vector3.up * 3f;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            transform.LookAt(player.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            npc_Name.SetActive(false);
            npc_Talk.SetActive(false);
            npc_talk_txt.text = "";
            if (!isSellNPC && !isQuestNPC)
            {
                anim.SetBool("Isinterection", false);
                anim.SetBool("IsWalk", true);
                navMeshAgent.isStopped = false;
                SetNextWaypoint();
            }

        }
       
    }

    void SetDestination()
    {
        navMeshAgent.SetDestination(Waypoint[currentWaypointIndex].position);
    }

    void SetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % Waypoint.Length;
        SetDestination();
    }

    public void ChangeNPCICON()
    {
        switch(npcid)
        {
            case 10:
                break;

            case 20:
                break;

            case 30:
                break;

        }
        QuestManager.GetInstance.NPCUP_ICON = NPCUP_ICON;
    }
}
