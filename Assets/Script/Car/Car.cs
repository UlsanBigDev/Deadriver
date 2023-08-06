using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Car
{   
    static bool isDirectionDragEvent { set; get; } // 방향 반전 이벤트
    static float playerAccelSpeed { set; get; }
    static float rotationSpeed { set; get; }

    static List<DrunkEvent> drunkEvents = new List<DrunkEvent>(); // 현재 어떤 음주 이벤트를 가지고있는지..
    static void AddDrunkEvent(DrunkEvent drunkEvent) { // 음주 이벤트 추가
        drunkEvents.Add(drunkEvent);
    }
    bool isPlayer { set; get; }
    float speed { set; get; }
    float rotation { set; get; }
}