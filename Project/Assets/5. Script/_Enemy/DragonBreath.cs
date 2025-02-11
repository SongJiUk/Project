using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreath : MonoBehaviour
{
    [SerializeField]
    GameObject attackEffectPrefab;
    [SerializeField]
    Transform EffectPosition;

    ParticleSystem particle;
    Player player;
    private void Start()
    {
        Enemy enemy = GetComponent<Enemy>();


        
        player = Player.GetInstance;
        GameObject obj = Instantiate(attackEffectPrefab);
        obj.GetComponent<EnemyAttack>().damage = enemy.damage;
        obj.transform.SetParent(EffectPosition);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        particle = obj.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (particle != null)
        {
            if (particle.isPlaying)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= 4.2f)
                {
                    //Debug.LogWarning("????????");
                }
            }
        }
        
    }

    public void DragonAttack()
    {
        transform.LookAt(player.transform);
       if(particle != null) particle.Play();
    }
}
