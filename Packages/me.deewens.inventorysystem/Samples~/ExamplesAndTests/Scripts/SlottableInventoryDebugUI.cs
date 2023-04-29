using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class SlottableInventoryDebugUI : MonoBehaviour
{
    [SerializeField] private SlottableInventoryHolder slottableInventoryHolder;

    [SerializeField] private ItemSlottableSO handgunItem;
    [SerializeField] private ItemSlottableSO potionItem;
    
    public void AddHandgunToSlottableInventory()
    {
        slottableInventoryHolder.AddItem(handgunItem);
    }
    public void AddPotionToSlottableInventory()
    {
        slottableInventoryHolder.AddItem(potionItem);
    }   
    
    public void RemoveHandgunToSlottableInventory()
    {
        slottableInventoryHolder.Inventory.RemoveItem(handgunItem);
    }
    public void RemovePotionToSlottableInventory()
    {
        slottableInventoryHolder.Inventory.RemoveItem(potionItem);
    }
}
