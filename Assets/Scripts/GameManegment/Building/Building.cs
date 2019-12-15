using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField, Header("Objects")]
    private RoomLayout[] roomLayouts;

    [SerializeField]
    private Transform[] roomSpots;

    [SerializeField]
    private Pickup[] pickups;

    [SerializeField, Header("Stats")]
    private int minimalPickups = 10;
    [SerializeField]
    private int maximumPickups = 10;
    [SerializeField]
    private int maxTry = 10;
    private List<PickupSpot> pickupSpots;
    private int pickupAmount;

    private void Start()
    {
        pickupSpots = new List<PickupSpot>();
        BuildRooms();

        pickupAmount = SetPresentAmount();
        InstantiatePickups();

    }

    private void BuildRooms()
    {
        for (int i = 0; i < roomSpots.Length; i++)
        {
            int random = Random.Range(0, roomLayouts.Length);
            RoomLayout newRoom = Instantiate(roomLayouts[random]);
            newRoom.transform.SetParent(roomSpots[i]);

            ResetPosition(newRoom.transform);

            pickupSpots.AddRange(newRoom?.PickupSpots);
        }
    }

    private int SetPresentAmount()
    {
        return Random.Range(minimalPickups, maximumPickups);
    }

    private void InstantiatePickups()
    {
        for (int i = 0; i < pickupAmount; i++)
        {
            PickupSpot currentSpot = ChooseSpot();
            pickupSpots.Remove(currentSpot);
            Pickup currentPickup = ChoosePickup(currentSpot.MaximumWeight);

            currentPickup = Instantiate(currentPickup);

            currentPickup.transform.SetParent(currentSpot.transform);
            ResetPosition(currentPickup.transform, false, true);
        }
    }

    private PickupSpot ChooseSpot() {
        int spotNumber = Random.Range(0, pickupSpots.Count);
        return pickupSpots[spotNumber];
    }

    private Pickup ChoosePickup(int maximumWeight, int currentTry = 0)
    {
        if (currentTry >= maxTry)
        {
            return null;
        }
        int pickupNumber = Random.Range(0, pickups.Length);
        Pickup currentPickup = pickups[pickupNumber].Weight <= maximumWeight ? pickups[pickupNumber] : ChoosePickup(maximumWeight, currentTry + 1);
        
        return currentPickup;
    }

    private void ResetPosition(Transform transform, bool resetScale = true, bool placeOnGround = false)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        if(resetScale) transform.localScale = Vector3.one;
        if (placeOnGround)
        {
            MeshRenderer pickupRenderer = transform.GetComponentInChildren<MeshRenderer>();
            transform.Translate(0, pickupRenderer.bounds.extents.y, 0);
        }
    }
}