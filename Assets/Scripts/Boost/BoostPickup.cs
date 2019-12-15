using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPickup : Pickup
{
    [SerializeField]
    private BoostType type;

    public void RegisterBoost()
    {
        BoostManager.Instance.RegisterBoost(type);
    }


}
