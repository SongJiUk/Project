using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDistanceAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }
    Vector3 startpos;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if(WeaponManager.GetInstance.Weapondata != null)
        {
            if (WeaponManager.GetInstance.Weapondata.playerjob == PlayerJobs.Mage)
            {
                var enemy = FindObjectOfType<Enemy>();
                timer += Time.deltaTime;

                
                Vector3 pos = transform.position;
                pos.y = Mathf.Sin(timer) * 3f;
                transform.position = Vector3.Lerp(startpos, enemy.transform.position + Vector3.up, timer * 0.4f);
                transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);


                Vector3 dis = (enemy.transform.position + Vector3.up - transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(dis);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
            //Invoke("WaitDestory", 0.5f);
        }
    }

    public void WaitDestory()
    {
        Destroy(gameObject);
    }
}
