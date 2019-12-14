using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detector : MonoBehaviour
{
    [SerializeField]
    protected int colliderLayer;

    protected abstract void OnTriggerStay(Collider collider);
}