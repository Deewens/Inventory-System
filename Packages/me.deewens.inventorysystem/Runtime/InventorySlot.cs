using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Manage the slots for the Slotted Inventory and the items stored in it.
    /// </summary>
    [Serializable]
    public class InventorySlot
    {
        [field: SerializeField] public string SlotCategory { get; set; } = "Default";
        [SerializeField] private InventoryItem item;

        public InventoryItem Item => item;

        /// <summary>
        /// Add an item to the slot. If an item already exists, it will either update its quantity if it is stackable or throw an exception.
        ///
        /// If the slot category of the item does not match the category of the slot inventory, it will also throw an exception.
        /// </summary>
        /// <param name="slottableItemData">The item to add</param>
        /// <exception cref="Exception"></exception>
        public void SetItem(ItemSlottableSO slottableItemData)
        {
            if (slottableItemData.Category == SlotCategory)
            {
                if (item.ItemData == null)
                {
                    item = new InventoryItem(slottableItemData);
                }
                else
                {
                    if (slottableItemData.IsStackable)
                    {
                        item.Quantity++;
                    }
                    else
                    {
                        throw new Exception("This slot is already full.");
                    }
                }
            }
            else
            {
                throw new Exception(
                    $"Trying to add an item to a slot with a different category. " +
                    $"{slottableItemData.Category} != {SlotCategory}");
            }
        }

        /// <summary>
        /// Remove an item from the slot. If the item is stackable, it will decrement the Quantity, otherwise,
        /// the item will be set to null, thus, the slot will be empty.
        /// </summary>
        /// <param name="slottableItemData">Item data to remove from inventory</param>
        /// <exception cref="Exception"></exception>
        public void RemoveItem(ItemSlottableSO slottableItemData)
        {
            if (slottableItemData.Category == SlotCategory)
            {
                if (slottableItemData.IsStackable)
                {
                    item.Quantity--;
                    if (item.Quantity == 0)
                    {
                        item.ItemData = null;
                    }
                }
                else
                {
                    item.ItemData = null;
                }
            }
            else
            {
                throw new Exception(
                    $"Trying to remove an item with from a slot with a different category. " +
                    $"{slottableItemData.Category} != {SlotCategory}");
            }
        }

        /// <summary>
        /// Clear the slot from every items
        /// </summary>
        public void ClearSlot()
        {
            item.ItemData = null;
        }
    }
}