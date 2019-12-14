using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory<T> : MonoBehaviour
{

    protected List<T> inventorySlots = new List<T>();

    public virtual T GetInventorySlot(int slotNumber)
    {
        return inventorySlots[slotNumber];
    }

    public virtual T[] GetAllSlots()
    {
        return inventorySlots.ToArray();
    }

    public virtual void AddSingleSlot(T item)
    {
        inventorySlots.Add(item);
    }

    public virtual void AddMultipleSlots(T[] item)
    {
        inventorySlots.AddRange(item);
    }

    public virtual void RemoveSlot(int slotNumber)
    {
        inventorySlots.RemoveAt(slotNumber);
    }

    public virtual void ClearInventory()
    {
        inventorySlots.Clear();
    }

    public virtual void ExchangeSlotToInventory(Inventory<T> nextInventory, T item)
    {
        nextInventory.AddSingleSlot(item);
    }

    public virtual void ExchangeAllToInventory(Inventory<T> nextInventory)
    {
        nextInventory.AddMultipleSlots(inventorySlots.ToArray());
    }
}
