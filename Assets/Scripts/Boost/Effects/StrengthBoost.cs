using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBoost : BoostEffect
{
    public override BoostType Type => BoostType.strengh;

    [SerializeField]
    private PlayerWalking playerWalking;

    [SerializeField]
    private int addedStrength;

    public override void Boost()
    {
        playerWalking.MaxWeight += addedStrength;
    }
}
