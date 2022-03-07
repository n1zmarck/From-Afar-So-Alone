using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : EnemyManager
{
    public Enemy enemy;
    public EnemyNavMesh enemynavmesh;
    public GameObject body;
    public EnemyManager manager;
    public Transform currentPos;
    public GameObject DestinationBeacon;
    public EnemyAI aI;
    public bool destinationSet;


    public float fireRange = 50f;

    private Vector3 startpos;
    private Vector3 roamPos;
    // Start is called before the first frame update

    public Vector3 GetRandomdirec()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    public Vector3 getRoamingPos()
    {
        return startpos + GetRandomdirec() * Random.Range(10f, 90f);
    }

    private void Awake()
    {
        GetComponent<Enemy>();
        GetComponent<EnemyNavMesh>();
        GetComponent<EnemyManager>();
        GetComponent<EnemyAI>();
        
        body = this.transform.gameObject;
        //DestinationBeacon.transform.position = currentPos.position;

    }

    private void Start()
    {
        manager.enemyBodies.Add(this);
        startpos = this.transform.position;
        //enemynavmesh.SetDestination(getRoamingPos());
        //destinationSet = true;
    }

    private void Update()
    {

    }

}
