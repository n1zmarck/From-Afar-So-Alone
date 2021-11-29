using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.02f;
    public LayerMask groundmask;
    bool isGrounded;
    private float GravSystem = -14.81f;
    Vector3 velocity;

    public Transform Player;
    private float PlayerMovementFactor = 12f;
    private float DefaultMovementFactor = 12f;
    public float PlayerJumpHeight = 12.4f;


    // Start is called before the first frame update


    float defaultHeight;

    private void Start()
    {
        defaultHeight = controller.height;
    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        if (isGrounded == true && Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = controller.height / 2;
            controller.center = new Vector3(0,-controller.height,0);
            PlayerMovementFactor = 6f;
        }
        //else if (isGrounded == true && Input.GetKey(KeyCode.Z))
        //{
        //    controller.height = controller.height / 4;
        //    PlayerMovementFactor = 3f;
        //}
        //else if (isGrounded == true && Input.GetKey(KeyCode.LeftShift))
        //{
        //    // sprinting
        //    PlayerMovementFactor = 17f;
        //}
        else
        {
            controller.center = new Vector3(0,controller.height,0);
            controller.height = defaultHeight;
            PlayerMovementFactor = DefaultMovementFactor;
        }


        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(PlayerJumpHeight * -2f * GravSystem);o
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    velocity.y = Mathf.Sqrt(PlayerJumpHeight * -2f * GravSystem);
        //}



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move* PlayerMovementFactor * Time.deltaTime);


        velocity.y += GravSystem * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

      
    }
}
