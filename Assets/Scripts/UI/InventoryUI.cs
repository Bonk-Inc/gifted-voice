using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private LocalInventory inventory;

    [SerializeField]
    private TMPro.TextMeshProUGUI inventoryText;


    private void Start()
    {
        inventory.OnInventoryUpdate += UpdateInventoryUI;
    }

    private void UpdateInventoryUI()
    {
        inventoryText.text = inventory.GetAllSlots().Length.ToString();
    }
}
