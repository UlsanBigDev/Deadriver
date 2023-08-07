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
                StartCoroutine(DamageDelay(carDamage, 1f)); //�ڷ�ƾ���� ���������� �浹�� �ߺ������� �Ͼ�� ������ �����ϱ� ���� �ּ����� �����̰� �����ʿ���
            }
        }
    }
    private IEnumerator DamageDelay(int carDamage, float delay)
    {
        delayedDamage = true;
        CarDamage(carDamage); //Invoke �Լ� �������� ���ڸ��� Log ��� �ȵǰ� 1�� �����̰� ó������ �ɷ����� �׷��� ���ڸ��� ������
        yield return new WaitForSeconds(delay); // �����̸� �ɾ���
        delayedDamage = false;
    }
}