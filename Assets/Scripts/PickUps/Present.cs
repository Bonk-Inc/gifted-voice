using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : Pickup
{
    [SerializeField]
    private PresentType presentType;

    public PresentType PresentType { get => presentType; }
}
