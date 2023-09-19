using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FreeNet;
using VirusWarGameServer;
public class NetObject : MonoBehaviour
{
    public int player_index { get; private set; }

    bool IsPlayer = false; //�÷��̾� �������� üũ
    //���� ������Ʈ ���� �߰��Ұ�(�÷��̾�,����,������)
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

    //���� ��ġ
    Vector3 PrePos;
    float MoveTimer = 0f;
    void PostionSend()
    {
        MoveTimer += Time.deltaTime;

        //�����϶���
        if (PrePos != transform.position)
        {
            if (MoveTimer >= 0.1f)
            {
                //�����Ӹ��� ������ ������ ������ ũ��.
                CMainTitle.current.PLAYER_MOVING_REQ(
                    transform.position, transform.rotation.eulerAngles.y);
                MoveTimer = 0;
            }

            PrePos = transform.position;
        }
    }


}
