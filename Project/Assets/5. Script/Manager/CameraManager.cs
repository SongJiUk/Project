using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Player player;


    float distance = 6f; // 카메라와 캐릭터 사이의 거리
    float height = 4f; // 카메라의 높이 설정

    public float smoothSpeed = 0.125f; 

    private void Start()
    {
        if (null == player) player = Player.GetInstance;

    }

  

    private void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position - (player.transform.forward * distance) + (Vector3.up * height);
        transform.position = targetPosition;


        transform.LookAt(player.transform.position);


        //선형보간 이용( 좀이상)
        //Vector3 desiredPosition = player.transform.position + targetPosition;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        //transform.LookAt(player.transform);
    }
}
