using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEvent : DrunkEvent
{
    private GameObject dragPrefab;

    private Transform[] gameObjectGroup; //장애물들이 생성될 위치를을 배열에 저장

    DrunkLevel level = Player.GetPlayer().drunkLevel; //난이도 받아옴

    public ObstacleEvent(Transform[] pointArray,GameObject drag) { 
        this.gameObjectGroup = pointArray;
        this.dragPrefab = drag;
    }

    public void obstacle()
    {
        //각 단계의 배열에 객체를 넣고 배열의 길이만큼 반복하면서 맵에 생성해줌
        for (int i = 0; i < gameObjectGroup.Length; i++)
        {
            Debug.Log("장애물 디버프");
            //Debug.Log(gameObjectGroup.Length);
            Object.Instantiate(dragPrefab, gameObjectGroup[i].transform);
        }
    }

    public override void Run()
    {
        obstacle();
    }
}

