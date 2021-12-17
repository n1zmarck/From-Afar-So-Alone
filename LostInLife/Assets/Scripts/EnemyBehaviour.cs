using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private Vector3 startpos;
    private Vector3 roamPos;
    // Start is called before the first frame update

    private Vector3 GetRandomdirec()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 getRoamingPos()
    {
      return startpos + GetRandomdirec() * Random.Range(10f, 90f);
    }

    void Start()
    {
        startpos = transform.position;
        roamPos = getRoamingPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
