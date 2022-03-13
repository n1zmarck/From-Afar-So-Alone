
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemyAI : MonoBehaviour {


    public GameObject Player;

    public enum State {
        Roaming,
        ChaseTarget,
        ShootingTarget,
    }

    //   private IAimShootAnims aimShootAnims;
    //EnemyPathfindingMovement pathfindingMovement;
    public EnemyNavMesh navMesh;
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private float nextShootTime;
    public State state;
    public Animator animator;


    private void Awake() {
        //pathfindingMovement = GetComponent<EnemyPathfindingMovement>();
        navMesh = GetComponent<EnemyNavMesh>();
       // aimShootAnims = GetComponent<IAimShootAnims>();
        state = State.Roaming;
    }

    private void Start() {
        startingPosition = transform.position;
        
    }

    private void Update() {
        switch (state) {
        default:
        case State.Roaming:


                //FindTarget();
                animator.Play("demo_combat_run");
            
                
                break;
        case State.ChaseTarget:

                
            float attackRange = 30f;
            if (Vector3.Distance(transform.position, Player.transform.position) < attackRange) {
                // Target within attack range
                if (Time.time > nextShootTime) {
                        // pathfindingMovement.StopMoving();
                        navMesh.stopMovingAgent();
                    state = State.ShootingTarget;
                    float fireRate = .25f;
                    nextShootTime = Time.time + fireRate;
                }
            }

       
                    break;
        case State.ShootingTarget:

                animator.Play("demo_combat_shoot");
            break;

        }
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
