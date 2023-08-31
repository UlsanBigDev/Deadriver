using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyEnemy : DrunkEvent
{
    private DrunkLevel level;
    public override void Run()
    {
        InitializeVariable();
        SetEnemyCoolTime();
    }

    private void InitializeVariable()
    {
        level = Player.GetPlayer().drunkLevel;
    }

    private void SetEnemyCoolTime()
    {
        SetEnemyCarCoolTime();
        SetEnemyPersonCoolTime();
    }
    private void SetEnemyCarCoolTime()
    {
        switch (level)
        {            
            case DrunkLevel.YELLOW:
                GameManager.enemyCarSpawnCoolTime = 20f;
                break;
            case DrunkLevel.ORANGE:
                GameManager.enemyCarSpawnCoolTime = 15f;
                break;
            case DrunkLevel.RED:
                GameManager.enemyCarSpawnCoolTime = 10f;
                break;
        }
    }

    private void SetEnemyPersonCoolTime()
    {
        switch (level)
        {            
            case DrunkLevel.YELLOW:
                GameManager.personSpawnCoolTime = 12f;
                break;
            case DrunkLevel.ORANGE:
                GameManager.personSpawnCoolTime = 10f;
                break;
            case DrunkLevel.RED:
                GameManager.personSpawnCoolTime = 8f;
                break;
        }
    }


    
}
