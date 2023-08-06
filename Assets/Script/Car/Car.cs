using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Car
{   
    static bool isDirectionDragEvent { set; get; } // ���� ���� �̺�Ʈ
    static float playerAccelSpeed { set; get; }
    static float rotationSpeed { set; get; }

    static List<DrunkEvent> drunkEvents = new List<DrunkEvent>(); // ���� � ���� �̺�Ʈ�� �������ִ���..
    static void AddDrunkEvent(DrunkEvent drunkEvent) { // ���� �̺�Ʈ �߰�
        drunkEvents.Add(drunkEvent);
    }
    bool isPlayer { set; get; }
    float speed { set; get; }
    float rotation { set; get; }
}