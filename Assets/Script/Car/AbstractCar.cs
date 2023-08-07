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
    private ControlEvent controlEvent;

    private void Awake()
    {
        Car.carHp = 100; //�ʱ�Hp 100���� �ʱ�ȭ
        Car.playerAccelSpeed = 2f; // �׳� ����Ʈ�� �ʱ�ȭ..
        Car.rotationSpeed = 100f;
        playerCarMovement = new PlayerCarMovement(transform);
        controlEvent = new ControlEvent(transform);
    }

    private void Start() //foreach������ Car.drunkEvents ����Ʈ���� ���� �ش��ϴ� Run�� �����Ŵ
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
        Debug.Log("���� HP�� -10 ���ҵǾ����ϴ�.");
        Debug.Log("���� ������ hp = " + Car.carHp);
    }
}

public class PlayerCarMovement
{
    public static float currentSpeed = 0f;
    private float accelSpeed;
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
        accelSpeed = Car.playerAccelSpeed;
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
        Vector3 movement = currentTransform.forward * v * currentSpeed;
        // velocity �� Rigidbody �� ���� ���� ������Ʈ�� �ӵ��� ��Ÿ���� �Ӽ���. �ӵ� ���ʹ� ��ü�� �̵� ����� �ӵ��� ������.
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // �ڵ��� ȸ��
        // ���ʹϾ�, ���Ϸ���
        float rotation = h * Car.rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
