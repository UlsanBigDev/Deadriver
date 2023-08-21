using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour, Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCrash(Player.GetPlayer());
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// 플레이어의 자동차와 충돌 했을때 호출됨
    /// </summary>
    protected abstract void OnCrash(Player player);
}
