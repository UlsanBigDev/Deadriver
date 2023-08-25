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
    public string title { get; set; }
    public List<MissionCompleteListener> listeners { get; set; }
    public void AddMissionCompleteListener(MissionCompleteListener listener);
    /// <summary>
    /// 미션 클리어 했는지 안했는지
    /// </summary>
    public bool GetState();
}