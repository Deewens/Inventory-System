using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    [SerializeField] private InventoryHolder inventoryHolder;

    [SerializeField] private List<ItemSO> itemList;
    
    public void AddRandItemToInventory()
    {
        inventoryHolder.AddItem(itemList[0]);
    }

    public void RemoveLastItemFromInventory()
    {
        inventoryHolder.Inventory.RemoveItem(itemList[^1]);
    }
    
    public void SaveInventoryToFile()
    {
        inventoryHolder.SaveInventory();
    }

    public void LoadInventoryFromFile()
    {
        inventoryHolder.LoadInventory();
    }

    public void ClearInventory()
    {
        inventoryHolder.Inventory.Clear();
    }
}
