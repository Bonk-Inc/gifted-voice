using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDetector : MonoBehaviour
{
    [SerializeField]
    private int colliderLayer;

    [SerializeField]
    private LocalInventory inventory;

    private void OnColliderStay(Collision collider)
    {
        if (collider.gameObject.layer != colliderLayer || !Input.GetKeyDown(KeyCode.Space) )
            return;

        Pickup newpickup = collider.gameObject.GetComponent<Pickup>();
        newpickup?.OnPickedUp();
        inventory.AddSingleSlot(newpickup);
    }
}
