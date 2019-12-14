using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private CompletementCounter counter;

    public bool FloorCompleted()
    {
        return counter.IsCompleted();
    }

    public void TeleportPlayer(GameObject player)
    {
        var playerMesh = player.GetComponent<MeshRenderer>();

        player.transform.position = spawnLocation.position;
        player.transform.Translate(0, playerMesh.bounds.extents.y, 0);
    }


}
