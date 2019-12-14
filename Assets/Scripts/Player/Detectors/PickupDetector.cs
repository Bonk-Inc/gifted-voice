using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDetector : Detector
{

    [SerializeField]
    private LocalInventory inventory;

    protected override void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer != colliderLayer || !Input.GetKeyDown(KeyCode.Space))
            return;

        Pickup newpickup = collider.gameObject.GetComponent<Pickup>();
        newpickup?.OnPickedUp();
        inventory.AddSingleSlot(newpickup);

        collider.gameObject.SetActive(false);
    }
}
