using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : AbstractEnemy
{
    /* 빌딩이랑 충돌됐는지 알려주는 코드 */
    //빌딜이랑 충돌되면 이 스크립트가 실행

    protected override void OnCrash(Player player)
    {
        Debug.Log("빌딩 충돌");
    }
}
