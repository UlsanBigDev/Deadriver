using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private PoolManager poolManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
        
    }

    private void Spawn()
    {
        GameObject obj = poolManager.Get(0);
        obj.transform.position = transform.position;
    }
}
