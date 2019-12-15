using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalInventory : Inventory<Pickup>
{
    private static GlobalInventory instance = null;

    public static GlobalInventory Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if (GlobalInventory.Instance)
            Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public override void AddMultipleSlots(Pickup[] item)
    {
        base.AddMultipleSlots(item);
        for (int i = 0; i < item.Length; i++)
        {
            SavePickup(item[i]);
        }
    }

    public override void AddSingleSlot(Pickup item)
    {
        base.AddSingleSlot(item);
        SavePickup(item);
    }

    public override void RemoveSlot(int slotNumber)
    {
        RemovePickup(slotNumber);
        base.RemoveSlot(slotNumber);
    }

    public override void ClearInventory()
    {
        for (int i = 0; i < Count; i++)
        {
            RemovePickup(i);
        }
        
        base.ClearInventory();
    }

    private void SavePickup(Pickup pickup)
    {
        pickup.transform.SetParent(transform);
    }

    private void RemovePickup(int number)
    {
        GetInventorySlot(number).transform.SetParent(null);
        SceneManager.MoveGameObjectToScene(GetInventorySlot(number).gameObject, SceneManager.GetActiveScene());
    }
}