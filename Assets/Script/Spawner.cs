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
        /*if (Input.GetKeyDown(KeyCode.Alpha1)) StartSpawn();
        if (Input.GetKeyDown(KeyCode.Alpha2)) StopSpawn();*/
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
        obj.transform.rotation = transform.rotation;
    }
    private IEnumerator SpawnCoroutine()
    {   
        while (isEnable)
        {
            Spawn();
            InitializeCoolTime();
            yield return new WaitForSeconds(coolTime);
        }
    }
}
