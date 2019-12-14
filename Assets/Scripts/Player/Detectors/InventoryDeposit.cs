using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDeposit : Detector
{
    [SerializeField]
    private LocalInventory localInventory;
    protected override void OnTriggerStay(Collider collider)
    {
        if (!CheckCollider(collider.gameObject) || !Input.GetKeyDown(KeyCode.Space)) return;
        localInventory.ExchangeAllToInventory(GlobalInventory.Instance);
        localInventory.ClearInventory();
    }
}
