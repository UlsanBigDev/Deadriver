using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCar : MonoBehaviour, Car
{
    public bool isPlayer { get; set; }
    public float speed { get; set; }
    public float rotation { get; set; }
    public int carHp { get; set; }

    private PlayerCarMovement playerCarMovement;

    private void Awake()
    {
        Car.Level = 15; 
        Car.carHp = 100; //초기Hp 100으로 초기화
        Car.playerAccelSpeed = 5f; // 5f로 해야 문제없이 후진까지 가능함
        Car.rotationSpeed = 100f;
        playerCarMovement = new PlayerCarMovement(transform);
    }

    private void Start() //foreach문으로 Car.drunkEvents 리스트에서 각각 해당하는 Run을 실행시킴
    {
        foreach(DrunkEvent drunkEvent in Car.drunkEvents) {
            drunkEvent.Run();
        }
    }

    private void FixedUpdate()
    {
        playerCarMovement.Update();
    }

    public void CarDamage(int carDamage)
    {
        Car.carHp -= carDamage;
        Debug.Log("차의 HP가 -10 감소되었습니다.");
        Debug.Log("현재 차량의 hp = " + Car.carHp);
        if (Car.carHp <= 0)
        {
            Debug.Log("님 차 터짐 ㅅㄱㅃ2");
            DestroyCar();
        }
    }
    private void DestroyCar()
    {
        Destroy(this);
    }
}

public class PlayerCarMovement
{
    public static float currentSpeed = 0f;
    private float decelSpeed = 10f;
    private float maxSpeed = 50f;
    /*public static float rotationSpeed = 100f;*/
    public static Rigidbody rb;
    /*private DirectionDrag directionDrag;
    private PedestrianDrag pedestrianDrag;
    private bool isAccel = false;*/

    public static Transform currentTransform;

    public PlayerCarMovement() { }
    public PlayerCarMovement(Transform transform)
    {   
        currentTransform = transform;
        rb = transform.GetComponent<Rigidbody>();
        /*directionDrag = new DirectionDrag(transform);*/
    }
    public void Update()
    {
        Debug.Log(Car.playerAccelSpeed);
        // 수직 수평 입력값 가져오는거
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S))
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
        

        // 자동차 회전
        // 쿼터니언, 오일러각
        float rotation = h * Car.rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}