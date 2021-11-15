using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float mouseSensitivity = 1000f;
    private Vector3 LastMousePosition;
    // Start is called before the first frame update

    private RaycastHit hit;

    public Transform playerBody;

    float xRotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetMouseButton(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f))
            {

                // Then you could find your GO with a specific tag by doing something like:
                if (hit.collider.tag == "Head")
                {
                    Debug.Log("HeadShot!");
                    hit.collider.transform.parent.gameObject.SetActive(false);
                }
                else if (hit.collider.tag == "UpperTorso")
                {
                    Debug.Log("ChestHit!");
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }



}
