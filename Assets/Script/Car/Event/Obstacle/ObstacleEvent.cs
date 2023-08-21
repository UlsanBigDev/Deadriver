using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 장애물 생성 디버프 클레스
/// </summary>
public class ObstacleEvent : DrunkEvent 
{
    private GameObject dragPrefab;

    private Transform[] gameObjectGroup; //장애물들이 생성될 위치를을 배열에 저장
    private Vector3[] currentPosition;

    DrunkLevel level = Player.GetPlayer().drunkLevel; //난이도 받아옴

    float plus = 0.1f;

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

    void OnTrigger(Collider other) //여기 있으면 실행이 안되서 위치 옮겨줘야함
    {
        while (true)
        {
            for (int i = 0; i < gameObjectGroup.Length; i++)
            {
                currentPosition[i] = gameObjectGroup[i].transform.position;
                float newXPosition = gameObjectGroup[i].transform.position.x + plus;
                float newYPosition = gameObjectGroup[i].transform.position.y;
                float newZPosition = gameObjectGroup[i].transform.position.z;

                gameObjectGroup[i].transform.position = new Vector3(newXPosition, newYPosition, newZPosition);

                if (other.tag == "building" || other.tag == "CarDrag" || other.tag == "Person")
                {
                    gameObjectGroup[i].transform.position = new Vector3(currentPosition[i].x, currentPosition[i].y, currentPosition[i].z);
                }
            }
        }
    }

    public override void Run()
    {
        obstacle();
    }
}

