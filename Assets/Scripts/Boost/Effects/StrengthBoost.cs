using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBoost : BoostEffect
{
    public override BoostType Type => BoostType.strengh;

    [SerializeField]
    private float addedStrength;

    public override void Boost()
    {
        //TODO implement (:
    }
}
