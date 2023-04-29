using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Special type of Inventory that stores item as "slots" instead of directly storing them in a list.
    /// </summary>
    [CreateAssetMenu(fileName = "SlottedInventory", menuName = "Inventory System/Inventory/Slotted Inventory",
        order = 0)]
    public class InventorySlottedSO : ScriptableObject
    {
        [field: SerializeField] public List<InventorySlot> Slots { get; private set; } = new();
        
        /// <summary>
        /// Triggered whenever the content of the inventory is changed.
        /// </summary>
        public event Action InventoryChanged;

        /// <summary>
        /// Triggered whenever an item is added to the inventory
        /// </summary>
        public event Action<ItemSlottableSO> ItemAdded;
        
        /// <summary>
        /// Triggered whenever an item is removed from the inventory.
        /// </summary>
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
        
        /// <summary>
        /// Save the inventory content to a persistent file
        /// </summary>
        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            FileManager.WriteToFile("slottable_inventory.json", json);
            Debug.Log("Inventory has been saved!");
            Debug.Log(Application.persistentDataPath);
        }
        
        /// <summary>
        ///  Load a previously saved inventory
        /// </summary>
        public void Load()
        {
            FileManager.LoadFromFile("slottable_inventory.json", out string json);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("Inventory has been loaded!");
        }
    }
}