using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuMovement : MonoBehaviour
{
    private float currentSpeed = 0f;
    private float accelSpeed = 2f;
    private float decelSpeed = 10f;
    private float maxSpeed = 50f;
    private float rotationSpeed = 100f;
    private Rigidbody rb;
    private bool isAccel = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // 수직 수평 입력값 가져오는거
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += accelSpeed * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // 최대 속도 제한
        }
        else if (Input.GetKey(KeyCode.S)) // ?????????????????? 정지상태에서 왜 후진하면 차가 뒤로 자빠지는지 모르겠음
        {
            // 여기 지금 이상해서 안돌아감;;
            currentSpeed += accelSpeed * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // 최대 속도 제한
        }
        else
        {
            currentSpeed -= decelSpeed * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0f);
        }

        // 자동차 앞뒤 이동
        Vector3 movement = transform.forward * v * currentSpeed;
        // velocity 는 Rigidbody 를 통해 게임 오브젝트의 속도를 나타내는 속성임. 속도 벡터는 물체의 이동 방향과 속도를 포함함.
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // 자동차 회전
        // 쿼터니언, 오일러각
        float rotation = h * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);

    }
}
