using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField, Header("Objects")]
    private RoomLayout[] roomLayouts;

    [SerializeField]
    private Transform[] roomSpots;

    [SerializeField]
    private Pickup[] pickups;

    [SerializeField]
    private List<BoostPickup> boosts;

    [SerializeField, Header("Stats")]
    private int minimalPickups = 10;
    [SerializeField]
    private int maximumPickups = 10;
    [SerializeField]
    private int maxTry = 10;

    [SerializeField]
    private List<PickupSpot> pickupSpots;
    private int pickupAmount;

    private void Start()
    {
        pickupSpots = new List<PickupSpot>();
        BuildRooms();

        boosts = boosts.Where(boost => !BoostManager.Instance.HasSpawned(boost.Type)).ToList();
        InstantiateBoost();

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

    private int SetPresentAmount() {
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
    private void InstantiateBoost()
    {
        PickupSpot currentSpot = ChooseSpot(4);
        if (currentSpot == null)
            return;
        Pickup currentPickup = ChoosePickup(currentSpot.MaximumWeight, 0, boosts.ToArray());
        if (currentPickup == null)
            return;
        pickupSpots.Remove(currentSpot);
        currentPickup = Instantiate(currentPickup);
        if (currentPickup is BoostPickup)
            BoostManager.Instance.AddToSpawned((currentPickup as BoostPickup).Type);
        currentPickup.transform.SetParent(currentSpot.transform);
        ResetPosition(currentPickup.transform, false, true);
    }


    private PickupSpot ChooseSpot(int minWeight = 0) {

        var availibleSpots = pickupSpots;
        if (minWeight > 0)
        {
            availibleSpots = availibleSpots.Where(spot => spot.MaximumWeight >= minWeight).ToList();
        }

        int spotNumber = Random.Range(0, availibleSpots.Count);
        return availibleSpots[spotNumber];
    }

    private Pickup ChoosePickup(int maximumWeight, int currentTry = 0, Pickup[] pickups = null)
    {
        pickups = pickups ?? this.pickups;
        if (currentTry >= maxTry || pickups.Length == 0)
        {
            return null;
        }
        int pickupNumber = Random.Range(0, pickups.Length);
        Pickup currentPickup = pickups[pickupNumber].Weight <= maximumWeight ? pickups[pickupNumber] : ChoosePickup(maximumWeight, currentTry + 1, pickups);
        
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