using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rammus : MonoBehaviour
{
    public float moveSpeed = 20f; // Adjust this to set the movement speed
    public float jumpForce = 10f; // Adjust this to set the jump force


    private Rigidbody2D rb;

    private bool GroundCheck = false;
  
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerMovement();
    }


    void playerMovement()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Jumping
        if (GroundCheck && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            GroundCheck = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            GroundCheck = true;
        }
    }
}
