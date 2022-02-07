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
    }

    private void Update()
    {
        currentPos = this.transform;
    }
}
