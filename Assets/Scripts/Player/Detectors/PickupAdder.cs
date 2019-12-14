using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAdder : Detector
{
    [SerializeField]
    private LocalInventory inventory;

    protected override void OnTriggerStay(Collider collider)
    {
        if(!CheckCollider(collider.gameObject) || !Input.GetKeyDown(KeyCode.Space)) return;

        if (inventory.CheckIfFull()) return;

        Pickup newpickup = collider.gameObject.GetComponent<Pickup>();
        newpickup?.OnPickedUp();
        inventory.AddSingleSlot(newpickup);
        collider.gameObject.SetActive(false);
    }
}
