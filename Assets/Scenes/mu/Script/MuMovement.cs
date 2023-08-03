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
        // 수직 수평 입력값 가져오는거
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            if (isAccel)
            {
                currentSpeed += accelSpeed * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // 최대 속도 제한
            }
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
            currentSpeed = Mathf.Max(currentSpeed, 0f); // decelSpeed 로 currentSpeed 값 감소를 최대 0f 까지만 감소하게 함
        }

        // 자동차 앞뒤 이동
        Vector3 movement = transform.forward * v * currentSpeed;
        // velocity 는 Rigidbody 를 통해 게임 오브젝트의 속도를 나타내는 속성임. 속도 벡터는 물체의 이동 방향과 속도를 포함함.
        cnt++;
        Debug.Log(cnt);
        if (cnt > 0 && 1000 > cnt)
        {
            Debug.Log("1단계");
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
        else if(cnt >= 1000 && 2000 > cnt) //방향키를 반대로
        {
            Debug.Log("2단계");
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z) * -1;
        }else if (cnt >= 2000)//방향키를 반대로 하면서 회전속도를 높임
        {
            Debug.Log("3단계");
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z) * -1;
            DirectionDrag.SpeedRotation();
        }
        

        // 자동차 회전
        // 쿼터니언, 오일러각
        float rotation = h * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
