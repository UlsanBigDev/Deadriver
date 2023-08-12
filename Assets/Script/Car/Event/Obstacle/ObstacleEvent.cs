using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObstacleEvent : DrunkEvent
{
    //변수가 GameObject로 선언되면 GetComponetsInChildren을 사용 불가능
    //Transform으로 선언 시 SetActive를 사용 불가능

    public Transform gameObjectGroup;
    
    public ObstacleEvent(Transform gameObjectGroup) { 
        this.gameObjectGroup = gameObjectGroup;
    }

    public void obstacle()
    {
        //Debug.Log(gameObjectGroup);
        //gameObjects = gameObjectGroup.GetComponentsInChildren<Transform>(true);
        //GetComponentInChildren을 0번째 자식 요소만 받아옴
        //GetComponentsInChildren은 모든 자식에 대해서 받아옴
        //GameObject는 Component를 받아올 수 없음

        Debug.Log("장애물 디버프");

        //for(int i = 0; i< this.transform.childCount)
    }

    public override void Run()
    {
        obstacle();
    }
}
