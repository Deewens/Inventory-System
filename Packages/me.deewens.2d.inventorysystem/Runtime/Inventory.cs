using System.Collections.Generic;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory
    {
        private readonly List<InventoryItem> _items = new();

        public void AddItem(ItemSO itemData)
        {
            Debug.Log("Adding item to inventory: " + itemData);
            
            if (itemData.IsStackable)
            {
                InventoryItem item = _items.Find(item => item.ItemData == itemData);
                if (item == null)
                {
                    _items.Add(new InventoryItem(itemData));
                }
                else
                {
                    item.Quantity++;
                }
            }
            else
            {
                _items.Add(new InventoryItem(itemData));
            }
        }

        public void RemoveItem(ItemSO itemData)
        {
            InventoryItem item = _items.Find(item => item.ItemData == itemData);

            if (item != null)
            {
                if (itemData.IsStackable)
                {
                    item.Quantity--;
                    if (item.Quantity == 0)
                    {
                        _items.Remove(item);
                    }
                }
                else
                {
                    _items.Remove(item);
                }
            }
        }
    }
}
