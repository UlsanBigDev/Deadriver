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
                    , "어머니 급 가정 방"
                ),
                "소광씨 지금 바쁘신가요? 고객사 서버가 지금 오류가 생겨서 급하게 회사로 나와주셔야 할 것 같아요 안태원 대리님은 출장 중이셔서 소광씨께 부탁드릴게요 ㅠㅠ"
            )
        );

        missionMap.Add(1,
            (
                new GroupMission(
                    new List<Mission>()
                    {
                        new TimeMission(120f),
                        new CrashMission(3)
                    }
                    , "어머니 급 가정 방"
                ),
                "소광씨 지금 바쁘신가요? 고객사 서버가 지금 오류가 생겨서 급하게 회사로 나와주셔야 할 것 같아요 안태원 대리님은 출장 중이셔서 소광씨께 부탁드릴게요 ㅠㅠ"
            )
        );
        missionMap.Add(2,
            (
                new GroupMission(
                    new List<Mission>()
                    {
                        new TimeMission(120f),
                        new CrashMission(3)
                    }
                    , "어머니 급 가정 방"
                ),
                "소광씨 지금 바쁘신가요? 고객사 서버가 지금 오류가 생겨서 급하게 회사로 나와주셔야 할 것 같아요 안태원 대리님은 출장 중이셔서 소광씨께 부탁드릴게요 ㅠㅠ"
            )
        );
    }

    private void SetRandomMission()
    {
        int randomValue = Random.Range(0, 3);
        mission = missionMap[randomValue].Item1;
        missionScript = missionMap[randomValue].Item2;
    }
    public void ChangeDriveScene()
    {
        LoadingManager.sceneName = "Drive";
        SceneManager.LoadScene("LoadingScene");
    }
}
