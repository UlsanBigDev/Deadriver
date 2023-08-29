using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : AbstractEnemy
{
    public float speed;
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    
    protected override void OnPlayerCrash(Player player)
    {

    }
}
