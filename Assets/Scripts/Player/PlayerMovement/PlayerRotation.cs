using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRotation : RigidbodyManipulator
{

    [SerializeField]
    private float rotationSpeed = 3;

    private void FixedUpdate()
    {
        var rot = rb.rotation.eulerAngles;
        rot.y += Input.GetAxis("Horizontal") * 3;
        rb.rotation = Quaternion.Euler(rot);
    }

}
