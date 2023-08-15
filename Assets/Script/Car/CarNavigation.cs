using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class CarNavigation
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private LineRenderer line;

    public void Init()
    {
        InitializeAgent();
    }

    private void InitializeAgent() 
    {
        agent.speed = 0f;
        agent.SetDestination(target.position);
    }

    internal void DrawLIne()
    {
        int length = agent.path.corners.Length;
        if (length < 2) return;
        line.positionCount = length;
        line.SetPositions(agent.path.corners);
    }

}
