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

    private void Update()
    {
        if (player == null)
        {
            player = Player.GetInstance;
        }
    }
    public void BallAttacks()
    {
        Enemy enemy = GetComponent<Enemy>();
        transform.LookAt(player.transform);
        var enemyattck =Instantiate(attackEffectPrefab, EffectPosition.position, Quaternion.identity);
        enemyattck.GetComponent<EnemyAttack>().damage = enemy.damage;
    }
}
