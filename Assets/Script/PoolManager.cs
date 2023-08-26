using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;

    private Dictionary<int, List<GameObject>> poolMap;

    private void Awake()
    {
        poolMap = new Dictionary<int, List<GameObject>>();
        for (int i=0; i<prefabs.Length; i++)
        {
            poolMap.Add(i, new List<GameObject>());
        }
        Debug.Log("초기화 완료!");
    }

    public GameObject Get(int id)
    {
        GameObject obj = null;
        List<GameObject> poolList = poolMap[id];
        foreach (GameObject poolObject in poolList) {
            if (!poolObject.activeSelf)
            {
                obj = poolObject;
                obj.SetActive(true);
                break;
            }
        }

        if (obj == null)
        {
            obj = Instantiate(prefabs[id], transform);
            poolList.Add(obj);
            /// poolList 에 추가한 요소가 poolMap 에서 적용 안될수 있음...
        }


        return obj;
    }

}
