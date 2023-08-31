using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DriveMissionUI : MonoBehaviour
{
    DrunkLevel level;
    public Text alcoholText;
    public Text CarDamage;
    public string str;

    private void Awake()
    {
        level = Player.GetPlayer().drunkLevel;
        SetLevel();
    }

    private void Start()
    {
        CarDamage.text = "차량손상도 : " + Car.carHp.ToString();
    }

    private void Update()
    {
        SetAlcohol();
    }

    public void SetLevel() //난이도별로 UI의 text, color를 변경함
    {
        alcoholText.text = "알콜 농도 : " + (Player.GetPlayer().drunkGauge / 1000.0f).ToString("F3") + "%";
        if (level == DrunkLevel.GREEN)
        {
            alcoholText.color = Color.green;
        }else if(level == DrunkLevel.YELLOW)
        {            
            alcoholText.color = Color.yellow;
        }else if(level == DrunkLevel.ORANGE)
        {            
            alcoholText.color = Color.yellow;
        }
        else if(level == DrunkLevel.RED)
        {
            alcoholText.color = Color.red;
        }
    }

    public void SetAlcohol()
    {
        CarDamage.text = Car.carHp.ToString(); // NNN%   // @장민욱 여기서 고치면됨여
    }
}
