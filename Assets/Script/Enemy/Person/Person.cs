using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : AbstractEnemy
{
    protected override void OnCrash(Player player)
    {
        Debug.Log("사람 충돌");
    }
}
