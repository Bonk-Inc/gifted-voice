using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private CompletementCounter counter;

    [SerializeField]
    private Apartment[] apartments;

    private int id;

    public void SetId(int id)
    {
        this.id = id;
        for (int i = 0; i < apartments.Length; i++)
        {
            apartments[i].SetId(id, i);
        }
    }

    public bool FloorCompleted() {
        return counter.IsCompleted();
    }

    public void TeleportPlayer(GameObject player) {
        var playerMesh = player.GetComponent<MeshRenderer>();

        player.transform.position = spawnLocation.position;

        if (playerMesh != null)
            player.transform.Translate(0, playerMesh.bounds.extents.y, 0);
    }


}
