
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarReset : MonoBehaviour
{
    private Vector3 initPosition; // 위치
    private Quaternion initRotation; // 회전값
    void Awake()
    {
        // 자동차의 시작위치와 회전값을 미리 저장
        initPosition = transform.position;
        initRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCar();
        }
    }

    private void ResetCar() // 완전 처음으로 돌아가는거
    {
        transform.position = initPosition; // 자동차의 위치 초기화
        transform.rotation = initRotation; // 자동차의 회전값 초기화

        Rigidbody carRb = GetComponent<Rigidbody>(); 
        if(carRb != null )
        {
            carRb.velocity = Vector3.zero;
            carRb.angularVelocity = Vector3.zero;
        }
    }
}
