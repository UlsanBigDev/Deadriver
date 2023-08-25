using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrashType
{
    ALL, BUILDING, ENEMY_CAR, PERSON
}
public class CrashMission : AbstractMission, CrashListener
{
    private int count;
    private CrashType crashType;
    public CrashMission(int count)
    {
        listeners = new List<MissionCompleteListener>();
        this.count = count;
        isSuccess = true;
        Car.AddCrashListener(this);
        crashType = CrashType.ALL;
    }

    public CrashMission(int count, CrashType type) : this(count) {
        crashType = type;
    }

    public CrashMission(int count, CrashType type, string title) : this(count, type)
    {
        this.title = title;
    }

    public virtual void OnCrash(Enemy enemy)
    {
        if (!isSuccess) return;
        if (!CheckType(enemy)) return;
        if (--count <= 0) isSuccess = false;
        Debug.Log("Crash Mission : " + enemy);
    }

    private bool CheckType(Enemy enemy)
    {
        if (crashType == CrashType.ALL)
        {
            return true;
        }
        else if (crashType == CrashType.BUILDING)
        {
            if (enemy is Building) return true;
            else return false;
        }
        else if (crashType == CrashType.ENEMY_CAR)
        {
            if (enemy is EnemyCar) return true;
            else return false;
        }
        else if (crashType == CrashType.PERSON)
        {
            if (enemy is Person) return true;
            else return false;
        }
        else
        { // 나도 모르는 경우
            return false;
        } 
    }
}
