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
	/// ������ ���ӵ� ���Ŀ� ó���� ����.
	/// ���콺 �Է��� ������ ENTER_GAME_ROOM_REQ���������� ��û�ϰ� 
	/// �ߺ� ��û�� �����ϱ� ���ؼ� ���� �ڷ�ƾ�� ���� ��Ų��.
	/// </summary>
	/// <returns></returns>
	IEnumerator after_connected()
	{
		// CBattleRoom�� ���ӿ��� ���¿��� ���콺 �Է��� ���� ���� ȭ������ �Ѿ������ �Ǿ� �ִµ�,
		// �� ������ ������ �� �ڷ�ƾ�� ����� ��� ���� ���콺 �Է��� �����ִ°����� �ǴܵǾ�
		// ���� ȭ������ ���ƿ��� ���� ENTER_GAME_ROOM_REQ��Ŷ�� ������ ���� �߻��Ѵ�.
		// ���� ������ �� �������� �ǳʶپ� ���� �����Ӻ��� �ڷ�ƾ�� ������ ����� �� �ֵ��� �Ѵ�.
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
	/// ������ ������ �Ϸ�Ǹ� ȣ���.
	/// </summary>
	public void on_connected()
	{
		this.user_state = USER_STATE.CONNECTED;
		StartCoroutine("after_connected");
	}

    // �������� �������� ������ �÷��̾� �ε���.
    int player_index;

    public int GetPlayerIndex()
    {
        return player_index;
    }

    /// <summary>
    /// ��Ŷ�� ���� ���� �� ȣ���.
    /// </summary>
    /// <param name="protocol"></param>
    /// <param name="msg"></param>
    public void on_recv(CPacket msg)
	{
		// ���� ���� �������� ���̵� �����´�.
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

                    //�ʱ� ������ġ
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


    //������ �̵� ��û, �� �÷��̾ ����
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
