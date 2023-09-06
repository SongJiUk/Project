using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack : MonoBehaviour
{
    [SerializeField]
    GameObject attackEffectPrefab;
    [SerializeField]
    Transform EffectPosition;
    Player player;
    private void Start()
    {
        player =  Player.GetInstance;
    }
    public void BallAttacks()
    {
        transform.LookAt(player.transform);
        Instantiate(attackEffectPrefab, EffectPosition.position, Quaternion.identity);
    }
}
