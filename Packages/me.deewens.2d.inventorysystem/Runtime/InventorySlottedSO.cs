using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "SlottedInventory", menuName = "Inventory System/Inventory/Slotted Inventory", order = 0)]
    public class InventorySlottedSO : ScriptableObject
    {
        [field: SerializeField] public List<InventorySlot> Slots { get; private set; } = new();
        public event Action InventoryChanged;

        public event Action<ItemSO> ItemAdded;
        public event Action<ItemSO> ItemRemoved;

        private void Awake()
        {
            InventorySlot newSlot = new InventorySlot
            {
                SlotCategory = "Handgun"
            };
            InventorySlot anotherSlot = new InventorySlot();
            
            Slots.Add(newSlot);
            Slots.Add(anotherSlot);
        }

        public void AddItem(ItemSO itemData)
        {
            // if (itemData.IsStackable)
            // {
            //     InventoryItem item = Slots.Find(slot => slot.Item.ItemData == itemData);
            //     if (item == null)
            //     {
            //         Items.Add(new InventoryItem(itemData));
            //     }
            //     else
            //     {
            //         item.Quantity++;
            //     }
            // }
            // else
            // {
            //     Items.Add(new InventoryItem(itemData));
            // }
            //
            // // Invoke event whenever an item is added
            // ItemAdded?.Invoke(itemData);
            //
            // InventoryChanged?.Invoke();
        }

        public void RemoveItem(ItemSO itemData)
        {
            // InventoryItem item = Items.Find(item => item.ItemData == itemData);
            //
            // if (item != null)
            // {
            //     if (itemData.IsStackable)
            //     {
            //         item.Quantity--;
            //         if (item.Quantity == 0)
            //         {
            //             Items.Remove(item);
            //         }
            //     }
            //     else
            //     {
            //         Items.Remove(item);
            //     }
            //
            //
            //     ItemRemoved?.Invoke(itemData);
            //     InventoryChanged?.Invoke();
            // }
        }

        /// <summary>
        /// Empty the inventory from every items
        /// </summary>
        public void Clear()
        {
            Slots.Clear();

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
            Debug.Log("Inventory has been loaded!");
        }
    }
}