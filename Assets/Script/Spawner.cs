using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private PoolManager poolManager;

    [SerializeField]
    private EnemyType type;

    private float coolTime;

    private void Awake()
    {
        InitializeCoolTime();
    }

    private void InitializeCoolTime()
    {
        switch (type)
        {
            case EnemyType.ENEMY_CAR:
                coolTime = GameManager.enemyCarSpawnCoolTime;
                break;
            case EnemyType.PERSON:
                coolTime = GameManager.personSpawnCoolTime;
                break;
            default:
                coolTime = 999f;
                break;
        }
    }

    
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }*/
        
    }

    private void Spawn()
    {
        GameObject obj = poolManager.Get((int) type);
        obj.transform.position = transform.position;
    }
}
