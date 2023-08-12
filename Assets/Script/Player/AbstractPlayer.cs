using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPlayer : Player
{
    int Player.drunkGauge { get; set; }
    bool Player.isDrunk { get; set; }
    DrunkLevel Player.dunkLevel { get; set; }

    public void SetDrunkGauge(int value)
    {
        
    }
}
