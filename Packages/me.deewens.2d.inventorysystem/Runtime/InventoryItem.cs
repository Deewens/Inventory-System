using InventorySystem.ScriptableObjects;

namespace InventorySystem
{
    public class InventoryItem
    {
        /// <summary>
        /// Item data stored in the inventory
        /// </summary>
        public ItemSO ItemData { get; }

        /// <summary>
        /// Quantity of this item stored in the inventory
        /// </summary>
        public int Quantity { get; set; }

        public InventoryItem(ItemSO itemData)
        {
            ItemData = itemData;
            Quantity = 1;
        }
    }
}