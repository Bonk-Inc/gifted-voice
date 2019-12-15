using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : BoostEffect
{
    public override BoostType Type => BoostType.speed;

    [SerializeField]
    private PlayerWalking playerWalking;

    [SerializeField]
    private float speedAddition;

    public override void Boost()
    {
        playerWalking.AddSpeed(speedAddition);
    }
}
