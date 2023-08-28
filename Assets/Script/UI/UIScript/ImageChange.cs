using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Sprite BScore, CScore, DScore, FScore;
    Image AScore;
    public int crashScore, carScore, drunkScore, missionScore, scoreTotal, total;
    DrunkLevel drunkLevel;
    GroupMission groupMission;

    void Awake()
    {
        crashScore = 0;
        carScore = 0;
        drunkScore = 0;
        missionScore = 0;
        scoreTotal = 0;
        total = 0;
        drunkLevel = Player.GetPlayer().drunkLevel;
        groupMission = new GroupMission(Player.missionList);
    }

    void Start()
    {  
        AScore = GetComponent<Image>();
    }
    void Update()
    {
            SetScore();
    }


    public void SetScore()
    {
        total = AbstractCar.buildingint + AbstractCar.personint + AbstractCar.carint;
        if (total == 0)
        {
            crashScore = 25;
        }
        else if (total >= 1 && total <= 5)
        {
            crashScore = 20;
        }
        else if (total >= 6 && total <= 10)
        {
            crashScore = 15;
        }
        else if (total >= 11 && total <= 20)
        {
            crashScore = 10;
        }
        else if (total >= 21)
        {
            crashScore = 5;
        }

        Debug.Log("asdasd" + Car.carHp);
        if (Car.carHp > 90 && Car.carHp <= 100)
        {
            carScore = 25;
        }
        else if (Car.carHp > 70 && Car.carHp <= 80)
        {
            carScore = 20;
        }
        else if (Car.carHp > 40 && Car.carHp <= 70)
        {
            carScore = 15;
        }
        else if (Car.carHp > 20 && Car.carHp <= 40)
        {
            carScore = 10;
        }
        else if (Car.carHp >= 0 && Car.carHp <= 20)
        {
            carScore = 5;
        }

        if (drunkLevel == DrunkLevel.GREEN)
        {
            drunkScore = 25;
        }
        else if (drunkLevel == DrunkLevel.YELLOW)
        {
            drunkScore = 20;
        }
        else if (drunkLevel == DrunkLevel.YELLOW)
        {
            drunkScore = 15;
        }
        else if (drunkLevel == DrunkLevel.YELLOW)
        {
            drunkScore = 10;
        }

        if (groupMission.GetState() == true)
        {
            missionScore = 25;
        }
        else
        {
            missionScore = 0;
        } 

        scoreTotal = (crashScore + carScore + drunkScore + missionScore) / 10;

        if (scoreTotal >= 6 && scoreTotal < 8)
        {
            AScore.sprite = BScore;
        }
        else if (scoreTotal >= 4 && scoreTotal < 6)
        {
            AScore.sprite = CScore;
        }
        else if (scoreTotal >= 2 && scoreTotal < 4)
        {
            AScore.sprite = DScore;
        }
        else if (scoreTotal >= 0 && scoreTotal < 2)
        {
            AScore.sprite = FScore;
        }
    }
}
