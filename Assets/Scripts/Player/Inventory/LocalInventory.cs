using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalInventory : Inventory<Pickup>
{

    private int maxInventorySlots = 3;

    public int MaxInventorySlots { get => maxInventorySlots; set => maxInventorySlots = value; }

    private void Start()
    {
        GlobalInventory.Instance.ExchangeAllToInventory(this);
        GlobalInventory.Instance.ClearInventory();
    }

    public override void AddSingleSlot(Pickup item)
    {
        if(inventorySlots?.Count <= maxInventorySlots)
            base.AddSingleSlot(item);
    }
}
