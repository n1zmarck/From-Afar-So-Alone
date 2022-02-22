using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button[] buttons;
    public Text newgameorContgame;
    // add buttons into array


   public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("CurrentPlayerLevel",-1) > -1)
        {
            newgameorContgame.text = "New Game";
        }


    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
