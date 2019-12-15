using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownDetector : Detector
{
    [SerializeField]
    private LocalInventory inventory;

    private Collider collider;

    protected override void OnTriggerStay(Collider collider)
    {
        

    }

    protected void OnTriggerEnter(Collider collider)
    {
        this.collider = collider; 
    }

    private void OnTriggerExit(Collider other)
    {
        this.collider = null;
    }

    private void Update()
    {
        if (collider == null  || !CheckCollider(collider.gameObject) || !Input.GetKeyDown(KeyCode.Space)) return;

        PresentPlacementHandler placement = collider.GetComponent<PresentPlacementHandler>();

        if (placement == null)
            return;

        Present present = null;

        for (int i = 0; i < inventory.Count; i++)
        {
            var currentPickup = inventory.GetInventorySlot(i);
            if (!(currentPickup is Present)) continue;

            var currentPresent = currentPickup as Present;
            if (!placement.CheckRequirements(currentPresent)) continue;

            present = PickPresent(i, inventory) as Present;
            break;
        }

        placement.PlacePresent(present);
        this.collider = null;
    }

    private Pickup PickPresent(int index, Inventory<Pickup> inventory)
    {
        var present = inventory.GetInventorySlot(index);
        inventory.RemoveSlot(index);
        return present;
    }
}
