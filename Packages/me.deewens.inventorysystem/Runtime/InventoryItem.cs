﻿using System;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Manage an Item stored in an inventory
    /// </summary>
    [Serializable]
    public class InventoryItem
    {
        /// <summary>
        /// Item data stored in the inventory
        /// </summary>
        [field: SerializeField] public ItemSO ItemData { get; set; }

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