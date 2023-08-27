using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupMission : AbstractMission
{
    public List<Mission> missionList;


    public GroupMission(List<Mission> missions)
    {
        isSuccess = false;
        missionList = missions;
    }

    public GroupMission(List<Mission> missions, string title) : this(missions)
    {
        this.title = title;
    }

    public override bool GetState()
    {
        foreach (Mission mission in missionList)
        {
            if (!mission.isSuccess) return false;
        }
        return true;
    }
}
