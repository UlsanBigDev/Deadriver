using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : AbstractEnemy
{
    protected override void OnCrash(Player player)
    {
        Debug.Log("빌딩 충돌");
    }
}
