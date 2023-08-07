using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCar : AbstractCar
{
    public int carDamage = 10;

    private void OnCollisionEnter(Collision collision) // �浹�� �Ͼ�� ����
    {
        if (collision.gameObject.CompareTag("building")) // building �̶�� tag �� ���� ������Ʈ�� �浹������, CompareTag = �ڹ� Equals�� ����� ����?
        {
            CarDamage(1);
        }
    }
}
