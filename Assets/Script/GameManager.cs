using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake() //������� drunkEvents ����Ʈ�� �߰�(Add)����
    { 
      //Start�� �ϸ� AbstractCar ��ũ��Ʈ������ Start���� foreach������ ����Ʈ�� Run�� ȣ���ϴ°Ŷ�
      //���⼭ Add�ϴ� �Ŷ� ���ÿ� �Ͼ�� ������ Add�� ���� ���� �Ŀ� ����Ʈ�� Run���� ȣ���ؾ��ϴϱ� ����� Awake��
      /* Awake( ����Ʈ�� Add ) -> Start( ����Ʈ�� Add �� ���鿡 �ش��ϴ� Run�� ���� ) */
        Car.AddDrunkEvent(new RashEvent());
        Car.AddDrunkEvent(new RotationEvent());
        Car.AddDrunkEvent(new ControlEvent());
    }
}
