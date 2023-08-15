using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[System.Serializable]
public class ObstacleEvent : DrunkEvent
{
    //변수가 GameObject로 선언되면 GetComponetsInChildren을 사용 불가능
    //Transform으로 선언 시 SetActive를 사용 불가능

    [SerializeField]
    public GameObject dragPrefab;

    public Transform[] gameObjectGroup; //장애물들이 생성될 위치를을 배열에 저장
    DrunkLevel level = Player.GetPlayer().drunkLevel; //난이도 받아옴

    public ObstacleEvent(Transform[] pointArray) { 
        this.gameObjectGroup = pointArray;
    }

    public void obstacle()
    {
        Debug.Log("장애물 디버프");

        if (level == DrunkLevel.GREEN)
        {
            for (int i = 0; i <= 1; i++)
            {
                Debug.Log("GREEN 난이도");

                int pointIndex = Random.Range(0,gameObjectGroup.Length);
                //0부터 gameObjectGroup의 길이까지 중에 랜덤으로 수를 받아옴

                Transform pointPosition = gameObjectGroup[pointIndex].transform;
                //pointIndex(랜덤 수)번째에 있는 gameObjectGroup의 위치를 position에 저장

                Debug.Log("test");
                //여기까지는 정상 실행되는데 Instantiate 이게 실행이 안됨
                GameObject clone = Object.Instantiate(dragPrefab, pointPosition);
            }
        }
        
    }

    public override void Run()
    {
        obstacle();
    }
}
