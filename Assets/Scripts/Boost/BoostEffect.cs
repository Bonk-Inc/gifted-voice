using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoostEffect : MonoBehaviour
{
    public abstract BoostType Type { get; }

    public abstract void Boost();
}
