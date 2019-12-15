using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : Pickup
{
    [SerializeField]
    private PresentType type;
    public PresentType Type { get => type; }
}
