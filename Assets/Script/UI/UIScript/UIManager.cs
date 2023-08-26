using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int i;
    public Text missionText, timeText, crashText;
    public List<Mission> missions = Player.missionList;

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

        //carDamageText.text = "차량 손상도 : " + Car.carHp;
        //crimeText.text = "총 사고 이력 : " + total + "번";
        //alcoholText.text = "혈중 알콜 농도 : " + (Player.GetPlayer().drunkGauge / 1000.0f).ToString("F3") + "%";
    }

    void Update()
    {

    }
}