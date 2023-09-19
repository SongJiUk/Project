using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : MonoBehaviour
{
    [SerializeField]
    GameObject attackEffectPrefab;
    [SerializeField]
    Transform EffectPosition;

    ParticleSystem particle;
    Player player;

    void Start()
    {
        GameObject obj = Instantiate(attackEffectPrefab);
        obj.transform.SetParent(EffectPosition);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        particle = obj.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (player == null)
        {
            player = Player.GetInstance;
        }
    }

    public void GolemAttacking()
    {
        particle.Play();
        if (Vector3.Distance(player.transform.position, EffectPosition.position) <= 3.1f)
        {
            Debug.Log("ÄíÄô");
        }
    }
}
