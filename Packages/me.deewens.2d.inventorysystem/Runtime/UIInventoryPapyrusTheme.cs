using UnityEngine;

namespace InventorySystem
{
    public class UIInventoryPapyrusTheme : UIInventory
    {
        [SerializeField] private int maxColumns = 3;

        // TODO: pagination system to implement
        // ReSharper disable once NotAccessedField.Local
        [SerializeField] private int maxRows = 4;
        [SerializeField] [Min(1)] private float itemSlotSize = 166.66f;

        protected override void RefreshInventorySlots()
        {
            RemoveAllItems();

            // Add each item to the UI
            var x = 0;
            var y = 0;

            foreach (var item in Inventory.Items)
            {
                // Create a new item slot from the template
                var newItemSlot = Instantiate(itemSlotTemplatePrefab, ItemSlotContainer);
                UIInventorySlot slotUI = newItemSlot.GetComponent<UIInventorySlot>();
                slotUI.SetPosition(new Vector2(x * itemSlotSize, y * itemSlotSize));
                slotUI.SetInventoryItem(item);

                x++;
                if (x >= maxColumns)
                {
                    x = 0;
                    y--; // Going downward because default Unity canvas origin is down-left, but slot start drawing from top-left
                }
            }
        }
    }
}