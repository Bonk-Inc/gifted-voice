using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public event Action PickedUp;

    public virtual void OnPickedUp()
    {
        print("Pick me up ;)");
        PickedUp?.Invoke();
    }
}
