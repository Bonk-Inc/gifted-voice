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
        if (WorldStateMachine.Instance)
            SetFloor(WorldStateMachine.Instance.currentFloor);
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
        if(floor >= floors.Length) {
            LastFloorCompleted?.Invoke();
            WorldStateMachine.Instance.EndGame(true);
            return;
        }

        currentFloor = floor;
        if(WorldStateMachine.Instance)
            WorldStateMachine.Instance.currentFloor = currentFloor;
        floors[currentFloor].TeleportPlayer(player);
    }

}
