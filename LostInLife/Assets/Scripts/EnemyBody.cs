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
        body = this.transform.gameObject;
    }

    private void Start()
    {
        manager.enemyBodies.Add(this);
        startpos = this.transform.position;
        enemynavmesh.SetDestination(getRoamingPos());
    }

    private void Update()
    {
        currentPos = this.transform;
        if (currentPos = enemynavmesh.moveDestination)
        {
            enemynavmesh.SetDestination(getRoamingPos());
        }
    }

}
