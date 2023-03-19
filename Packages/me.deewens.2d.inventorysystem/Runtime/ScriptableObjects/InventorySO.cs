using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    /// <summary>
    /// Inventory holder, store a list of InventoryItem. Item added are stored in a InventoryItem object
    /// </summary>
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventorySO : ScriptableObject
    {
        [field: SerializeField] public List<InventoryItem> Items { get; private set; } = new();
        public event Action InventoryChanged;

        /// <summary>
        /// Add an item to the inventory.
        /// </summary>
        /// <param name="itemData">Item ScriptableObject</param>
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

            InventoryChanged?.Invoke();
        }

        /// <summary>
        /// Remove the specified Item ScriptableObject from the Inventory
        /// </summary>
        /// <param name="itemData">Item ScriptableObject</param>
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
            }

            InventoryChanged?.Invoke();
        }
    }
}