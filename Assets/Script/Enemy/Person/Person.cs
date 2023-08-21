using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : AbstractEnemy
{
    /* 사람이랑 충돌됐는지 알려주는 코드 */
    //사람이랑 충돌되면 이 스크립트가 실행

    protected override void OnCrash(Player player)
    {
        Debug.Log("사람 충돌");
    }
}
