using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyManipulator : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody rb;

    private void Reset()
    {
        rb = GetComponent<Rigidbody>();
    }
}
