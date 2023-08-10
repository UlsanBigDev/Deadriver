using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEvent : DrunkEvent
{
    public GameObject[] gameObjects;

    public GameObject gameObjectGroup;

    public ObstacleEvent(GameObject gameObjectGroup) { 
        this.gameObjectGroup = gameObjectGroup;
    }

    public void obstacle()
    {
        //Debug.Log(gameObjectGroup);
        gameObjects = gameObjectGroup.GetComponentsInChildren<GameObject>();
        //GameObject는 Component를 받아올 수 없음

        Debug.Log("장애물 디버프");

        for (int i = 0; i <= Car.Level; i++)
        {
            gameObjects[i].SetActive(true);
        }
    }

    public override void Run()
    {
        obstacle();
    }
}
