using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    Player player;
    Vector3 Dir;
    void Start()
    {
        Invoke("DestroyBall", 5f);
        player = Player.GetInstance;

        Dir = (player.transform.position + Vector3.up * 1) - (transform.position);

    }

    void DestroyBall()
    {
        if (gameObject.activeSelf)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.position += Dir * Time.deltaTime * 1.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("거미거미");
    }
}
