using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PedestrianDrag : MonoBehaviour
{
    //Arragne ��ũ��Ʈó�� �� �迭�� ���̵��� ���ع��� ���� �ְ� Ȱ��ȭ/��Ȱ��ȭ
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
