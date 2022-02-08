using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using System.IO;
using System.Threading.Tasks;

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

    public void continueGame()
    {
        isGamePaused = !isGamePaused;
        pausemenu.gameObject.SetActive(!pausemenu.isActiveAndEnabled);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsMenu.gameObject.activeInHierarchy == false)
        {
            isGamePaused = !isGamePaused;
            pausemenu.gameObject.SetActive(!pausemenu.isActiveAndEnabled);
        }
    }

    public void returntoMainmenu()
    {
        
        
        SceneManager.LoadSceneAsync("mainmenu");
  

    }

    public void startSettings ()
    {
        settingsMenu.gameObject.SetActive(true);
        pausemenu.gameObject.SetActive(false);
    }
}
