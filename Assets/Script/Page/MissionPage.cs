using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPage : MonoBehaviour
{
    private Dictionary<int, Mission> missionMap;

    private void Awake()
    {
        InitializeMission();
    }

    private void InitializeMission()
    {
        missionMap = new Dictionary<int, Mission>();
        missionMap.Add(0,
            new GroupMission(
                new List<Mission>()
                {
                    new TimeMission(120f),
                    new CrashMission(3)
                }
                , "어머니 급 가정 방"
            )
        );

        missionMap.Add(1,
            new GroupMission(
                new List<Mission>()
                {
                    new TimeMission(240f),
                    new CrashMission(6)
                }
                , "5분 내로 오면 5만원"
            )
        );
        missionMap.Add(2,
            new GroupMission(
                new List<Mission>()
                {
                    new TimeMission(300f),
                    new CrashMission(9)
                }
                , "상사 호출"
            )
        );
    }
}
