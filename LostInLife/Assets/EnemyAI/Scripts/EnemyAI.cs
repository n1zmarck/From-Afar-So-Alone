
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemyAI : MonoBehaviour {


    public GameObject Player;

    private enum State {
        Roaming,
        ChaseTarget,
        ShootingTarget,
    }

    //   private IAimShootAnims aimShootAnims;
    //EnemyPathfindingMovement pathfindingMovement;
    EnemyNavMesh navMesh;
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private float nextShootTime;
    private State state;

    private void Awake() {
        //pathfindingMovement = GetComponent<EnemyPathfindingMovement>();
        navMesh = GetComponent<EnemyNavMesh>();
       // aimShootAnims = GetComponent<IAimShootAnims>();
        state = State.Roaming;
    }

    private void Start() {
        startingPosition = transform.position;
        navMesh.SetDestination(GetRoamingPosition());
    }

    private void Update() {
        switch (state) {
        default:
        case State.Roaming:
            //pathfindingMovement.MoveToTimer(roamPosition);

            float reachedPositionDistance = 10f;
            if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance) {
                // Reached Roam Position
                roamPosition = GetRoamingPosition();
            }

            FindTarget();
            break;
        case State.ChaseTarget:
                //pathfindingMovement.MoveToTimer(Player.transform.position);
                navMesh.SetDestination(Player.transform.position);
           // aimShootAnims.SetAimTarget(Player.Instance.GetPosition());


            float attackRange = 30f;
            if (Vector3.Distance(transform.position, Player.transform.position) < attackRange) {
                // Target within attack range
                if (Time.time > nextShootTime) {
                        // pathfindingMovement.StopMoving();
                        navMesh.stopMovingAgent();
                    state = State.ShootingTarget;
                    float fireRate = .15f;
                    nextShootTime = Time.time + fireRate;
                }
            }

            float stopChaseDistance = 80f;
            if (Vector3.Distance(transform.position, Player.transform.position) > stopChaseDistance) {
                // Too far, stop chasing
                state = State.ChaseTarget;
            }
            break;
        case State.ShootingTarget:
            break;

        }
    }

    private Vector3 GetRoamingPosition() {
        return startingPosition + throwRandom() * Random.Range(10f, 70f);
    }

    private void FindTarget() {
        float targetRange = 50f;
        if (Vector3.Distance(transform.position, Player.transform.position) < targetRange) {
            // Player within target range
            state = State.ChaseTarget;
        }
    }


    public Vector3 throwRandom()
    {
        return new Vector3(Random.Range(-1f, 1f),0, Random.Range(-1f, 1f)).normalized;
    }
}
