using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrunkLevel
{
    GRREN, YELLOW, ORANGE, RED
}

interface Player
{
    private static Player instance;
    public static Player GetPlayer()
    {
        if (instance == null) instance = new AbstractPlayer();
        return instance;
    }
    public int drunkGauge { get; protected set; }
    public bool isDrunk { get; protected set; }
    public DrunkLevel dunkLevel { get; protected set; }
    public void SetDrunkGauge(int value);
}