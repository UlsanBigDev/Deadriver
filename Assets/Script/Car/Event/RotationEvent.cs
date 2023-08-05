using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEvent : DrunkEvent
{   
    public override void Run()
    {
        Debug.Log("대충 헨들링 관련 이벤트");
        Car.rotationSpeed = 200f;
    }
}
