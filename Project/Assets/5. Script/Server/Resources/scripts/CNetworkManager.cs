using UnityEngine;
using System;
using System.Collections;
using FreeNet;
using FreeNetUnity;
using VirusWarGameServer;

public class CNetworkManager : MonoBehaviour {

	CFreeNetUnityService gameserver;
	string received_msg;

	public MonoBehaviour message_receiver;

	void Awake()
	{
		this.received_msg = "";

		// ��Ʈ��ũ ����� ���� CFreeNetUnityService��ü�� �߰��մϴ�.
		this.gameserver = gameObject.AddComponent<CFreeNetUnityService>();

		// ���� ��ȭ(����, �����)�� �뺸 ���� ��������Ʈ ����.
		this.gameserver.appcallback_on_status_changed += on_status_changed;

		// ��Ŷ ���� ��������Ʈ ����.
		this.gameserver.appcallback_on_message += on_message;
	}


	public void connect()
	{

        //this.gameserver.connect("115.94.245.254", 7979);
        this.gameserver.connect("192.168.30.14", 7979);
        //this.gameserver.connect("127.0.0.1", 7979);
    }

	public bool is_connected()
	{
		return this.gameserver.is_connected();
	}

	/// <summary>
	/// ��Ʈ��ũ ���� ����� ȣ��� �ݹ� �żҵ�.
	/// </summary>
	/// <param name="server_token"></param>
	void on_status_changed(NETWORK_EVENT status)
	{
		switch (status)
		{
				// ���� ����.
			case NETWORK_EVENT.connected:
				{
                    Debug.Log("on connected");
					this.received_msg += "on connected\n";

                    CMainTitle.current.on_connected();
				}
				break;

				// ���� ����.
			case NETWORK_EVENT.disconnected:
                Debug.Log("disconnected");
				this.received_msg += "disconnected\n";
				break;
		}
	}

	void on_message(CPacket msg)
	{
		this.message_receiver.SendMessage("on_recv", msg);
	}

	public void send(CPacket msg)
	{
		this.gameserver.send(msg);
	}
}
