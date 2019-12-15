using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayout : MonoBehaviour
{
    [SerializeField]
    private PickupSpot[] pickupSpots;

    public PickupSpot[] PickupSpots { get => pickupSpots; }
}
