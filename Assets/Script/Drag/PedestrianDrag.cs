using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PedestrianDrag : MonoBehaviour
{
    //Arragne 스크립트처럼 각 배열에 난이도별 방해물을 각각 넣고 활성화/비활성화
    public List<GameObject> listObject = new List<GameObject>();
    public GameObject[] LevelArrange0;
    public GameObject[] LevelArrange1;
    public GameObject[] LevelArrange2;
    public GameObject[] LevelArrange4;
    public GameObject PedestrianObject;

    void Awake()
    {
        PedestrianLevel();    
    }

    public void PedestrianLevel()
    {
        int levelint = PlayerPrefs.GetInt("GameLevel");
        //LevelArrange = LevelArrange[levelint];
        Debug.Log("levelint" + levelint);

        for(int i=0; i<levelint; i++)
        {
            listObject.Add(LevelArrange0[i]);
        }

        //for(int i=0; i<levelint ; i++)
        //{
        //    for(int j=0; j<)
        //}
    }
}
