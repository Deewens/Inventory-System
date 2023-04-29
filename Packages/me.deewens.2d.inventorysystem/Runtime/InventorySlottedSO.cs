using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "SlottedInventory", menuName = "Inventory System/Inventory/Slotted Inventory",
        order = 0)]
    public class InventorySlottedSO : ScriptableObject
    {
        [field: SerializeField] public List<InventorySlot> Slots { get; private set; } = new();
        public event Action InventoryChanged;

        public event Action<ItemSlottableSO> ItemAdded;
        public event Action<ItemSlottableSO> ItemRemoved;

        public void AddItem(ItemSlottableSO itemData)
        {
            // Find slot category in inventory
            InventorySlot slot = Slots.Find(slot => slot.SlotCategory == itemData.Category);

            // If category exists
            if (slot != null)
            {
                try
                {
                    slot.SetItem(itemData);
                    
                    // Invoke event whenever an item is added
                    ItemAdded?.Invoke(itemData);
                    InventoryChanged?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
            else
            {
                throw new Exception("You cannot add an item with a category that does not exist in the inventory.");
            }
        }

        public void RemoveItem(ItemSlottableSO itemData)
        {   
            // Find slot category in inventory
            InventorySlot slot = Slots.Find(slot => slot.SlotCategory == itemData.Category);
            // If category exists
            if (slot != null)
            {
                try
                {
                    slot.RemoveItem(itemData);
                    
                    // Invoke event whenever an item is added
                    ItemRemoved?.Invoke(itemData);
                    InventoryChanged?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
            else
            {
                throw new Exception("You cannot remove an item with a category that does not exist in the inventory.");
            }
        }

        /// <summary>
        /// Empty the inventory from every items
        /// </summary>
        public void Clear()
        {
            foreach (var slot in Slots)
            {
                slot.ClearSlot();
            }

            InventoryChanged?.Invoke();
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            FileManager.WriteToFile("slottable_inventory.json", json);
            Debug.Log("Inventory has been saved!");
            Debug.Log(Application.persistentDataPath);
        }

        public void Load()
        {
            FileManager.LoadFromFile("slottable_inventory.json", out string json);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("Inventory has been loaded!");
        }
    }
}