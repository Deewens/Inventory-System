using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Standard inventory
    /// </summary>
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory/Standard Inventory")]
    public class InventorySO : ScriptableObject
    {
        [field: SerializeField] public List<InventoryItem> Items { get; private set; } = new();

        /// <summary>
        /// Triggered whenever the content of the inventory is changed.
        /// </summary>
        public event Action InventoryChanged;
        
        /// <summary>
        /// Triggered whenever an item is added to the inventory
        /// </summary>
        public event Action<ItemSO> ItemAdded;
        
        /// <summary>
        /// Triggered whenever an item is removed from the inventory.
        /// </summary>
        public event Action<ItemSO> ItemRemoved;

        public void AddItem(ItemSO itemData)
        {
            if (itemData.IsStackable)
            {
                InventoryItem item = Items.Find(item => item.ItemData == itemData);
                if (item == null)
                {
                    Items.Add(new InventoryItem(itemData));
                }
                else
                {
                    item.Quantity++;
                }
            }
            else
            {
                Items.Add(new InventoryItem(itemData));
            }

            // Invoke event whenever an item is added
            ItemAdded?.Invoke(itemData);
            
            InventoryChanged?.Invoke();
            
        }

        public void RemoveItem(ItemSO itemData)
        {
            InventoryItem item = Items.Find(item => item.ItemData == itemData);

            if (item != null)
            {
                if (itemData.IsStackable)
                {
                    item.Quantity--;
                    if (item.Quantity == 0)
                    {
                        Items.Remove(item);
                    }
                }
                else
                {
                    Items.Remove(item);
                }
                
                
                ItemRemoved?.Invoke(itemData);
                InventoryChanged?.Invoke();
            }
        }

        /// <summary>
        /// Empty the inventory from every items
        /// </summary>
        public void Clear()
        {
            Items.Clear();
            
            InventoryChanged?.Invoke();
        }
        
        /// <summary>
        /// Save the inventory content to a persistent file
        /// </summary>
        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            FileManager.WriteToFile("inventory.json", json);
            Debug.Log("Inventory has been saved!");
            Debug.Log(Application.persistentDataPath);
        }

        /// <summary>
        ///  Load a previously saved inventory
        /// </summary>
        public void Load()
        {
            FileManager.LoadFromFile("inventory.json", out string json);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}