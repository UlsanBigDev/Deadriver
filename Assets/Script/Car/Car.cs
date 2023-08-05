using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Car
{   
    static bool isDirectionDragEvent { set; get; } // 방향 반전 이벤트
    static float playerAccelSpeed { set; get; }
    bool isPlayer { set; get; }
    float speed { set; get; }
    float rotation { set; get; }
}