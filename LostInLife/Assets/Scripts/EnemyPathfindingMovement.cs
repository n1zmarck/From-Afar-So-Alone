using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GridPathfindingSystem;

public class EnemyPathfindingMovement : MonoBehaviour
{
    private const float SPEED = 32f;

    private List<Vector3> pathVecList;
    private int currentPathIndex;
    private float pathFindingTimer;
    private Vector3 movingDir;
    private Vector3 lastmoveDir;
    private GameObject Enemy;

    public void MoveToTimer (Vector3 position)
    {



    }

    public void StopMoving()
    {


        
    }
    private void Awake()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        pathFindingTimer -= Time.deltaTime;
        HandleMovement();

    }
    private void FixedUpdate()
    {
        
    }

    private void HandleMovement()
    {
        PrintPathFindingPath();
        if (pathVecList != null)
        {
            Vector3 targetPosition = pathVecList[currentPathIndex];
            float reachTargetDistance = 4f;
            if (Vector3.Distance(GetPosition(),targetPosition) > reachTargetDistance)
            {
                movingDir = (targetPosition - GetPosition()).normalized;
                lastmoveDir = movingDir;
                //play enemy animation of moving.
            }
            else
            {

            }
        }
    }

    private void PrintPathFindingPath()
    {
        throw new NotImplementedException();
    }

    private Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public void MoveTo(Vector3 Target)
    {
        SetTargetPosition(Target);
    }

    private void SetTargetPosition(Vector3 target)
    {
        currentPathIndex = 0;

        pathVecList = GridPathfinding.instance.GetPathRouteWithShortcuts(GetPosition(), target).pathVectorList;
    }
}
