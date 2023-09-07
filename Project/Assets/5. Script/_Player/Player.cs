using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    private int level;
    public int LEVEL { get { return level; } }

    private float exp;
    public float EXP { get { return exp; } }

    private float hp;
    public float HP { get { return hp; } }

    private float speed;
    public float SPEED { get { return speed; } set { speed = value; } }


    Animator anim;
    public Animator ANIM { get { return anim; } private set {  } }
    NavMeshAgent nav;
    public NavMeshAgent NAV { get { return nav; } private set { } }
    Rigidbody rigid;
    public Rigidbody RIGID { get { return rigid; } private set { } }

    private void Awake()
    {
        //if (null == instance) instance = this;
        if (null == anim) anim = GetComponent<Animator>();
        if (null == nav) nav = GetComponent<NavMeshAgent>();
        if (null == rigid) rigid = GetComponent<Rigidbody>();
        SPEED = 3f;

    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
    }
}
