using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPlayer : Player
{

    public int drunkGauge { get; set; }
    public bool isDrunk { get; set; }
    public DrunkLevel drunkLevel { get; set; }

    public AbstractPlayer()
    {
        InitializeVariable();
    }

    private void InitializeVariable()
    {
        drunkGauge = 0;
        isDrunk = false;
        drunkLevel = DrunkLevel.GREEN;
    }

    public void SetDrunkGauge(int value)
    {
        drunkGauge = value;
        drunkLevel = CalculateDrunkLevel(value);
        if (drunkLevel != DrunkLevel.GREEN) isDrunk = true;
    }

    private DrunkLevel CalculateDrunkLevel(int value)
    {
        if (value < 30) return DrunkLevel.GREEN;
        else if (value < 80) return DrunkLevel.YELLOW;
        else if (value < 100) return DrunkLevel.ORANGE;
        else return DrunkLevel.RED;
    }
}
