using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public bool isGamePaused = false;
    public Canvas pausemenu;
    public Canvas settingsMenu;
    
    // Start is called before the first frame update
    void Start()
    {

        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            pausemenu.gameObject.SetActive(!pausemenu.isActiveAndEnabled);
        }
    }


    public void startSettings ()
    {
        settingsMenu.gameObject.SetActive(true);
        pausemenu.gameObject.SetActive(false);
    }
}
