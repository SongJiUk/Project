using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDistanceAttack : MonoBehaviour
{
    [SerializeField] GameObject hit;
    [SerializeField] GameObject Flash;
    private float randomUpAngle;
    private float randomSideAngle;
    public float sideAngle = 25;
    public float upAngle = 20;
    private Rigidbody rigid;
    void Start()
    {
        startpos = transform.position;
        rigid = GetComponent<Rigidbody>();
        FlashEffect();
        newRandom();
    }
    Vector3 startpos;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if (Player.GetInstance.playerStat.unitCode == UnitCode.MAGE)
        {
            var enemy = FindObjectOfType<Enemy>();
            timer += Time.deltaTime;
            if(enemy != null)
            {
                Vector3 pos = transform.position;
                pos.y = Mathf.Sin(timer) * 3f;
                transform.position = Vector3.Lerp(startpos, enemy.transform.position + Vector3.up, timer * 0.4f);
                transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);


                Vector3 dis = (enemy.transform.position + Vector3.up - transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(dis);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);
            }
            else
            {
                rigid.velocity = transform.forward * 10f;
            }

            
        }
        else if (Player.GetInstance.playerStat.unitCode == UnitCode.ARCHER)
        {
            if(Player.GetInstance.PController.isGuided)
            {
                var enemy = FindObjectOfType<Enemy>();
                //if (enemy == null)
                //{
                //    foreach (var detachedPrefab in Detached)
                //    {
                //        if (detachedPrefab != null)
                //        {
                //            detachedPrefab.transform.parent = null;
                //        }
                //    }
                //    Destroy(gameObject);
                //    return;
                //}

                Vector3 forward = enemy.transform.position - transform.position;
                Vector3 crossDirection = Vector3.Cross(forward, Vector3.up);
                Quaternion randomDeltaRotation = Quaternion.Euler(0, randomSideAngle, 0) * Quaternion.AngleAxis(randomUpAngle, crossDirection);
                Vector3 direction = randomDeltaRotation * enemy.transform.position - transform.position;



                float distanceThisFrame = Time.deltaTime * 55f;
                transform.Translate(direction.normalized * distanceThisFrame, Space.World);
                transform.rotation = Quaternion.LookRotation(direction);
            }
            else
            {
                float distanceThisFrame = Time.deltaTime * 1000f;
                //transform.Translate(Vector3.forward * distanceThisFrame, Space.World);
                rigid.velocity = transform.forward * 50f;
            }
        }
        
    }

    void newRandom()
    {
        randomUpAngle = Random.Range(0, upAngle);
        randomSideAngle = Random.Range(-sideAngle, sideAngle);
    }
    void FlashEffect()
    {
        if (Flash != null)
        {
            var flashInstance = Instantiate(Flash, transform.position, Quaternion.identity);
            flashInstance.transform.forward = gameObject.transform.forward;
            var flashPs = flashInstance.GetComponent<ParticleSystem>();
            if (flashPs != null)
            {
                Destroy(flashInstance, flashPs.main.duration);
            }
            else
            {
                var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(flashInstance, flashPsParts.main.duration);
            }
        }
    }

   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if(hit != null) Instantiate(hit, transform);
            Destroy(gameObject);
        }
    }

    public void WaitDestory()
    {
        Destroy(gameObject);
    }

    /*
     * 
    void Update()
    {
        if (target == null)
        {
            foreach (var detachedPrefab in Detached)
            {
                if (detachedPrefab != null)
                {
                    detachedPrefab.transform.parent = null;
                }
            }
            Destroy(gameObject);
            return;
        }

        Vector3 forward = ((target.position + targetOffset) - transform.position);
        Vector3 crossDirection = Vector3.Cross(forward, Vector3.up);
        Quaternion randomDeltaRotation = Quaternion.Euler(0, randomSideAngle, 0) * Quaternion.AngleAxis(randomUpAngle, crossDirection);
        Vector3 direction = randomDeltaRotation * ((target.position + targetOffset) - transform.position);

        float distanceThisFrame = Time.deltaTime * speed;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.rotation = Quaternion.LookRotation(direction);
    }
     */
}
