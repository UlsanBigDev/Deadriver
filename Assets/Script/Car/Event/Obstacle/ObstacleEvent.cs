using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ObstacleEvent : DrunkEvent
{
    //[SerializeField]
    private GameObject dragPrefab;

    private Transform[] gameObjectGroup; //장애물들이 생성될 위치를을 배열에 저장
    DrunkLevel level = Player.GetPlayer().drunkLevel; //난이도 받아옴

    public ObstacleEvent(Transform[] pointArray,GameObject drag) { 
        this.gameObjectGroup = pointArray;
        this.dragPrefab = drag;
    }

    public void obstacle()
    {
        for(int i=0; i < gameObjectGroup.Length; i++) {
            Debug.Log("장애물 디버프");
            Object.Instantiate(dragPrefab, gameObjectGroup[i].transform);
        }
    }

    public override void Run()
    {
        obstacle();
    }
}
