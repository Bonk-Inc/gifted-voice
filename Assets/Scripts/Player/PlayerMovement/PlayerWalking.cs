using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : RigidbodyManipulator
{

    [SerializeField]
    private float speed;

    void Update() {

        var velocity = Vector3.zero;
        velocity += transform.forward * speed * Input.GetAxis("Vertical");
        velocity += transform.right * speed * Input.GetAxis("Horizontal");


        if (velocity.magnitude > speed)
        {
            velocity.Normalize();
            velocity *= speed;
        }
        rb.velocity = velocity;
    }
}
