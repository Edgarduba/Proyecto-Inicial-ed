using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public PlayerMovements controller;
    public float speed = 5f;
    float dirX;
    Rigidbody2D _rBody;


    void Awake()
    {
        
        
        _rBody = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        Debug.Log(dirX);
    }


    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirX * speed, _rBody.velocity.y);

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
