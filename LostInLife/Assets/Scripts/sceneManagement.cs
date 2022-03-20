using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagement : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            //Camera.current
            // camera fades to black.
            SceneManager.LoadScene("Main menu");
        }

    }
}
