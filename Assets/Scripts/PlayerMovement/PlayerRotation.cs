using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRotation : RigidbodyManipulator
{

    public float rotationSpeed = 9f;

    void Update()
    {
        float yRotation = transform.localEulerAngles.y;
        yRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        var rot = transform.localEulerAngles;
        rot.y = yRotation;
        transform.localEulerAngles = rot;
    }

}
