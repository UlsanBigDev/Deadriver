using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PedestrianDrag : MonoBehaviour
{
    //Arragne ��ũ��Ʈó�� �� �迭�� ���̵��� ���ع��� ���� �ְ� Ȱ��ȭ/��Ȱ��ȭ
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
            Debug.Log("0�ܰ�");
            PedestrianObject = LevelArrange[levelint];
            PedestrianObject.SetActive(true);
        }

        else if(levelint == 1)
        {
            Debug.Log("1�ܰ�"); 
            for (int i = 0; i <= levelint; i++)
            {
                Debug.Log(i);
                PedestrianObject = LevelArrange[i];
                PedestrianObject.SetActive(true);

            }
        }

        else if (levelint == 2)
        {
            Debug.Log("2�ܰ�");
            for (int i = 0; i <= levelint; i++)
            {
                PedestrianObject = LevelArrange[i];
                PedestrianObject.SetActive(true);
            }
        }

        else if (levelint == 3)
        {
            Debug.Log("3�ܰ�");
            for (int i = 0; i <= levelint; i++)
            {
                PedestrianObject = LevelArrange[i];
                PedestrianObject.SetActive(true);
            }
        }
    }
}
