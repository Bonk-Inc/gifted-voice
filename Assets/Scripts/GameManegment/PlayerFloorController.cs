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

    private void Start()
    {
        for (int i = 0; i < floors.Length; i++)
        {
            floors[i].SetId(i);
        }
    }

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
