using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : AbstractEnemy
{
    /* 자동차랑 충돌됐는지 알려주는 코드 */
    //자동차랑 충돌되면 이 스크립트가 실행

    protected override void OnPlayerCrash(Player player)
    {
        //Debug.Log("자동차 충돌");
    }
}
