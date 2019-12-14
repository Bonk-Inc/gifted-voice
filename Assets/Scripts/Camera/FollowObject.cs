using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float followSpeed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, followSpeed * Time.deltaTime);
    }

}
