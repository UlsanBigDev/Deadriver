using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour 
{
    //배열에 장애물을 저장하고 if문으로 조건에 따라 어떤 장애물들을 활성화시킬지 

    public GameObject[] obstacleArrange;
    public GameObject arrangeObject;
    public int i = 613;

    public void obstacle()
    {
        if (0 < Car.Level && Car.Level < 25)
        {
            Debug.Log("0단계");
            arrangeObject = obstacleArrange[0];
            arrangeObject.SetActive(true);
        }

        else if (25 < Car.Level && Car.Level < 50)
        {
            Debug.Log("1단계");
            for (int i = 0; i <= 1; i++)
            {
                Debug.Log(i);
                arrangeObject = obstacleArrange[i];
                arrangeObject.SetActive(true);

            }
        }

        else if (50 < Car.Level && Car.Level < 75)
        {
            Debug.Log("2단계");
            for (int i = 0; i <= 2; i++)
            {
                arrangeObject = obstacleArrange[i];
                arrangeObject.SetActive(true);
            }
        }

        else if (75 < Car.Level && Car.Level < 100)
        {
            Debug.Log("3단계");
            for (int i = 0; i <= 2; i++)
            {
                arrangeObject = obstacleArrange[i];
                arrangeObject.SetActive(true);
            }
        }
    }


}
