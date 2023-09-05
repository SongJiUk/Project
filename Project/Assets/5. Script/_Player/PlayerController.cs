using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    Player player;
    void Start()
    {
        if (null == player) player = Player.GetInstance;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
