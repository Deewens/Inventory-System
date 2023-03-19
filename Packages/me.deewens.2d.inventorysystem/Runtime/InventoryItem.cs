using System;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Item stored and stacked in the inventory
    /// </summary>
    [Serializable]
    public class InventoryItem
    {
        /// <summary>
        /// Item data stored in the inventory
        /// </summary>
        [field: SerializeField] public ItemSO ItemData { get; private set; }

        /// <summary>
        /// Quantity of this item stored in the inventory
        /// </summary>
        [field: SerializeField] public int Quantity { get; set; }

        public InventoryItem(ItemSO itemData)
        {
            ItemData = itemData;
            Quantity = 1;
        }
    }
}