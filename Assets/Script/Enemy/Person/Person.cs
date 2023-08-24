using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : AbstractEnemy
{
    public float speed;
    private void Update()
    {
        transform.position += transform.forward.normalized * Time.deltaTime * speed;
    }
    /* 사람이랑 충돌됐는지 알려주는 코드 */
    //사람이랑 충돌되면 이 스크립트가 실행
    protected override void OnPlayerCrash(Player player)
    {
        //Debug.Log("사람 충돌");
    }
    

}
