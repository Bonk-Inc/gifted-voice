using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentPlacementHandler : Completable
{
    
    [SerializeField]
    private PresentType requiredType;

    [SerializeField]
    private bool positionAsGround = false;

    public bool HasPresent { get; private set; } = false;


    private Present present;
    private string id;

    public void PlacePresent(Present present )
    {
        if (HasPresent)
            return;

        if (!CheckRequirements(present))
            return;

        var presentMeshRenderer = present.GetComponent<MeshRenderer>();
        
        present.gameObject.SetActive(true);
        present.gameObject.layer = 0;
        present.transform.position = transform.position;
        if (positionAsGround)
            present.transform.Translate(0, presentMeshRenderer.bounds.extents.y, 0);
        PresentKeepHandler.Instance.AddPresent(this.id, present);
        gameObject.SetActive(false);
        this.present = present;
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

    public void SetId(int floorId, int apartmentId, int id)
    {
        this.id = $"{floorId}_{apartmentId}_{id}";
        var present = PresentKeepHandler.Instance.GetPresent(this.id);
        if (present != null)
            PlacePresent(present);
    
    }
}
