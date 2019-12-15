using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpot : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    private int maximumWeight = 1;

    private bool isAvailable = true;

    public int MaximumWeight { get => maximumWeight; }
    public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
}
