using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public bool isDrunken;
    public int damageLevel;
    public string[] crimeRecords;

    /*
     * isDrunken ==true 이면 디버프 동작
     * 이후 각 디버프들은 damageLevel, crimeRecords 조절
     * 
     * isDrunken은 음주이벤트 클래스에서 true/false 조절
     * 
     * isDrunken == true일때 음주이벤트 클래스에서 음주량(int alcholLevel) 조절
     */

}
