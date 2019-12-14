using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public event Action PickedUp;

    protected virtual void OnPickedUp()
    {
        print("Pick me up ;)");
        PickedUp?.Invoke();
    }
}
