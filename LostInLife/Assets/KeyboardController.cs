using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{



    public Transform Player;
    private float PlayerMovementFactor = 0.05f;
    // Start is called before the first frame update

    [Header("CheatStuff")]
    public GameObject mobTarget;
    public GameObject mobTargetTorso;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Player.position += Vector3.forward*PlayerMovementFactor;
        }else if (Input.GetKey(KeyCode.A))
        {
            Player.position += Vector3.left*PlayerMovementFactor;
        } else if (Input.GetKey(KeyCode.S))
        {
            Player.position += Vector3.back*PlayerMovementFactor;
        } else if (Input.GetKey(KeyCode.D))
        {
            Player.position += Vector3.right*PlayerMovementFactor;
        }else if (Input.GetKey(KeyCode.R) && mobTarget.gameObject.activeInHierarchy == false)
        {
            mobTarget.gameObject.SetActive(true);
            mobTargetTorso.gameObject.SetActive(true);
            
        }

      
    }
}
