using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCar : AbstractCar
{
    public int carDamage;
    private bool delayedDamage = false;

    private void OnCollisionEnter(Collision collision) // 충돌이 일어나자 마자
    {
        if (collision.gameObject.CompareTag("building")) // building 이라는 tag 를 가진 오브젝트와 충돌했을때, CompareTag = 자바 Equals랑 비슷한 느낌?
        {
            if (!delayedDamage)
            {
                //soundManager.SfxPlay(SoundManager.Sfx.crashBuiling);
                carDamage = 10;
                Debug.Log(carDamage);
                StartCoroutine(DamageDelay(carDamage, 1f)); //코루틴으로 순간적으로 충돌이 중복적으로 일어나는 현상을 방지하기 위해 최소한의 딜레이값 설정필요함
            }
        }
        else if (collision.gameObject.CompareTag("CarDrag"))
        {
            if (!delayedDamage)
            {
                //soundManager.SfxPlay(SoundManager.Sfx.crashBuiling);
                carDamage = 5;
                Debug.Log(carDamage);
                StartCoroutine(DamageDelay(carDamage, 1f)); //코루틴으로 순간적으로 충돌이 중복적으로 일어나는 현상을 방지하기 위해 최소한의 딜레이값 설정필요함
            }
        }else if (collision.gameObject.CompareTag("Person"))
        {
            if (!delayedDamage)
            {
                //soundManager.SfxPlay(SoundManager.Sfx.crashBuiling);
                carDamage = 1;
                Debug.Log(carDamage);
                StartCoroutine(DamageDelay(carDamage, 1f)); //코루틴으로 순간적으로 충돌이 중복적으로 일어나는 현상을 방지하기 위해 최소한의 딜레이값 설정필요함
            }
        }
    }
    private IEnumerator DamageDelay(int carDamage, float delay)
    {
        delayedDamage = true;
        CarDamage(carDamage); //Invoke 함수 썼을때는 박자마자 Log 출력 안되고 1초 딜레이가 처음부터 걸려버림 그래서 박자마자 실행후
        yield return new WaitForSeconds(delay); // 딜레이를 걸어줌
        delayedDamage = false;
    }
}