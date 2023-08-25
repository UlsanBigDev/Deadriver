using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMission : Mission
{
    public bool isSuccess { get; set; }

    public List<MissionCompleteListener> listeners { get; set; }

    public string title { get; set; }

    public void AddMissionCompleteListener(MissionCompleteListener listener)
    {
        listeners.Add(listener);
    }

    public virtual bool GetState() //virtual
    {
        return isSuccess;
    }
}
