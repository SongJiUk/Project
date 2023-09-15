using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWindow : MonoBehaviour
{
    [SerializeField]
    GameObject ChatPrefabs;

    [SerializeField]
    Transform parTrans;

    public static ChatWindow current;
    private void Awake()
    {
        if (current == null)
            current = this;
        else
            Debug.LogError("Not single ChatWindow");
    }
    public void ChatCreate(string msg)
    {
        GameObject obj = Instantiate(ChatPrefabs, parTrans);
        obj.GetComponent<ChatText>().OnCreateText(msg);
    }

}
