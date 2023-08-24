using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashMission : AbstractMission, CrashListener
{
    private int count;
    public CrashMission(int count)
    {
        this.count = count;
        isSuccess = true;
        Car.AddCrashListener(this);
    }

    public void OnCrash(Enemy enemey)
    {
        if (!isSuccess) return;
        if (--count <= 0) isSuccess = false;
        Debug.Log("Crash Mission : " + enemey);
    }
}
