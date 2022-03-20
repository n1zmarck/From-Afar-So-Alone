using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public Enemy enemy;
    public EnemyNavMesh enemynavmesh;
    public GameObject body;
    // public EnemyManager manager;
    public Transform playerCurrentPos;
    public Transform currentPos;
    public GameObject DestinationBeacon;
    public EnemyAI aI;
    public bool destinationSet = true;
    float stopChasingDistance = 16f;

    public float fireRange = 50f;

    private Vector3 startpos;
    private Vector3 roamPos;
    // Start is called before the first frame update

    public Vector3 getRoamingPos(Vector3 startpos)
    {
        return startpos + GetRandomdirec() * Random.Range(1f, 5f);
    }
    public Vector3 GetRandomdirec()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private void Awake()
    {
        GetComponent<Enemy>();
        GetComponent<EnemyNavMesh>();
        GetComponent<EnemyManager>();
        GetComponent<EnemyAI>();
        
        body = this.transform.gameObject;

    }

    private void Start()
    {
        //manager.enemyBodies.Add(this);
        startpos = this.transform.position;
        enemynavmesh.SetDestination(getRoamingPos(currentPos.position));
        destinationSet = true;
    }

    private void Update()
    {

   
        //if (Vector3.Distance (transform.position, DestinationBeacon.transform.position) < 5f)
        //{
        //    //destinationSet = false;
        //}
        currentPos = this.transform;
        if (destinationSet == false)
        {
            Vector3 temp = getRoamingPos(currentPos.position);
            Debug.Log(temp.ToString() + currentPos.ToString());
            temp.y = 0.0f;
            enemynavmesh.SetDestination(temp);
            enemynavmesh.navAgent.SetDestination(enemynavmesh.moveDestination.transform.position);
            destinationSet = true;

        }
        //set random interval and play random voiceLine
        if (Vector3.Distance(currentPos.position, enemynavmesh.moveDestination.transform.position) < 0.0f)
        {

            enemynavmesh.SetDestination(getRoamingPos(enemynavmesh.moveDestination.transform.position));

        }

        if (aI.state == EnemyAI.State.Roaming && Vector3.Distance(currentPos.position, playerCurrentPos.position) <= 100f)
        {
            aI.state = EnemyAI.State.ChaseTarget;
        }
        if (aI.state == EnemyAI.State.ChaseTarget && Vector3.Distance(currentPos.position, playerCurrentPos.position) <= fireRange)
        {
            aI.state = EnemyAI.State.ShootingTarget;
        }
        if (aI.state == EnemyAI.State.ShootingTarget && Vector3.Distance(currentPos.position, playerCurrentPos.position) >= fireRange)
        {

            aI.state = EnemyAI.State.ChaseTarget;
            if (Vector3.Distance(currentPos.position, playerCurrentPos.transform.position) > stopChasingDistance)
            {
                // Too far, stop chasing
                // resume to roaming area.
                aI.state = EnemyAI.State.Roaming;
            }

        }
        if (Vector3.Distance(currentPos.position, DestinationBeacon.transform.position) <= 3.0f)
        {
            aI.state = EnemyAI.State.Idle;
        }
    }

}
