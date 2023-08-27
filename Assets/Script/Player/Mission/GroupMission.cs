using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupMission : AbstractMission
{
<<<<<<< HEAD
    private List<Mission> missionList;
     
=======
    public List<Mission> missionList;

>>>>>>> 2959f8ee7bdee502c308cfa7f0d8dc6c0216618f
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
