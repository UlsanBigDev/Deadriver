using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCar : AbstractCar
{
    public int carDamage = 10;
    private bool delayedDamage = false;
    private void OnCollisionEnter(Collision collision) // 충돌이 일어나자 마자
    {
        if (collision.gameObject.CompareTag("building")) // building 이라는 tag 를 가진 오브젝트와 충돌했을때, CompareTag = 자바 Equals랑 비슷한 느낌?
        {
            if (!delayedDamage)
            {
                Invoke("DelayedCarDamage", 1f);
                delayedDamage = true;
            }
        }
    }
    private void DelayedCarDamage()
    {
        CarDamage(carDamage);
        delayedDamage = false;
    }
}