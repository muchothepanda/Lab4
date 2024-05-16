using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float move;
    public float speed;
    public float jump;
    
    public bool Isgrounded;

    
    void Start()
    {
       rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (move* speed, rb.velocity.y);
       
           
       
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && (Isgrounded==false))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Isgrounded = false;
        }
    }
    
    
    
}
