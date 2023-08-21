using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEvent : DrunkEvent //조작키 디버프
{
    public override void Run()
    {
        Car.isDirectionDragEvent = true;
        Debug.Log("조작키 반대 디버프");
    }
}
