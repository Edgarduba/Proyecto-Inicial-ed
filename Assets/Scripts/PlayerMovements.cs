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
    private float vertical;
    public PlayableDirector director;
    private Animator anim;
    


    public float sensorRadius = 0.1f;
    private Vector2 playerVelocity;
    public Transform groundSensor;
    public LayerMask ground;
    public float jumpForce = 20f;
    //public float jumpHeight = 1;
    //private float gravity = -9.81f;
    public bool isGrounded = false;
    private Transform playerTransform;


     private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    void Jump()
    {
        //isGrounded = controller.isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, ground);
        
        if(Input.GetButtonDown("jump") && isGrounded)
        { 
            body.AddForce(Vector2.up * jumpForce);
            anim.SetBool("jump" , true);
        }
        else 
        {
            anim.SetBool("jump" , false);
        }
        if(isGrounded = true) 
        {
            Debug.Log("Suelo");
        }
        
    }
    


    /*void Start() 
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }*/

      
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); 
        Jump();
        //GameManager.Instance.RestarVidas();
        //GameManager.Instance.vidas;
        //Global.nivel = 1;
       
    }


    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, 0);

        horizontal = Input.GetAxisRaw("Horizontal");
        body = GetComponent<Rigidbody2D>();

        if(horizontal == 0)
        {
            anim.SetBool("run", false);
    
        }
        else if (horizontal == 1)
        {
            anim.SetBool("run", true);
            playerTransform.rotation =Quaternion.Euler(0, 0,0);
        }
        else if (horizontal == -1)
        {
            anim.SetBool("run", true);
            playerTransform.rotation =Quaternion.Euler(0, -180,0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Cinematica")
        {
            director.Play();
        }
        if(other.gameObject.layer == 6)
        {
            //GameManager.Instance.RestarVidas();
            StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake());
            Destroy(other.gameObject);
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
