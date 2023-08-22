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
        level = DrunkLevel.GREEN;
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
        // @민욱 여기서 혈중 알콜 농도 0.3~ 에서 어쩌구 식으로 변경하게
        alcoholText.text = "알콜 농도 : " + (Player.GetPlayer().drunkGauge / 1000.0f).ToString("F3") + "%";
        Debug.Log(alcoholText.text);
        if (level == DrunkLevel.GREEN)
        {
            Debug.Log("GREEN 색깔");
            //colorLevel.text = "0 ~ 29";
            alcoholText.color = Color.green;
        }else if(level == DrunkLevel.YELLOW)
        {
            Debug.Log("YELLOW 색깔");
            //colorLevel.text = "30 ~ 79";
            alcoholText.color = Color.yellow;
        }else if(level == DrunkLevel.ORANGE)
        {
            Debug.Log("ORANGE 색깔");
            //str = "<color=#FF4500>" + "80 ~ 99" + "</color>";
            alcoholText.text = str;            
        }
        else if(level == DrunkLevel.RED)
        {
            Debug.Log("RED 색깔");
            //colorLevel.text = "100 ~ ";
            alcoholText.color = Color.red;
        }
    }

    public void SetAlcohol()
    {
        //Debug.Log("차량 손상도 UI"); 
        CarDamage.text = Car.carHp.ToString(); // NNN%   // @장민욱 여기서 고치면됨여
    }
}
