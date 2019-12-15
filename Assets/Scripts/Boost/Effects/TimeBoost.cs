using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBoost : BoostEffect
{
    public override BoostType Type => BoostType.time;

    [SerializeField]
    private float addedTime;

    public override void Boost()
    {
        TimerSingleton.Instance?.ChangeTimeLeft(addedTime);
    }
}
