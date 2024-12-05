using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float moveSpeed = 5f; // Base movement speed
    public float sprintSpeed = 10f; // Speed while sprinting
    public float acceleration = 15f; // How quickly to reach the target speed
    public float deceleration = 100f; // How quickly to come to a stop

    public Vector2 currentVelocity; // Current velocity of the player
    private Vector2 movementInput; // Current input from the player

    void Update()
    {
        // Get input from keyboard
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        // Handle sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementInput *= sprintSpeed;
        }
        else
        {
            movementInput *= moveSpeed;
        }

        // Normalize to prevent faster diagonal movement
        if (movementInput.magnitude > 3f)
        {
            movementInput = new Vector2(movementInput.x / 1.5f,movementInput.y / 1.5f);
        }

        // Update velocity based on input and acceleration
        if (movementInput != Vector2.zero)
        {
            currentVelocity = Vector2.MoveTowards(currentVelocity, movementInput, (5 + acceleration) * Time.deltaTime);
            if (currentVelocity.x > 20f)
            {
                currentVelocity.x = 20f;
            }
            else if (currentVelocity.y > 17f)
            {
                currentVelocity.y = 17f;
            }
        }
        else
        {
            currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration * Time.deltaTime);
        }

        MoveCharacter();
    }

    private void MoveCharacter()
    {
        // Move the character
        Vector3 move = new Vector3(currentVelocity.x, currentVelocity.y, 0) * Time.deltaTime;
        transform.position += move;
    }
}

