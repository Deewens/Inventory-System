using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class SlottableInventoryHolder : MonoBehaviour
{
    [field: SerializeField] public InventorySlottedSO Inventory { get; set; }

    private void Awake()
    {
        Inventory.InventoryChanged += OnInventoryChanged;
        Inventory.ItemAdded += OnItemAdded;
        Inventory.ItemRemoved += OnItemRemoved;
    }

    private void OnItemRemoved(ItemSlottableSO removedItem)
    {
        Debug.Log($"Item has been removed {removedItem.Name}");
    }

    private void OnInventoryChanged()
    {
        Debug.Log("Inventory has been changed. New content:");
        DisplayInventoryContent();
    }

    private void OnItemAdded(ItemSlottableSO addedItem)
    {
        Debug.Log($"Item has been added {addedItem.Name}");
    }

    public void AddItem(ItemSlottableSO item)
    {
        Inventory.AddItem(item);
    }

    public void SaveInventory()
    {
        Inventory.Save();
    }

    public void LoadInventory()
    {
        Inventory.Load();
    }

    public void DisplayInventoryContent()
    {
        foreach (var slot in Inventory.Slots)
        {
            if (slot.Item.ItemData != null)
            {
                Debug.Log($"| {slot.SlotCategory} | {slot.Item.ItemData.Name} | {slot.Item.Quantity} |");
            }
            else
            {
                Debug.Log($"| {slot.SlotCategory} | Slot empty | 0 |");
            }
        }
        Debug.Log("------------------");
    }

    public void ClearInventory()
    {
        Inventory.Clear();
    }
}
