using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MissionCompleteListener
{
    public void OnComplete();
}

public interface Mission
{
    public bool isSuccess { set; get; }
    public List<MissionCompleteListener> listeners { get; set; }
    public void AddMissionCompleteListener(MissionCompleteListener listener);
}