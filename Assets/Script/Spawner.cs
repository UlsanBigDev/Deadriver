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

    private IEnumerator coroutine;
    public bool isEnable;

    private void Awake()
    {
        isEnable = true;
        InitializeCoolTime();
        coroutine = SpawnCoroutine();

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
        Debug.DrawRay(transform.position, transform.forward);
    }

    private void Start()
    {
        StartSpawn();
    }

    private void StartSpawn()
    {
        isEnable = true;
        StartCoroutine(coroutine);
    }

    public void StopSpawn()
    {
        isEnable = false;
        StopCoroutine(coroutine);
    }

    private void Spawn()
    {
        GameObject obj = poolManager.Get((int) type);
        obj.transform.position = transform.position;
    }
    private IEnumerator SpawnCoroutine()
    {   
        while (isEnable)
        {
            Spawn();
            yield return new WaitForSeconds(coolTime);
        }
    }
}
