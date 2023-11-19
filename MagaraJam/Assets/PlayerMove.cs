using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;
    Vector2 movement;

    void Update()
    {


        getMoveInput();
       
    }

    private void FixedUpdate()
    {
        // Move the player
        MovePlayer(movement);
    }

    void getMoveInput()
    {
        // Get input from the arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the movement vector to ensure constant speed in all directions
        movement.Normalize();
    }

    void MovePlayer(Vector2 movement)
    {
        // Get the Rigidbody2D component attached to the GameObject
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Move the player
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
}


