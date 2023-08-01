using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuMovement : MonoBehaviour
{
    private float speed = 5f;
    private float rotationSpeed = 60.0f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // ���� ���� �Է°� �������°�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �ڵ��� �յ� �̵�
        Vector3 movement = transform.forward * verticalInput * speed;
        // velocity �� Rigidbody �� ���� ���� ������Ʈ�� �ӵ��� ��Ÿ���� �Ӽ���. �ӵ� ���ʹ� ��ü�� �̵� ����� �ӵ��� ������.
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // �ڵ��� ȸ��
        // ���ʹϾ�, ���Ϸ���
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);

    }
}
