using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractCar : MonoBehaviour, Car
{
    public bool isPlayer { get; set; }
    public float speed { get; set; }
    public float rotation { get; set; }
    public int carHp { get; set; }

    public SoundManager soundManager;
    private CarMovement carMovement;

    [SerializeField]
    private CarNavigation carNavigation;

    private void Awake()
    {
        Car.Level = 1; 
        Car.carHp = 100; //초기Hp 100으로 초기화
        /*
          5f로 해야 문제없이 후진까지 가능함
          23.08.15 전진 후진 가속도 이슈 수정이후 5f는 너무 느려서 값
        */
        Car.playerAccelSpeed = 10f; 
        Car.rotationSpeed = 100f;
        carMovement = new CarMovement(transform);
        carNavigation.Init();
        soundManager = FindObjectOfType<SoundManager>();
    }
 
    private void Start() //foreach문으로 Car.drunkEvents 리스트에서 각각 해당하는 Run을 실행시킴
    {
        foreach (DrunkEvent drunkEvent in Car.drunkEvents) {
            drunkEvent.Run();
        }        
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
        Debug.Log("차의 HP가 -10 감소되었습니다.");
        Debug.Log("현재 차량의 hp = " + Car.carHp);
        if (Car.carHp <= 0)
        {
            Debug.Log("님 차 터짐 ㅅㄱㅃ2");
            soundManager.bgmPlayer.Stop();
            soundManager.SfxPlay(SoundManager.Sfx.over);
            DestroyCar();
        }
    }
    private void DestroyCar()
    {
        Destroy(this);
    }

}