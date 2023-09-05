using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Player player;


    float distance = 6f; // 카메라와 캐릭터 사이의 거리
    float height = 4f; // 카메라의 높이 설정

    public float smoothSpeed = 0.125f; // 카메라 이동 속도
    public Vector3 offset; // 초기 위치 오프셋

    private void Start()
    {
        if (null == player) player = Player.GetInstance;

    }

  

    private void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position - (player.transform.forward * distance) + (Vector3.up * height);
        transform.position = targetPosition;


        transform.LookAt(player.transform.position);

        //Vector3 desiredPosition = player.transform.position + targetPosition;

        //// 부드러운 이동을 위한 보간
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        //// 카메라 위치 업데이트
        //transform.position = smoothedPosition;

        //// 카메라가 캐릭터를 바라보도록 회전 설정
        //transform.LookAt(player.transform);
    }
}
