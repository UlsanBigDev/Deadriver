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
    private NavMeshAgent agent;
    public CarNavigation(GameObject gameObject)
    {
        current = gameObject;
        InitializeNavMeshAgent();
    }

    private void InitializeNavMeshAgent()
    {
        agent = current.GetComponent<NavMeshAgent>();
        agent.speed = 0f;
    }

    internal void SetTarget(Transform transform)
    {
        target = transform;
        agent.SetDestination(target.position);
        Debug.Log(agent.path.corners.Length);
    }

}
