using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public bool isDrunken;
    public int damageLevel;
    public string[] crimeRecords;

    /*
     * isDrunken ==true �̸� ����� ����
     * ���� �� ��������� damageLevel, crimeRecords ����
     * 
     * isDrunken�� �����̺�Ʈ Ŭ�������� true/false ����
     * 
     * isDrunken == true�϶� �����̺�Ʈ Ŭ�������� ���ַ�(int alcholLevel) ����
     */

}
