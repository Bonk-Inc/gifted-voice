using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAdder : Detector
{
    [SerializeField]
    private LocalInventory inventory;

    private Collider collider;

    protected void OnTriggerEnter(Collider collider)
    {
        this.collider = collider;
    }

    private void OnTriggerExit(Collider other)
    {
        this.collider = null;
    }

    protected override void OnTriggerStay(Collider collider)
    {
    }

    private void Update()
    {
        if (collider == null || !CheckCollider(collider.gameObject) || !Input.GetKeyDown(KeyCode.Space)) return;

        if (inventory.CheckIfFull()) return;

        Pickup newpickup = collider.gameObject.GetComponent<Pickup>();
        newpickup?.OnPickedUp();
        inventory.AddSingleSlot(newpickup);
        collider.gameObject.SetActive(false);
        collider = null;
    }
}
