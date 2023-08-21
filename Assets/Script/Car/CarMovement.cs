using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement 
{
    public static float currentSpeed = 0f;
    private float decelSpeed = 10f;
    private float maxSpeed = 50f;    
    public static Rigidbody rb;
    public static Transform currentTransform;

    public CarMovement(Transform transform)
    {
        currentTransform = transform;
        rb = transform.GetComponent<Rigidbody>();
    }
    private void UpCurrentSpeed() //앞으로 갈 때 속도가 점점 증가
    {
        currentSpeed += Car.playerAccelSpeed * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
    }

    private void DownCurrentSpeed() //뒤로 갈 때 속도 감소
    {
        currentSpeed -= decelSpeed * Time.deltaTime;
        currentSpeed = Mathf.Max(currentSpeed, 0f); // decelSpeed 로 currentSpeed 값 감소를 최대 0f 까지만 감소하게 함
    }
    public void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        /*Debug.Log(rb.transform.forward);*/
        /*rb.AddForce(currentTransform.forward, ForceMode.Force);*/
        if (Input.GetKey(KeyCode.W)) //W키를 눌러서 앞으로 이동
        {
            rb.AddForce(currentTransform.forward * Car.playerAccelSpeed * Time.deltaTime, ForceMode.VelocityChange );
        }


        if (Input.GetKey(KeyCode.S)) //S키를 눌러서 뒤로 이동
        {
            rb.AddForce(currentTransform.forward * -1 * Car.playerAccelSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }



        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.S) && currentSpeed > 0) {
                DownCurrentSpeed();
            } else {
                UpCurrentSpeed();
            }
            
        }
        Debug.Log(currentSpeed);

        Vector3 movement = currentTransform.forward * v * currentSpeed;

        if (Car.isDirectionDragEvent == true) //W -> 뒤로, S -> 앞으로
        {
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z) * -1;
        }
        else
        {
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        }*/


        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            currentSpeed += Car.playerAccelSpeed * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // 최대 속도 제한
        }
        else
        {
            currentSpeed -= decelSpeed * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0f); // decelSpeed 로 currentSpeed 값 감소를 최대 0f 까지만 감소하게 함
        }
        // 자동차 앞뒤 이동
        Vector3 movement = currentTransform.forward * v * currentSpeed;

        if (Car.isDirectionDragEvent == true) //W -> 뒤로, S -> 앞으로
        {
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z) * -1;
        }
        else
        {
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        }
        // velocity 는 Rigidbody 를 통해 게임 오브젝트의 속도를 나타내는 속성임. 속도 벡터는 물체의 이동 방향과 속도를 포함함.

        */


        // 자동차 회전
        // 쿼터니언, 오일러각
        float rotation = h * Car.rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
