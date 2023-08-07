using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Car
{   
    static bool isDirectionDragEvent { set; get; } // ���� ���� �̺�Ʈ
    static float playerAccelSpeed { set; get; }
    static float rotationSpeed { set; get; }
    static int carHp { set; get; }

    static List<DrunkEvent> drunkEvents = new List<DrunkEvent>(); // ���� � ���� �̺�Ʈ�� �������ִ���..
    static void AddDrunkEvent(DrunkEvent drunkEvent) { // ���� �̺�Ʈ �߰� ->   GameManager���� �� �Լ��� ȣ��
        drunkEvents.Add(drunkEvent);
    }

    void CarDamage(int carDamage);
    bool isPlayer { set; get; }
    float speed { set; get; }
    float rotation { set; get; }
}