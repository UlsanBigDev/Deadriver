using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RashEvent : DrunkEvent //가속도 디버프 
{ 
    DrunkLevel level = Player.GetPlayer().drunkLevel;
    
    public override void Run()
    {
        if (level == DrunkLevel.YELLOW)
        {
            Car.playerAccelSpeed = 15f;
            Debug.Log("YELLOW 급발진");
        }
        else if (level == DrunkLevel.ORANGE)
        {
            Car.playerAccelSpeed = 35f;
            Debug.Log("ORANGE 급발진");
        }
        else if (level == DrunkLevel.RED)
        {
            Car.playerAccelSpeed = 60f;
            Debug.Log("RED 급발진");
        }
       
    }
}


