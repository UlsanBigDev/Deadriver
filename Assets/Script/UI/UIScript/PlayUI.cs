using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    DrunkLevel level = Player.GetPlayer().drunkLevel;
    public Text colorLevel;
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

    public void SetLevel()
    {
        if (level == DrunkLevel.GREEN)
        {
            Debug.Log("GREEN 색깔");
            colorLevel.text = "0 ~ 29";
            colorLevel.color = Color.green;
        }else if(level == DrunkLevel.YELLOW)
        {
            Debug.Log("YELLOW 색깔");
            colorLevel.text = "30 ~ 79";
            colorLevel.color = Color.yellow;
        }else if(level == DrunkLevel.ORANGE)
        {
            Debug.Log("ORANGE 색깔");
            str = "<color=#FF4500>" + "80 ~ 99" + "</color>";
            colorLevel.text = str;            
        }
        else if(level == DrunkLevel.RED)
        {
            Debug.Log("RED 색깔");
            colorLevel.text = "100 ~ ";
            colorLevel.color = Color.red;
        }
    }

    public void SetAlcohol()
    {
        //Debug.Log("차량 손상도 UI"); 
        CarDamage.text = "차량 손상도 :" + Car.carHp.ToString();
    }
}
