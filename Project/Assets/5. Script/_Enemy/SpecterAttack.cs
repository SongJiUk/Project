using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecterAttack : MonoBehaviour
{
    [SerializeField]
    GameObject Sword;

    BoxCollider SwordCollider;
    void Start()
    {
        SwordCollider = Sword.GetComponent<BoxCollider>();
    }
    
    public void SwordAttack()
    {
        SwordCollider.enabled = true;
    }

    public void AttackFinish()
    {
        SwordCollider.enabled = false;
    }
}
