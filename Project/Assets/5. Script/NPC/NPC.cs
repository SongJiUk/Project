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

    void Start()
    {
        manager = GameManager.GetInstance;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        boxCollider = GetComponent<BoxCollider>();
        interection = false;

        //distance = Vector3.Distance(startPosition, transform.position);

        //// 사각형의 크기를 계산합니다.
        //width = Mathf.Abs(startPosition.x - transform.position.x);
        //height = Mathf.Abs(startPosition.y - transform.position.y);

        //// 사각형의 중심 위치를 계산합니다.
        //centerPosition = (startPosition + transform.position) / 2;
    }
    void Update()
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
