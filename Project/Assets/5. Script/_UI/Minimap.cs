using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField]
    private bool x, y, z;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private GameObject targetCamMiniMap;

    [SerializeField]
    private Transform targetMainCam;

    private void Update()
    {
        if (!target) return;
        if (!targetCamMiniMap) return;
        if (!targetMainCam) return;

        transform.position = new Vector3(
            (x ? target.position.x : transform.position.x),
            (y ? target.position.y : transform.position.y),
            (z ? target.position.z : transform.position.z));

        Vector3 dir = targetMainCam.position - targetCamMiniMap.transform.position;
        dir.y = 0f;
        Quaternion rot = Quaternion.LookRotation(dir.normalized);


        targetCamMiniMap.transform.rotation = rot;

    }
}
