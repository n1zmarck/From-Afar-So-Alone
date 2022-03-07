using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyBody> enemyBodies;
    private int numberofBodiesinlevel = 0;
    public Transform playerCurrentPos;
    public float stopChasingDistance = 150f;
    // Start is called before the first frame update



    void Awake()
    {
        //enemyBodies.Add(FindObjectOfType<EnemyBody>);
        playerCurrentPos = GetComponent<Transform>();
        numberofBodiesinlevel = enemyBodies.Count;
    }

    public Vector3 getRoamingPos(Vector3 startpos)
    {
        return startpos + GetRandomdirec() * Random.Range(1f, 5f);
    }
    public Vector3 GetRandomdirec()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in enemyBodies)
        {
            if (enemy.enemy.health <= 0)
            {
                Debug.Log("Enemy Killed and should despawn");

                Destroy(enemy.transform.gameObject);
                //push force for ragdoll

                enemyBodies.Remove(enemy);
            }
            //if close to player distance and facing them, switch state to chase and attack
            enemy.currentPos = enemy.transform;
            if (enemy.destinationSet == false)
            {
                Vector3 temp = getRoamingPos(enemy.currentPos.position);
                Debug.Log(temp);
                temp.y = 0.0f;
                enemy.enemynavmesh.SetDestination(temp);
                enemy.enemynavmesh.navAgent.SetDestination(enemy.enemynavmesh.moveDestination.transform.position);
                enemy.destinationSet = true;

            }
            //set random interval and play random voiceLine
            if (Vector3.Distance(enemy.currentPos.position,enemy.enemynavmesh.moveDestination.transform.position) < 20.0f)
            {

                enemy.enemynavmesh.SetDestination(getRoamingPos(enemy.enemynavmesh.moveDestination.transform.position));

            }

            if (enemy.aI.state == EnemyAI.State.Roaming && Vector3.Distance(enemy.currentPos.position,playerCurrentPos.position) <= 100f)
            {
                enemy.aI.state = EnemyAI.State.ChaseTarget;
            }
            if (enemy.aI.state == EnemyAI.State.ChaseTarget && Vector3.Distance(enemy.currentPos.position,playerCurrentPos.position) <= enemy.fireRange)
            {
                enemy.aI.state = EnemyAI.State.ShootingTarget;
            }
            if (enemy.aI.state == EnemyAI.State.ShootingTarget && Vector3.Distance(enemy.currentPos.position, playerCurrentPos.position) >= enemy.fireRange)
            {

                enemy.aI.state = EnemyAI.State.ChaseTarget;
                if (Vector3.Distance(enemy.currentPos.position, playerCurrentPos.transform.position) > stopChasingDistance)
                {
                    // Too far, stop chasing
                    // resume to roaming area.
                    enemy.aI.state = EnemyAI.State.Roaming;
                }

            }
        }
    }


}
