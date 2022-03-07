using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float mouseSensitivity = 1200f;
    private Vector3 LastMousePosition;
    // Start is called before the first frame update

    //insert weapon script here

    public Canvas pausemenu, settingsmenu;

    private RaycastHit hit;

    public Transform playerBody;

    float xRotation = 0f;

    public PauseMenu pause;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (pause.isGamePaused == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
            
            
        
        if (pausemenu.isActiveAndEnabled == true || settingsmenu.isActiveAndEnabled == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (pausemenu.isActiveAndEnabled == false && settingsmenu.isActiveAndEnabled == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


    }



}
