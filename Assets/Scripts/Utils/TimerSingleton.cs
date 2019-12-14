using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSingleton : Timer
{
    private static TimerSingleton instance = null;

    public static TimerSingleton Instance { get => instance; }

    private void Awake()
    {
        if (TimerSingleton.instance)
            Destroy(this);
        else
            instance = this;
    }
}
