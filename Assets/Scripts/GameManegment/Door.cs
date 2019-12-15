using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private PlayerFloorController elevator;

    [SerializeField]
    private Floor currentFloor;

    private Collider other;

    protected void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        this.other = other;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        this.other = null;
    }

    private void Update()
    {
        if (other == null || !other.CompareTag("Player") || !currentFloor.FloorCompleted() || !Input.GetKeyDown(KeyCode.Space))
            return;

        elevator.NextFloor();
    }

    private void OnTriggerStay(Collider other)
    {
        
    }


}
