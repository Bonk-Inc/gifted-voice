using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDeposit : Detector
{
    [SerializeField]
    private LocalInventory localInventory;

    private Collider collider;

    protected void OnTriggerEnter(Collider collider)
    {
        if (CheckCollider(collider.gameObject))
            this.collider = collider;
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckCollider(other.gameObject))
            this.collider = null;
    }

    protected override void OnTriggerStay(Collider collider)
    {
        
    }

    private void Update()
    {
        if (collider == null || !Input.GetKeyDown(KeyCode.Space)) return;
        localInventory.ExchangeAllToInventory(GlobalInventory.Instance);
        localInventory.ClearInventory();
    }
}
