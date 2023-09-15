using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatText : MonoBehaviour
{
    public void OnCreateText(string msg)
    {
        UnityEngine.UI.Text msgtext = GetComponentInChildren<UnityEngine.UI.Text>();
        if (msgtext != null)
            msgtext.text = msg;
    }
}
