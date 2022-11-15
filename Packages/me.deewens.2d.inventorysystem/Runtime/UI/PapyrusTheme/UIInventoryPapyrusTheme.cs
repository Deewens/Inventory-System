using UnityEngine;

namespace InventorySystem.UI.PapyrusTheme
{
    public class UIInventoryPapyrusTheme : UIInventory
    {
        public override void RefreshInventorySlots()
        {
            RemoveAllItems();

            // Add each item to the UI
            foreach (var item in Inventory.Items)
            {
                // Create a new item slot from the template
                UIInventorySlotPapyrusTheme newItemSlot =
                    (UIInventorySlotPapyrusTheme) Instantiate(itemSlotPrefab, ItemSlotContainer);
                newItemSlot.SetInventoryItem(item);
                newItemSlot.OnItemSlotClicked += HandleItemClick;
                newItemSlot.OnItemSlotRightClicked += HandleItemRightClick;
            }
        }

        private void HandleItemClick(UIInventorySlot item)
        {
            Debug.Log("Test");
        }

        private void HandleItemRightClick(UIInventorySlot obj)
        {
            throw new System.NotImplementedException();
        }
    }
}