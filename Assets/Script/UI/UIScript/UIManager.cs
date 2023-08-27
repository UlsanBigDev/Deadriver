using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text carDamageText, alcoholText, crimeText,resultMissionText;
    public List<Mission> missions = Player.missionList;
    public int total;
    GroupMission groupMission;
    // LoadingAnimation loadingAnimation;

    void Start()
    {
    }

    void Awake()
    {
        groupMission = new GroupMission(Player.missionList);      
        // loadingAnimation = GetComponent<LoadingAnimation>();
    }

    void Update()
    {
        total = AbstractCar.buildingint + AbstractCar.personint + AbstractCar.carint;
        carDamageText.text = "차량 손상도 : " + Car.carHp;
        crimeText.text = "총 사고 이력 : " + total + "번";
        alcoholText.text = "혈중 알콜 농도 : " + (Player.GetPlayer().drunkGauge / 1000.0f).ToString("F3") + "%";

        if(groupMission.GetState() == true)
        {
            resultMissionText.text = "미션 : 성공";
        }
        else
        {
            resultMissionText.text = "미션 : 실패";
        }
    }

    public void clickBack()
    {
        // loadingAnimation.changeScene("StartScene");
        SceneManager.LoadScene("LoadingScene");
    }
}