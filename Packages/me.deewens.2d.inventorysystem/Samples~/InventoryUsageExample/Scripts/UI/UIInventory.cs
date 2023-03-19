using System;
using System.Collections.Generic;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.UI
{
    /// <summary>
    /// Attached to the UI Inventory container. Used to manage the logic of the UI
    /// </summary>
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] [Tooltip("Template Prefab to be cloned when drawing a new slot for an item in the inventory")]
        protected UIInventorySlot itemSlotPrefab;
        
        /// Event are invoked whenever user left or right click on an item in the inventory
        public event Action<InventoryItem> ItemClicked, ItemRightClicked;

        /// Container Game Object where every item slots will be instantiated
        private Transform _itemSlotContainer;
        
        /// The ScriptableObject describing the inventory
        private InventorySO _inventory;

        public InventorySO Inventory
        {
            get => _inventory;
            set
            {
                _inventory = value;
                _inventory.InventoryChanged += RefreshInventorySlots;
                RefreshInventorySlots();
            }
        }

        private void Awake()
        {
            _itemSlotContainer = transform.Find("ItemSlotContainer");
            if (_itemSlotContainer == null)
            {
                throw new InventoryUIElementNotFoundException(
                    "ItemSlotContainer GameObject is missing inside UIInventoryContainer");
            }
        }

        /// <summary>
        /// Remove and refresh all items in the inventory
        /// </summary>
        private void RefreshInventorySlots()
        {
            RemoveAllItems();

            // Add each item to the UI
            foreach (var item in Inventory.Items)
            {
                // Create a new item slot from the template
                UIInventorySlot newItemSlot =
                    (UIInventorySlot)Instantiate(itemSlotPrefab, _itemSlotContainer);
                newItemSlot.SetInventoryItem(item);

                newItemSlot.ItemClicked += ItemClicked;
                newItemSlot.ItemRightClicked += ItemRightClicked;
            }
        }

        /// <summary>
        /// Clear the UI of all its items
        /// </summary>
        private void RemoveAllItems()
        {
            // Remove all items from the UI
            foreach (Transform itemSlot in _itemSlotContainer)
            {
                Destroy(itemSlot.gameObject);
            }
        }

        /// <summary>
        /// Display the inventory
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Hide the inventory
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}