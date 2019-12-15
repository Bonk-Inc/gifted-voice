using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : RigidbodyManipulator
{

    [SerializeField]
    private LocalInventory inventory;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int maxWeight;
    [SerializeField]
    private float encumberedMultiplier = 2f;
    private bool isEncumbered = false;

    public int MaxWeight { get => maxWeight; set => maxWeight = value; }


    private void Start()
    {
        inventory.OnInventoryUpdate += CheckEncumbered;
    }

    private void Update() {
        float currentSpeed = isEncumbered ? speed : speed / encumberedMultiplier;


        var velocity = Vector3.zero;

        velocity += transform.forward * currentSpeed * Input.GetAxis("Vertical");
        velocity += transform.right * currentSpeed * Input.GetAxis("Horizontal");


        if (velocity.magnitude > speed)
        {
            velocity.Normalize();
            velocity *= currentSpeed;
        }
        rb.velocity = velocity;
    }

    private void CheckEncumbered()
    {
        isEncumbered = inventory.GetWeight() < MaxWeight;
    }

    public void AddSpeed(float amount)
    {
        print("what: " + amount);
        speed += amount;
    }
}
