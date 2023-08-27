using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMission : AbstractMission, UpdateListener
{
    public float originTime;
    private float completeTime;
    public TimeMission(float time)
    {
        originTime = time;
        this.completeTime = time;
        isSuccess = true;
        GameManager.AddUpdateListener(this);
    }

    public TimeMission(float time, string title) : this(time)
    {
        this.title = title;
    }

    public void OnUpdate()
    {
        if (!isSuccess) return;
        // Debug.Log("남은시간 : " + completeTime);
        completeTime -= Time.deltaTime;
        if (completeTime <= 0) isSuccess = false;

    }
}
