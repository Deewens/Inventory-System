﻿using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem.UI.PapyrusTheme
{
    public class UIInventorySlotPapyrusTheme : UIInventorySlot
    {
        private Image _icon;
        private TextMeshProUGUI _quantityText;

        public  void Awake()
        {
            // Initialise the slot by getting the necessary components.
            _icon = GetComponentInChildren<Image>();
            _quantityText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public override void SetInventoryItem(InventoryItem item)
        {
            base.SetInventoryItem(item);
            
            gameObject.name = "Item Slot: " + Item.ItemData.Name + " (" + Item.Quantity + ")";
            _icon.sprite = item.ItemData.Icon;
            if (item.Quantity > 1)
            {
                _quantityText.SetText(item.Quantity.ToString());
            }
            else
            {
                _quantityText.SetText("");
            }
        }
    }
}