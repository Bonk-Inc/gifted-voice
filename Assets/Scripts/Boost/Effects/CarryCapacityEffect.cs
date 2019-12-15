using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryCapacityEffect : BoostEffect
{
    [SerializeField]
    private LocalInventory inventory;

    [SerializeField]
    private int addedCapacity;

    public override BoostType Type => BoostType.carryCapacity;

    public override void Boost()
    {
        inventory.MaxInventorySlots += addedCapacity;
    }
}
