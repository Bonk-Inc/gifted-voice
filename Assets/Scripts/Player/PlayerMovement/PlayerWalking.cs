using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : RigidbodyManipulator
{

    [SerializeField]
    private float speed;

    void Update() {
        rb.velocity = transform.forward * speed * Input.GetAxis("Vertical"); 
    }
}
