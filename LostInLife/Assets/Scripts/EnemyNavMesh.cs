using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] public Transform moveDestination;

    public NavMeshAgent navAgent;
    public float speed;
    private bool stopMoving = false;
    private Enemy self;

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
        if (navAgent != null)
        {
            navAgent = GetComponent<NavMeshAgent>();            
        }

    }

   
}
