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

    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in enemyBodies)
        {
            if (enemy.enemy.health <= 0)
            {
                Destroy(enemy.transform.gameObject);
                enemyBodies.Remove(enemy);
            }
            //if close to player distance and facing them, switch state to chase and attack

            //set random interval and play random voiceLine
        }
    }
}
