using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class CarNavigation
{
    private GameObject current;
    [SerializeField]
    private Transform target;
    public CarNavigation(GameObject gameObject)
    {
        current = gameObject;
    }

}
