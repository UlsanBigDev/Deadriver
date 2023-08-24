using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour, Enemy
{
    private void OnCollisionEnter(Collision collision)
    {
        /* 빌딩, 다른 자동차, 보행자가 Player랑 부딪혔을 때 동작될 코드? */

        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerCrash(Player.GetPlayer());
            //Player와 부딪히면 플레이어의 자동차를 OnCrash를 통해서 넘겨줌
            //Player가 어떤 객체와 부딪혔는지 Debug.Log를 통해 알 수 있음 - OnCrash 함수를 통해서
        }
        else
        {
            OnCrash();
            return;
        }
    }

    /// <summary>
    /// 플레이어의 자동차와 충돌 했을때 호출됨
    /// </summary>
    protected abstract void OnPlayerCrash(Player player);
    protected virtual void OnCrash()
    {
        Disable();
        Debug.Log("Player 말고 다른거랑 부딪");
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
