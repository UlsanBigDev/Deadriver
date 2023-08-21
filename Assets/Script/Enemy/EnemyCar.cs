using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : AbstractEnemy
{
    protected override void OnCrash(Player player)
    {
        Debug.Log("자동차 충돌");
    }
}
