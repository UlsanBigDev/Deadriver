using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Car.AddDrunkEvent(new RashEvent());
        Car.AddDrunkEvent(new RotationEvent());
    }
}
