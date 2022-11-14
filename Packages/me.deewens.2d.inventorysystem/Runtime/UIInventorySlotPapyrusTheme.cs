using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem
{
    public class UIInventorySlotPapyrusTheme : UIInventorySlot
    {
        private Image _icon;
        private TextMeshProUGUI _amountText;

        public override void Awake()
        {
            base.Awake();
            
            // Initialise the slot by getting the necessary components.
            _icon = GetComponentInChildren<Image>();
            _amountText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public override void SetInventoryItem(InventoryItem item)
        {
            base.SetInventoryItem(item);
            
            gameObject.name = "Item Slot: " + Item.ItemData.Name + " (" + Item.Quantity + ")";
            _icon.sprite = item.ItemData.Icon;
            if (item.Quantity > 1)
            {
                _amountText.SetText(item.Quantity.ToString());
            }
            else
            {
                _amountText.SetText("");
            }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                
            }
            throw new System.NotImplementedException();
        }
    }
}