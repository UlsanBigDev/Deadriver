using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuMovement : MonoBehaviour
{
    public static float currentSpeed = 0f;
    private float accelSpeed = 2f;
    private float decelSpeed = 10f;
    private float maxSpeed = 50f;
    public static float rotationSpeed = 100f;
    public static Rigidbody rb;
    private DirectionDrag directionDrag;
    private PedestrianDrag pedestrianDrag;
    private bool isAccel = false;

    public int cnt;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cnt = 0;
        directionDrag = new DirectionDrag(transform);
    }

    void Update()
    {
        // ���� ���� �Է°� �������°�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
                currentSpeed += accelSpeed * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // �ִ� �ӵ� ����
        }
        else if (Input.GetKey(KeyCode.S)) // ?????????????????? �������¿��� �� �����ϸ� ���� �ڷ� �ں������� �𸣰���
        {
            // ���� ���� �̻��ؼ� �ȵ��ư�;;
            currentSpeed += accelSpeed * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // �ִ� �ӵ� ����
        }
        else
        {
            currentSpeed -= decelSpeed * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0f); // decelSpeed �� currentSpeed �� ���Ҹ� �ִ� 0f ������ �����ϰ� ��
        }

        // �ڵ��� �յ� �̵�
        Vector3 movement = transform.forward * v * currentSpeed;
        // velocity �� Rigidbody �� ���� ���� ������Ʈ�� �ӵ��� ��Ÿ���� �Ӽ���. �ӵ� ���ʹ� ��ü�� �̵� ����� �ӵ��� ������.
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // �ڵ��� ȸ��
        // ���ʹϾ�, ���Ϸ���
        float rotation = h * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}