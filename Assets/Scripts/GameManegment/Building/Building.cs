using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    private GameObject[] roomLayouts;

    [SerializeField]
    private Transform[] roomSpots;

    private void Start()
    {
        for (int i = 0; i < roomSpots.Length; i++)
        {
            int random = Random.Range(0, roomLayouts.Length);
            GameObject newRoom = Instantiate(roomLayouts[random]);
            newRoom.transform.SetParent(roomSpots[i]);

            ResetPosition(newRoom);
        }
    }

    private void ResetPosition(GameObject room)
    {
        room.transform.localPosition = Vector3.zero;
        room.transform.localRotation = Quaternion.identity;
        room.transform.localScale = Vector3.one;
    }
}
