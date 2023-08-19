using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEvent : DrunkEvent
{
    DrunkLevel level = Player.GetPlayer().drunkLevel;

    public override void Run()
    {
        if (level == DrunkLevel.GREEN)
        {
            Car.playerAccelSpeed = 10f;
            Debug.Log("GREEN 회전속력");
        }
        else if (level == DrunkLevel.YELLOW)
        {
            Car.playerAccelSpeed = 15f;
            Debug.Log("YELLOW 회전속력");
        }
        else if (level == DrunkLevel.ORANGE)
        {
            Car.playerAccelSpeed = 20f;
            Debug.Log("ORANGE 회전속력");
        }
        else if (level == DrunkLevel.RED)
        {
            Car.playerAccelSpeed = 25f;
            Debug.Log("RED 회전속력");
        }
    }
}
