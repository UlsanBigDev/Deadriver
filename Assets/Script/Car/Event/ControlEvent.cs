using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEvent : DrunkEvent
{
    public override void Run()
    {
        Car.isDirectionDragEvent = true;
        Debug.Log("조작키 반대 디버프");
    }
}
