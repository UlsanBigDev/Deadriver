using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCar : AbstractCar
{
    public int carDamage = 10;
    private bool delayedDamage = false;
    private void OnCollisionEnter(Collision collision) // �浹�� �Ͼ�� ����
    {
        if (collision.gameObject.CompareTag("building")) // building �̶�� tag �� ���� ������Ʈ�� �浹������, CompareTag = �ڹ� Equals�� ����� ����?
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