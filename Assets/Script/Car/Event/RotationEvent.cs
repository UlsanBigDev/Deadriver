using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEvent : DrunkEvent
{   
    public override void Run()
    {
        Debug.Log("���� ��鸵 ���� �̺�Ʈ");
        Car.rotationSpeed = 200f;
    }
}
