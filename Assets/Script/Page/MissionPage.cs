using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MissionPage : MonoBehaviour
{
    private Dictionary<int, (Mission, string)> missionMap;
    private Mission mission;
    private string missionScript;

    [SerializeField]
    private TMP_Text missionText;

    private void Awake()
    {
        InitializeMission();
        SetRandomMission();
    }

    private void Start()
    {
        missionText.text = missionScript;
        Player.missionList.Add(mission);
    }

    private void InitializeMission()
    {
        missionMap = new Dictionary<int, (Mission, string)>();
        missionMap.Add(0,
            (
                new GroupMission(
                    new List<Mission>()
                    {
                        new TimeMission(120f),
                        new CrashMission(3)
                    }
                    , "어머니 급 가정 방문"
                ),
                "아들 회사야?? \n반찬했는데. 택배로 하기는 좀 그래서 엄마가 아들 집으로 가고있어\n지금 역 앞이니까 곧 도착 할꺼야\n아들 방 깔끔하게 쓰고있는지도 확인할거야~"
            )
        );

        missionMap.Add(1,
            (
                new GroupMission(
                    new List<Mission>()
                    {
                        new TimeMission(180f),
                        new CrashMission(6)
                    }
                    , "친구 구출"
                ),
                "야 소광아 나 똥싸다가 화장실에 갇혔어\n우리집에 와서 나좀 꺼내주라 제에에에발~~~~~~\n10분 뒤에 나 약속있다고 빨리와줘야해\n집 주소는 어디인줄 알지?\n꺼내주면 바로 5만원 찔러줄께 부탁한다 소광아..."
            )
        );
        missionMap.Add(2,
            (
                new GroupMission(
                    new List<Mission>()
                    {
                        new TimeMission(240f),
                        new CrashMission(9)
                    }
                    , "상사 호출"
                ),
                "소광씨 지금 바쁘신가요? 고객사 서버가 지금 오류가 생겨서 급하게 회사로 나와주셔야 할 것 같아요 안태원 대리님은 출장 중이셔서 소광씨께 부탁드릴게요 ㅠㅠ"
            )
        );
        missionMap.Add(3,
            (
                new GroupMission(
                    new List<Mission>()
                    {
                        new TimeMission(300f),
                        new CrashMission(12)
                    }
                    , "친구의 깜작 이벤트"
                ),
                "광! 아!\n내 오늘 지영이한테 고백 박아버릴꺼니까 니가좀 도와라\n차에서 풍선정도는 튀나와 줘야 지영이가 안좋아 하긋나?\n그래서 니 차좀 빌려도.\n지영이 곧 퇴근하는데 빨리 온나 내 난중에 술 한잔 살께!"
            )
        );
    }

    private void SetRandomMission()
    {
        int randomValue = Random.Range(0, 3);
        Mission.selectMissionIndex = randomValue;
        mission = missionMap[randomValue].Item1;
        missionScript = missionMap[randomValue].Item2;
    }
    public void ChangeDriveScene()
    {
        LoadingManager.sceneName = "Drive";
        SceneManager.LoadScene("LoadingScene");
    }
}
