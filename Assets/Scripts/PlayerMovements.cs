using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovements : MonoBehaviour
{
    //public PlayerMovements controller;
    private CharacterController controller;
    public float runSpeed = 2f;
    private Rigidbody2D body;
    private float horizontal;
    public PlayableDirector director;
    private Animator anim;



    public float sensorRadius = 0.1f;
    private Vector2 playerVelocity;
    public Transform groundSensor;
    public LayerMask ground;
    public float jumpForce = 20;
    public float jumpHeight = 1;
    private float gravity = -9.81f;
    public bool isGrounded;



    void Jump()
    {
        //isGrounded = controller.isGrounded;
        isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, ground);
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //playerVelocity.y += jumpForce;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    


    void Start() 
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

      
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal == 0)
        {
            anim.SetBool("Correr", false);
        }
        else
        {
            anim.SetBool("Correr", true);
        }

        Jump();
        
    }


    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Cinematica")
        {
            director.Play();
        }
        
    }
    




 /*
    private Transform playerTransform;
    
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //playerTransform.position += new Vector3 (horizontal * speed * Time.deltaTime, 0, 0);

        //playerTransform.Translate(Vector3.right * horizontal * speed * Time.deltaTime, Space.World);

        
    }
*/
}
