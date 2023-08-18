using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RashEvent : DrunkEvent
{ 
    DrunkLevel level = Player.GetPlayer().drunkLevel;
    
    public override void Run()
    {
        if (level == DrunkLevel.GREEN)
        {
            Car.playerAccelSpeed = 10f;
            Debug.Log("GREEN 급발진");
        }
        else if (level == DrunkLevel.YELLOW)
        {
            //Car.playerAccelSpeed = 10f;
            Debug.Log("YELLOW 급발진");
        }
        else if (level == DrunkLevel.ORANGE)
        {
            //Car.playerAccelSpeed = 10f;
            Debug.Log("ORANGE 급발진");
        }
        else if (level == DrunkLevel.RED)
        {
            //Car.playerAccelSpeed = 10f;
            Debug.Log("RED 급발진");
        }
       
    }
}


