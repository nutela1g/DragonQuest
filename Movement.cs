using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovementSpeed = 5.2f;
    public GameObject Character;
    private Vector3 Velocity;

    void Update()
    {
        var PosX = Input.GetAxisRaw("Horizontal");
        var PosY = Input.GetAxisRaw("Vertical");
        Velocity = new Vector3(PosX, PosY, 1) * MovementSpeed;
    }

    private void FixedUpdate()
    {
        Character.transform.position = Character.transform.position + Velocity * Time.fixedDeltaTime;
    }
}
