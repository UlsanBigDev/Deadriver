using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrunkLevel
{
    GREEN, YELLOW, ORANGE, RED
}

public interface Player
{
    private static Player instance;
    public static Player GetPlayer()
    {
        if (instance == null) instance = new AbstractPlayer();
        return instance;
    }
    public static List<Mission> missionList = new List<Mission>();
    public int drunkGauge { get; set; }
    public bool isDrunk { get; set; }
    public DrunkLevel drunkLevel { get; set; }
    public void SetDrunkGauge(int value);
}