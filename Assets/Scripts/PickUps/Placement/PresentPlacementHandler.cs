using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentPlacementHandler : Completable
{

    [SerializeField]
    private PresentType requiredType;

    public bool HasPresent { get; private set; } = false;

    public void PlacePresent(Present present )
    {
        if (!CheckRequirements(present))
            return;

        var presentMeshRenderer = present.GetComponent<MeshRenderer>();
        
        present.gameObject.SetActive(true);
        present.gameObject.layer = 0;
        present.transform.position = transform.position;
        present.transform.Translate(0, presentMeshRenderer.bounds.extents.y, 0);

        HasPresent = true;
    }

    public bool CheckRequirements(Present present)
    {

        return present != null && present.Type == requiredType;
    }

    public override bool IsCompleted()
    {
        return HasPresent;
    }
}
