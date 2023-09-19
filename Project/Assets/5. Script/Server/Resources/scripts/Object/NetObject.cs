using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FreeNet;
using VirusWarGameServer;
public class NetObject : MonoBehaviour
{
    public int player_index { get; private set; }

    bool IsPlayer = false; //플레이어 소유인지 체크
    //추후 오브젝트 정보 추가할것(플레이어,몬스터,아이템)
    public void CreateObejct(int playerindex)
    {
        player_index = playerindex;

        if (CMainTitle.current.GetPlayerIndex() == player_index)
            IsPlayer = true;
    }

    void Start()
    {
        
    }

    void PlayerInput()
    {
        Vector3 Dir = new Vector3(
         Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        transform.position += Dir.normalized * Time.deltaTime * 3f;
    }
    public Vector3 TargetPos;
    public float Angle;
    void Update()
    {
        if (IsPlayer == false)
        {
            transform.position =  Vector3.Lerp(transform.position,TargetPos,Time.deltaTime * 6f);

            if(Vector3.Distance(transform.position,TargetPos) < 0.1f)
                GetComponent<Animator>().SetBool("IsWalk",false);
            else
                GetComponent<Animator>().SetBool("IsWalk", true);

            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(0, Angle, 0), Time.deltaTime * 10f);
     
            return;
        }



       //PlayerInput();
        PostionSend();
    }

    //이전 위치
    Vector3 PrePos;
    float MoveTimer = 0f;
    void PostionSend()
    {
        MoveTimer += Time.deltaTime;

        //움직일때만
        if (PrePos != transform.position)
        {
            if (MoveTimer >= 0.1f)
            {
                //프레임마다 보내면 연산이 오지게 크다.
                CMainTitle.current.PLAYER_MOVING_REQ(
                    transform.position, transform.rotation.eulerAngles.y);
                MoveTimer = 0;
            }

            PrePos = transform.position;
        }
    }


}
