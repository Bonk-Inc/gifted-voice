using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : BoostEffect
{
    public override BoostType Type => BoostType.reach;

    [SerializeField]
    private BoxCollider reachCollider;

    [SerializeField]
    private float sizeIncrease; 

    public override void Boost()
    {
        var center = reachCollider.center;
        center.z += sizeIncrease/2;
        reachCollider.center = center;

        var size = reachCollider.size;
        size.z += sizeIncrease;
        reachCollider.size = size;
    }
}
