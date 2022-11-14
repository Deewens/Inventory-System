using UnityEngine;

namespace InventorySystem.UI.PapyrusTheme
{
    public class UIInventoryPapyrusTheme : UIInventory
    {
        protected override void RefreshInventorySlots()
        {
            RemoveAllItems();

            // Add each item to the UI
            foreach (var item in Inventory.Items)
            {
                // Create a new item slot from the template
                UIInventorySlotPapyrusTheme newItemSlot =
                    (UIInventorySlotPapyrusTheme) Instantiate(itemSlotPrefab, Vector3.zero, Quaternion.identity);
                UIItemSlotList.Add(newItemSlot);
            }
        }
    }
}