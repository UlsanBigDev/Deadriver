using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RashEvent : DrunkEvent
{
    public override void Run()
    {   
        Car.playerAccelSpeed = 5f;
        Debug.Log("���� �޹��� �ϴ� �Լ�");
    }
}
