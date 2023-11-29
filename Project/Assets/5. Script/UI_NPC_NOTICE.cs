using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_NPC_NOTICE : MonoBehaviour
{

    Camera camera;


    Vector3 direction;
    private void OnEnable()
    {
        camera = Camera.main;

        // 텍스트의 방향을 카메라를 향하도록 설정합니다.
        direction = camera.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform.position);
    }
}
