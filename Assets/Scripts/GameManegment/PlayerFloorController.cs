using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloorController : MonoBehaviour
{

    [SerializeField]
    private int currentFloor = 0;

    [SerializeField]
    private Floor[] floors;

    [SerializeField]
    private GameObject player;

    public event Action LastFloorCompleted;

    public void NextFloor()
    {
        SetFloor(currentFloor + 1);
    }

    public void SetFloor(int floor)
    {
        if(currentFloor >= floors.Length) {
            LastFloorCompleted?.Invoke();
            return;
        }

        currentFloor = floor;
        floors[currentFloor].TeleportPlayer(player);
    }

}
