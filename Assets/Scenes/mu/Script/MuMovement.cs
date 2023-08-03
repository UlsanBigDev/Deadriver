using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuMovement : MonoBehaviour
{
    private float currentSpeed = 0f;
    private float accelSpeed = 2f;
    private float decelSpeed = 10f;
    private float maxSpeed = 50f;
    public static float rotationSpeed = 100f;
    private Rigidbody rb;
<<<<<<< HEAD
    private bool isAccel = false;
=======

    public Text textText;
    public int cnt;

>>>>>>> 8b3f3237d8da6295baf04e86d71adc57293595dc
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cnt = 0;
    }
    void Update()
    {
        // ���� ���� �Է°� �������°�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            if (isAccel)
            {
                currentSpeed += accelSpeed * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // �ִ� �ӵ� ����
            }
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
        cnt++;
        Debug.Log(cnt);
        if (cnt > 0 && 1000 > cnt)
        {
            Debug.Log("1�ܰ�");
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
        else if(cnt >= 1000 && 2000 > cnt) //����Ű�� �ݴ��
        {
            Debug.Log("2�ܰ�");
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z) * -1;
        }else if (cnt >= 2000)//����Ű�� �ݴ�� �ϸ鼭 ȸ���ӵ��� ����
        {
            Debug.Log("3�ܰ�");
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z) * -1;
            DirectionDrag.SpeedRotation();
        }
        

        // �ڵ��� ȸ��
        // ���ʹϾ�, ���Ϸ���
        float rotation = h * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
