using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int i;
    public Text missionText, timeText, crashText, resultMissionText;
    public Text carDamageText, alcoholText, crimeText, scoreText;
    public List<Mission> missions = Player.missionList;
    GroupMission groupMission;

    void Awake()
    {
        //groupMission = new GroupMission();
    }
    void Start()
    {
        //i = Random.Range(0, 3); //미션 씬에서 랜덤 수를 받고 그 값을 여기로 가져옴
        i = 0;
        missionText.text = missions[i].title;
        switch (i)
        {
            case 0:
                //Debug.Log(TimeMission.timeMissionint);
                //timeText.text = "제한 시간 : " + TimeMission.timeMissionint / 60 + "분";
                timeText.text = "제한 시간 : 2분";
                crashText.text = "충돌 제한 횟수 : 3번";
                break;
            case 1:
                timeText.text = "제한 시간 : 4분";
                crashText.text = "충돌 제한 횟수 : 6번";
                break;
            case 2:
                timeText.text = "제한 시간 : 5분";
                crashText.text = "충돌 제한 횟수 : 3번";
                break;
        }       
    }

    void Update()
    {
        carDamageText.text = "차량 손상도 : " + Car.carHp;
        crimeText.text = "총 사고 이력 : " + (AbstractCar.buildingint + AbstractCar.personint + AbstractCar.carint) + "번";
        alcoholText.text = "혈중 알콜 농도 : " + (Player.GetPlayer().drunkGauge / 1000.0f).ToString("F3") + "%";
        //if(AbstractMission.GetState() == true)
        //{
        //    resultMissionText.text = "미션 : 성공";
        //}
        //else
        //{
        //    resultMissionText.text = "미션 : 실패 ";
        //}
        
    }
}