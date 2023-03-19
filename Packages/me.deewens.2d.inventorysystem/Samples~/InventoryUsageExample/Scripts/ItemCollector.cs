using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem.Interfaces;
using InventorySystem.UI;
using UnityEngine;

/// <summary>
/// Place this script on any GameObject that can collect an item by triggering a collision
/// </summary>
public class ItemCollector : MonoBehaviour
{
    private UIInventoryController _inventoryController;
    
    private void Start()
    {
        _inventoryController = GetComponent<UIInventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // If the item is "collectable", invoke the OnCollectingItem method.
        if (col.TryGetComponent(out ICollectableItem item))
        {
            item.OnCollectingItem(_inventoryController.InventorySO);
        }
    }
}
