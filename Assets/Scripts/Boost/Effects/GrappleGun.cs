using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : BoostEffect
{
    public override BoostType Type => BoostType.reach;

    [SerializeField]
    private BoxCollider collider;

    [SerializeField]
    private float sizeIncrease; 

    public override void Boost()
    {
        var center = collider.center;
        center.z += sizeIncrease/2;
        collider.center = center;

        var size = collider.size;
        size.z += sizeIncrease;
        collider.size = size;
    }
}
