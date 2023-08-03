
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarReset : MonoBehaviour
{
    private Vector3 initPosition; // ��ġ
    private Quaternion initRotation; // ȸ����
    void Awake()
    {
        // �ڵ����� ������ġ�� ȸ������ �̸� ����
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

    private void ResetCar() // ���� ó������ ���ư��°�
    {
        transform.position = initPosition; // �ڵ����� ��ġ �ʱ�ȭ
        transform.rotation = initRotation; // �ڵ����� ȸ���� �ʱ�ȭ

        Rigidbody carRb = GetComponent<Rigidbody>(); 
        if(carRb != null )
        {
            carRb.velocity = Vector3.zero;
            carRb.angularVelocity = Vector3.zero;
        }
    }
}
