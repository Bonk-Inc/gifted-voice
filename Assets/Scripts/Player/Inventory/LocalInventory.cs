﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalInventory : Inventory<Pickup>
{

    private int maxInventorySlots = 3;

    public int MaxInventorySlots { get => maxInventorySlots; set => maxInventorySlots = value; }

    private void Start()
    {
        if (GlobalInventory.Instance == null)
            return;

        GlobalInventory.Instance.ExchangeAllToInventory(this);
        GlobalInventory.Instance.ClearInventory();
    }

    public override void AddSingleSlot(Pickup item)
    {
        if(!CheckIfFull())
            base.AddSingleSlot(item);
    }

    public bool CheckIfFull()
    {
        return inventorySlots?.Count >= maxInventorySlots;
    }
}
