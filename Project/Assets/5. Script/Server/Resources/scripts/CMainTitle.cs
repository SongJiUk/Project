using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FreeNet;
using VirusWarGameServer;

public class CMainTitle : MonoBehaviour {


    public static CMainTitle current;
    private void Awake()
    {
        if (current == null)
            current = this;
        else
            Debug.LogError("Not Single CMainTitle");
    }

    enum USER_STATE
	{
		NOT_CONNECTED,
		CONNECTED,
		WAITING_MATCHING
	}
	CNetworkManager network_manager;
	USER_STATE user_state;
	void Start () {
		this.user_state = USER_STATE.NOT_CONNECTED;

        this.network_manager = GetComponent<CNetworkManager>();

		this.user_state = USER_STATE.NOT_CONNECTED;
		enter();
	}


	public void enter()
	{
		StopCoroutine("after_connected");

		this.network_manager.message_receiver = this;

		if (!this.network_manager.is_connected())
		{
			this.user_state = USER_STATE.CONNECTED;
			this.network_manager.connect();
		}
		else
		{
			on_connected();
		}
	}


	/// <summary>
	/// 서버에 접속된 이후에 처리할 루프.
	/// 마우스 입력이 들어오면 ENTER_GAME_ROOM_REQ프로토콜을 요청하고 
	/// 중복 요청을 방지하기 위해서 현재 코루틴을 중지 시킨다.
	/// </summary>
	/// <returns></returns>
	IEnumerator after_connected()
	{
		// CBattleRoom의 게임오버 상태에서 마우스 입력을 통해 메인 화면으로 넘어오도록 되어 있는데,
		// 한 프레임 내에서 이 코루틴이 실행될 경우 아직 마우스 입력이 남아있는것으로 판단되어
		// 메인 화면으로 돌아오자 마자 ENTER_GAME_ROOM_REQ패킷을 보내는 일이 발생한다.
		// 따라서 강제로 한 프레임을 건너뛰어 다음 프레임부터 코루틴의 내용이 수행될 수 있도록 한다.
		yield return new WaitForEndOfFrame();

        CPacket msg = CPacket.create((short)PROTOCOL.ENTER_GAME_ROOM);
        this.network_manager.send(msg);

        //while (true)
        //{
        //	if (this.user_state == USER_STATE.CONNECTED)
        //	{
        //		if (Input.anyKeyDown)
        //		{
        //			this.user_state = USER_STATE.WAITING_MATCHING;

        //			CPacket msg = CPacket.create((short)PROTOCOL.ENTER_GAME_ROOM);
        //			this.network_manager.send(msg);

        //			StopCoroutine("after_connected");
        //                  break;
        //		}
        //	}

        //	yield return 0;
        //}
    }
	public void ChatSend(string ChatMsg)
    {
        CPacket msg = CPacket.create((short)PROTOCOL.CHAT_MSG);
        msg.push(ChatMsg);
        this.network_manager.send(msg);
    }

	/// <summary>
	/// 서버에 접속이 완료되면 호출됨.
	/// </summary>
	public void on_connected()
	{
		this.user_state = USER_STATE.CONNECTED;
		StartCoroutine("after_connected");
	}

    // 서버에서 지정해준 본인의 플레이어 인덱스.
    int player_index;

    public int GetPlayerIndex()
    {
        return player_index;
    }

    /// <summary>
    /// 패킷을 수신 했을 때 호출됨.
    /// </summary>
    /// <param name="protocol"></param>
    /// <param name="msg"></param>
    public void on_recv(CPacket msg)
	{
		// 제일 먼저 프로토콜 아이디를 꺼내온다.
		PROTOCOL protocol_id = (PROTOCOL)msg.pop_protocol_id();
        switch (protocol_id)
		{
            case PROTOCOL.CHAT_MSG:
                {
                   string recvmsg = msg.pop_string();
                   ChatWindow.current.ChatCreate(recvmsg);
                    //Debug.LogError(recvmsg);
                }
                break;

            case PROTOCOL.ENTER_GAME_ROOM:
                {
                    player_index = msg.pop_int32();

                    //초기 생성위치
                    ObjectManager.current.MoveObject(player_index, new Vector3(player_index, 0, 0),0f);
                    Debug.LogError(player_index);
                }
                break;

            case PROTOCOL.PLAYER_MOVING:
                {
                    int player_index = msg.pop_int32();
                    float x = msg.pop_float();
                    float y = msg.pop_float();
                    float z = msg.pop_float();
                    float Angle = msg.pop_float();
                    ObjectManager.current.MoveObject(player_index, new Vector3(x, y, z), Angle);

                }
                break;
        }
	}


    //서버에 이동 요청, 내 플레이어만 가능
    public void PLAYER_MOVING_REQ(Vector3 MoveTarget,float angle)
    {
        CPacket msg = CPacket.create((short)PROTOCOL.PLAYER_MOVING);
        msg.push(MoveTarget.x);
        msg.push(MoveTarget.y);
        msg.push(MoveTarget.z);
        msg.push(angle);

        this.network_manager.send(msg);
    }
}
