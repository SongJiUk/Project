using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriviewLongDistance : MonoBehaviour
{
    private void Start()
    {
        Invoke("OnDestroy", 1f);
    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.5f);
    }
}
