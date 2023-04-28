using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventorySO : ScriptableObject
    {
        [field: SerializeField] public List<InventoryItem> Items { get; private set; } = new();
        public event Action InventoryChanged;
        
        public event Action<ItemSO> ItemAdded;
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
        
        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            FileManager.WriteToFile("inventory.json", json);
            Debug.Log("Inventory has been saved!");
            Debug.Log(Application.persistentDataPath);
        }

        public void Load()
        {
            FileManager.LoadFromFile("inventory.json", out string json);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}