using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class following : MonoBehaviour
{
    public Transform player;         // The player object
    public float moveSpeed = 1f;     // The speed at which the object moves towards the player
    public float stoppingDistance = 0.5f; // The distance at which the object stops moving

    private void Update()
    {
        if (player != null)
        {
            // Calculate direction to the player
            Vector3 direction = player.position - transform.position;

            // Check if we are far enough to keep moving
            if (direction.magnitude > stoppingDistance)
            {
                // Normalize the direction vector and move towards the player
                direction.Normalize();

                // Move the object
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    }
}

