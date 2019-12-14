using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : Pickup
{
    [SerializeField]
    private PresentType type;
    [SerializeField, Range(0,5)]
    private int weight = 1;

    public PresentType Type { get => type; }
    public int Weight { get => weight;}
}
