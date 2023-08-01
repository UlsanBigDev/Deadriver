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
        // 수직 수평 입력값 가져오는거
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 자동차 앞뒤 이동
        Vector3 movement = transform.forward * verticalInput * speed;
        // velocity 는 Rigidbody 를 통해 게임 오브젝트의 속도를 나타내는 속성임. 속도 벡터는 물체의 이동 방향과 속도를 포함함.
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // 자동차 회전
        // 쿼터니언, 오일러각
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);

    }
}
