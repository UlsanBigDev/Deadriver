using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEvent : DrunkEvent
{
    ObstacleObject obstacleObject;

    void Awake()
    {
        obstacleObject = new ObstacleObject();
    }

    public override void Run()
    {
        //Run을 통해서 obstacle의 함수를 실행시킴
        Debug.Log("방해물 디버프");
        Debug.Log(Car.Level);
        //obstacleObject.obstacle();
    }
}
