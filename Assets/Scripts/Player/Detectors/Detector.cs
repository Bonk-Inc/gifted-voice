using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detector : MonoBehaviour
{
    [SerializeField]
    protected LayerMask colliderLayer;

    protected abstract void OnTriggerStay(Collider collider);

    protected bool CheckCollider(GameObject collider)
    {
        return (((1 << collider.gameObject.layer) & colliderLayer) != 0);
    }
}