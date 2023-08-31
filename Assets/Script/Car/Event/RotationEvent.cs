using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEvent : DrunkEvent //회전속도 증가 디버프
{
    DrunkLevel level = Player.GetPlayer().drunkLevel;

    public override void Run()
    {
        if (level == DrunkLevel.YELLOW)
        {
            Car.playerAccelSpeed = 15f;
            Debug.Log("YELLOW 회전속력");
        }
        else if (level == DrunkLevel.ORANGE)
        {
            Car.playerAccelSpeed = 35f;
            Debug.Log("ORANGE 회전속력");
        }
        else if (level == DrunkLevel.RED)
        {
            Car.playerAccelSpeed = 50f;
            Debug.Log("RED 회전속력");
        }
    }
}
