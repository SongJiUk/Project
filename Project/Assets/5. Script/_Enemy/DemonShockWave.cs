using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonShockWave : MonoBehaviour
{
    void Start()
    {
        Invoke("ShockWaveDestroy", 4f);
    }

    void ShockWaveDestroy()
    {
        Destroy(gameObject);
    }
}
