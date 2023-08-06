using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PedestrianDrag : MonoBehaviour
{
    //Arragne 스크립트처럼 각 배열에 난이도별 방해물을 각각 넣고 활성화/비활성화
    public GameObject[] LevelArrange;
    public GameObject PedestrianObject;

    void Awake()
    {
        PedestrianLevel();    
    }

    public void PedestrianLevel()
    {
        int levelint = PlayerPrefs.GetInt("GameLevel");
        Debug.Log("levelint" + levelint);

        if(levelint == 0)
        {
            Debug.Log("0단계");
            PedestrianObject = LevelArrange[levelint];
            PedestrianObject.SetActive(true);
        }

        else if(levelint == 1)
        {
            Debug.Log("1단계"); 
            for (int i = 0; i <= levelint; i++)
            {
                Debug.Log(i);
                PedestrianObject = LevelArrange[i];
                PedestrianObject.SetActive(true);

            }
        }

        else if (levelint == 2)
        {
            Debug.Log("2단계");
            for (int i = 0; i <= levelint; i++)
            {
                PedestrianObject = LevelArrange[i];
                PedestrianObject.SetActive(true);
            }
        }

        else if (levelint == 3)
        {
            Debug.Log("3단계");
            for (int i = 0; i <= levelint; i++)
            {
                PedestrianObject = LevelArrange[i];
                PedestrianObject.SetActive(true);
            }
        }
    }
}
