using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private PlayerFloorController elevator;

    [SerializeField]
    private Floor currentFloor;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player") || !currentFloor.FloorCompleted() || !Input.GetKeyDown(KeyCode.Space))
            return;
        
        elevator.NextFloor();
    }


}
