using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] public Transform moveDestination;

    private NavMeshAgent navAgent;
    private bool stopMoving = false;
    private Enemy health;
    public void stopMovingAgent()
    {
        stopMoving = true;
    }

    public void SetDestination(Vector3 Target)
    {
        moveDestination.position = Target;    
    }


    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (stopMoving == false)
        {
            navAgent.speed = health.getSpeed(navAgent.speed);
            navAgent.destination = moveDestination.position;

        }
    }
}
