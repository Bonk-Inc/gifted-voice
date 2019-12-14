using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}