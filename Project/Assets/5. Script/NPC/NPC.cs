using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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


    [SerializeField] string NPCNAME;
    [SerializeField] string[] NPCTALK;
    [SerializeField] bool isSellNPC;
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

    void Start()
    {
        if (player == null)
        {
            player = Player.GetInstance;
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
    }
    void Update()
    {

        if(isSellNPC)
        {

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
                    //manager.Action(scanObj);

                    if (SellNPCPopup != null) SellNPCPopup.SetActive(true);


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
        else
        {
            //// 이동 방향을 계산합니다.
            //Vector3 direction = centerPosition - transform.position;

            //// 이동합니다.
            //transform.position += direction * speed * Time.deltaTime;

            //// 이동 거리를 업데이트합니다.
            //distance -= Vector3.Distance(startPosition, transform.position);

            //// 사각형의 경계선을 벗어나면 방향을 반대로 바꿉니다.
            //if (transform.position.x < centerPosition.x - width / 2)
            //{
            //    direction.x = -direction.x;
            //}
            //else if (transform.position.x > centerPosition.x + width / 2)
            //{
            //    direction.x = -direction.x;
            //}

            //if (transform.position.y < centerPosition.y - height / 2)
            //{
            //    direction.y = -direction.y;
            //}
            //else if (transform.position.y > centerPosition.y + height / 2)
            //{
            //    direction.y = -direction.y;
            //}
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            int Rand = Random.Range(0, 2); 
            npc_Name.SetActive(true);
            npc_Talk.SetActive(true);

            string npcText = $"<color=orange>NPC</color><color=white>{NPCNAME}</color>";
            npc_name_txt.text = npcText;
            //npc_name_txt.colorGradient = new VertexGradient(new Color(1f, 0.5f, 0f), Color.white, Color.white, Color.white);
            // if (string.IsNullOrEmpty(npc_name_txt.text)) npc_name_txt.text = $"NPC[{NPCNAME}]";
            if (string.IsNullOrEmpty(npc_talk_txt.text)) npc_talk_txt.text = $"{NPCTALK[Rand]}";

            npc_Name.GetComponent<Transform>().position = transform.position + Vector3.up * 2f;
            npc_Talk.GetComponent<Transform>().position = transform.position + Vector3.up * 2.5f;
            
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

        }
       
    }
}
