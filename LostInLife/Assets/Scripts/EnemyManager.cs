using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyBody> enemyBodies;
    private int numberofBodiesinlevel = 0;
    public Transform playerCurrentPos;
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
                enemy.enemynavmesh.navAgent.SetDestination(enemy.enemynavmesh.moveDestination.position);
                enemy.destinationSet = true;

            }// if enemy close to beacon change beacon position.
            //if (enemy.enemynavmesh.moveDestination == null)
            //{
            //    enemy.DestinationBeacon.transform.position = getRoamingPos(enemy.currentPos.position);
            //    enemy.enemynavmesh.SetDestination(getRoamingPos(enemy.currentPos.position));
            //    enemy.enemynavmesh.navAgent.speed = (enemy.enemy.getSpeed(enemy.enemy.health));
            //}
            //set random interval and play random voiceLine


            //debugtool
        }
    }
}
