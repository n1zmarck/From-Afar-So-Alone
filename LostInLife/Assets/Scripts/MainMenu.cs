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

    private Ray ray;

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
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            if (hit.collider == true )
            {
                foreach (var item in buttons)
                {

                }
            }
        }
    }
}
