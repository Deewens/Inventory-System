using System;
using System.Collections.Generic;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.UI
{
    public abstract class UIInventory : MonoBehaviour
    {
        [SerializeField] [Tooltip("Template Prefab to be cloned when drawing a new slot for an item in the inventory")]
        protected UIInventorySlot itemSlotPrefab;

        /// <summary>
        /// Container Game Object where every item slots will be instantiated
        /// </summary>
        protected Transform ItemSlotContainer;
        
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

        public event Action<UIInventorySlot> OnItemActionRequested;


        private void Awake()
        {
            ItemSlotContainer = transform.Find("ItemSlotContainer");
            if (ItemSlotContainer == null)
            {
                throw new InventoryUIElementNotFoundException(
                    "ItemSlotContainer GameObject is missing inside UIInventoryContainer");
            }

            // Refresh inventory on Awake, to prevent a "small" freeze by doing it when getting an object for the first time
            // Idk why this do that, but this seems to fix the issue
            // Well, after further investigation, it does not fix the issue, I let it like that for now, I'll try later to investigate this
            //RefreshInventorySlots();
        }

        public abstract void RefreshInventorySlots();

        /// <summary>
        /// Clear the UI of all its items
        /// </summary>
        protected void RemoveAllItems()
        {
            // Remove all items from the UI
            foreach (Transform itemSlot in ItemSlotContainer)
            {
                Destroy(itemSlot.gameObject);
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}