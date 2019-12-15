using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartment : MonoBehaviour
{
    [SerializeField]
    private PresentPlacementHandler[] placementHandlers;

    public void SetId(int floorId, int apartmentId)
    {
        for (int i = 0; i < placementHandlers.Length; i++)
        {
            placementHandlers[i].SetId(floorId, apartmentId, i);
        }
    }


}
