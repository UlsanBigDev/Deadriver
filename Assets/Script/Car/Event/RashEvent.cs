using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RashEvent : DrunkEvent
{
    public override void Run()
    {   
        Car.playerAccelSpeed = 5f;
        Debug.Log("대충 급발진 하는 함수");
    }
}
