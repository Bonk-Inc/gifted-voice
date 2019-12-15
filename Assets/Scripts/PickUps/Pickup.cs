using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    private int weight = 1;
    public int Weight { get => weight; }

    public event Action PickedUp;

    public virtual void OnPickedUp()
    {
        PickedUp?.Invoke();
    }
}
