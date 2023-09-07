using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour
{
    Player player;
    Vector3 Dir;

    float attckTimer =13f;

    Animator anime;

    [SerializeField]
    Transform Point;
    [SerializeField]
    GameObject ChargePrefab;
    [SerializeField]
    GameObject LazerChargePrefab;

    ParticleSystem Charge;
    ParticleSystem Lazer;
    void Start()
    {
        player = Player.GetInstance;
        anime = GetComponent<Animator>();
        attckTimer = 3f;
        Attack1Position();
    }

    void Update()
    {
        attckTimer -= Time.deltaTime;
        if (attckTimer <= 0f)
        {
            float ran = Random.Range(0, 101);
            transform.LookAt(player.transform);
            if (ran <= 30)
            {
                anime.SetTrigger("Attack1");
                DemonCharge();
                attckTimer = 12f;
            }else if (ran > 30 && ran <= 55)
            {
                anime.SetTrigger("Attack2");
                attckTimer = 15f;
            }
            else if (ran > 55 && ran <= 85)
            {

            }else
            {

            }
        }
    }

    void Attack1Position()
    {
        GameObject obj;
        obj = Instantiate(ChargePrefab);
        obj.transform.SetParent(Point);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        Charge = obj.GetComponent<ParticleSystem>();

        obj = Instantiate(LazerChargePrefab);
        obj.transform.SetParent(Point);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        Lazer = obj.GetComponent<ParticleSystem>();
    }

    //Dir = (player.transform.position) - (transform.position);
    void DemonCharge()
    {
        Charge.Play();
    }

    public void DemonLazer()
    {
        Lazer.Play();
    }

    [SerializeField]
    GameObject DemonMeteorPrefab;
    int meteorMaxCount = 5;
    int meteorCount = 0;
    public void DemonMeteor()
    {
        InvokeRepeating("MeteorInvoke", 0f, 0.2f);
    }

    void MeteorInvoke()
    {
        Vector3 playerPosi = player.transform.position;
        Instantiate(DemonMeteorPrefab, new Vector3(Random.Range(playerPosi.x - 10, playerPosi.x + 10), 1f, Random.Range(playerPosi.z - 10, playerPosi.z + 10)), Quaternion.identity);
        meteorCount++;
        if (meteorCount >= meteorMaxCount)
        {
            CancelInvoke("MeteorInvoke");
            meteorCount = 0;
        }
    }
}
