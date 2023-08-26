using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
public interface CrashListener
{
    public void OnCrash(Enemy enemey);
}
public abstract class AbstractCar : MonoBehaviour, Car
{
    

    public bool isPlayer { get; set; }
    public float speed { get; set; }
    public float rotation { get; set; }
    public int carHp { get; set; }
    public int carDamage;
    public int total;
    private bool delayedDamage = false;
    public static int carint, personint, buildingint;
    public TextMeshProUGUI person;
    public TextMeshProUGUI building;
    public TextMeshProUGUI car;
    public Image informaitionPanel;
    public Text carDamageText, alcoholText, crimeText, scoreText;
    //public Animator anim;

    public DriveSceneSoundManager driveSceneSoundManager;
    private CarMovement carMovement;

    [SerializeField]
    private CarNavigation carNavigation;

    private void Awake()
    {
        InitializeVariable();
        DrunkEventRun();
    }

    private void DrunkEventRun()
    {
        foreach (DrunkEvent drunkEvent in Car.drunkEvents)
        {   
            drunkEvent.Run();
        }
    }

    private void InitializeVariable()
    {
        Car.Level = 1;
        Car.carHp = 100;
        Car.playerAccelSpeed = 10f;
        Car.rotationSpeed = 100f;
        carMovement = new CarMovement(transform);
        carNavigation.Init();
        driveSceneSoundManager = FindObjectOfType<DriveSceneSoundManager>();
        carint = 0;
        personint = 0;
        buildingint = 0;
    }

    private void Start() //foreach문으로 Car.drunkEvents 리스트에서 각각 해당하는 Run을 실행시킴
    {   
        person.text = "보행자 충돌 " + personint;
        car.text = "차량 충돌 " + carint;
        building.text = "빌딩 충돌 " + buildingint;
    }

    private void Update()
    {
        carNavigation.DrawLIne();
    }

    private void FixedUpdate()
    {
        carMovement.Update();
    }


    public void CarDamage(int carDamage) 
    {
        Car.carHp -= carDamage;
        Debug.Log("현재 차량의 hp = " + Car.carHp);
        if (Car.carHp <= 0)
        {
            Debug.Log("님 차 터짐 ㅅㄱㅃ2");
            driveSceneSoundManager.bgmPlayer.Stop();
            driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.over);
            DestroyCar();
        }
    }

    private void DestroyCar()
    { 
        Destroy(this);
    }

    /// <summary>
    /// Enemy 와 충돌 햇을때 호
    /// </summary>
    protected void OnEnemyCrash(Enemy enemy) //부딪힌 객체에 따라서 HP 감소 - 부딪히는 객체에 따라서 carDamage의 값을 변경해주는 코드
    {
        if (delayedDamage) return;
        foreach (CrashListener listener in Car.crashListeners)
        {
            listener.OnCrash(enemy);
        }
        if (enemy is Building)
        {
            driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.crashBuiling);
            Debug.Log("차의 HP가 -5 감소되었습니다.");
            Debug.Log("현재 차량의 hp = " + Car.carHp);
            carDamage = 5;
            buildingint++;
            total++;
            building.text = "빌딩 충돌 " + buildingint;
        }
        else if (enemy is EnemyCar)
        {
            driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.crashCar);
            Debug.Log("차의 HP가 -3 감소되었습니다.");
            Debug.Log("현재 차량의 hp = " + Car.carHp);
            carDamage = 3;
            carint++;
            total++;
            car.text = "차량 충돌 " + carint;
        }
        else if (enemy is Person)
        {
            driveSceneSoundManager.SfxPlay(DriveSceneSoundManager.Sfx.crashPersonWomen);
            Debug.Log("차의 HP가 -1 감소되었습니다.");
            Debug.Log("현재 차량의 hp = " + Car.carHp);
            carDamage = 1;
            personint++;
            total++;
            person.text = "보행자 충돌 " + personint;
        }
        StartCoroutine(DamageDelay(carDamage, 0.5f));
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("endPoint")) //OnEnemyCrash 함수로 부딪힌 객체가 어떤 객체인지 정보를 넘겨줌
        {
            informaitionPanel.gameObject.SetActive(false);
            //carDamageText.text = "차량 손상도 : " + Car.carHp;
            //crimeText.text = "총 사고 이력 : " + total + "번";
            //alcoholText.text = "혈중 알콜 농도 : " + (Player.GetPlayer().drunkGauge / 1000.0f).ToString("F3") + "%";
            GameManager.GameEnd();
            //anim.SetBool("Result", true);
            //GameManager.GameEnd();          
            //Debug.Log("결과창 나옴");
        }
    }


    private void OnCollisionEnter(Collision collision) // 충돌이 일어나자 마자
    {
        if (collision.gameObject.CompareTag("Enemy")) //OnEnemyCrash 함수로 부딪힌 객체가 어떤 객체인지 정보를 넘겨줌
        {
            OnEnemyCrash(collision.gameObject.GetComponent<Enemy>());
        }
        //if (collision.gameObject.CompareTag("building")) // building 이라는 tag 를 가진 오브젝트와 충돌했을때, CompareTag = 자바 Equals랑 비슷한 느낌?
        //{
        //    if (!delayedDamage)
        //    {
        //        //soundManager.SfxPlay(SoundManager.Sfx.crashBuiling);
        //        carDamage = 10;
        //        Debug.Log(carDamage);
        //        StartCoroutine(DamageDelay(carDamage, 1f)); //코루틴으로 순간적으로 충돌이 중복적으로 일어나는 현상을 방지하기 위해 최소한의 딜레이값 설정필요함
        //    }
        //}
        //else if (collision.gameObject.CompareTag("EnemyCar"))
        //{
        //    if (!delayedDamage)
        //    {
        //        //soundManager.SfxPlay(SoundManager.Sfx.crashBuiling);
        //        carDamage = 5;
        //        Debug.Log(carDamage);
        //        StartCoroutine(DamageDelay(carDamage, 1f)); //코루틴으로 순간적으로 충돌이 중복적으로 일어나는 현상을 방지하기 위해 최소한의 딜레이값 설정필요함
        //    }
        //}
        //else if (collision.gameObject.CompareTag("Person"))
        //{
        //    if (!delayedDamage)
        //    {
        //        //soundManager.SfxPlay(SoundManager.Sfx.crashBuiling);
        //        carDamage = 1;
        //        Debug.Log(carDamage);
        //        StartCoroutine(DamageDelay(carDamage, 1f)); //코루틴으로 순간적으로 충돌이 중복적으로 일어나는 현상을 방지하기 위해 최소한의 딜레이값 설정필요함
        //    }
        //}
    }
    private IEnumerator DamageDelay(int carDamage, float delay)
    {
        delayedDamage = true;
        CarDamage(carDamage); //Invoke 함수 썼을때는 박자마자 Log 출력 안되고 1초 딜레이가 처음부터 걸려버림 그래서 박자마자 실행후
        yield return new WaitForSeconds(delay); // 딜레이를 걸어줌
        delayedDamage = false;
    }
}