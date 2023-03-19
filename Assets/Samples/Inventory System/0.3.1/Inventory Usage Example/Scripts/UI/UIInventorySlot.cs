using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class UIInventorySlot : MonoBehaviour, IPointerClickHandler
    {
        private InventoryItem _item;
        
        public event Action<InventoryItem> ItemClicked, ItemRightClicked;
        
        private Image _icon;
        private TextMeshProUGUI _quantityText;

        public void Awake()
        {
            // Initialise the slot by getting the necessary components.
            _icon = GetComponentInChildren<Image>();
            _quantityText = GetComponentInChildren<TextMeshProUGUI>();
        }

        /// <summary>
        /// Set an item to be displayed by the inventory UI.
        /// </summary>
        /// <param name="item">The Item to be displayed</param>
        public void SetInventoryItem(InventoryItem item)
        {           
            _item = item;
            
            gameObject.name = "Item Slot: " + _item.ItemData.Name + " (" + _item.Quantity + ")";
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
        
        /// <summary>
        /// Whenever a user left click on the item, an event is invoked
        /// </summary>
        private void OnItemClicked()
        {
            ItemClicked?.Invoke(_item);
        }

        /// <summary>
        /// Whenever a user right click on the item, an event is invoked
        /// </summary>
        private void OnItemRightClicked()
        {
            ItemRightClicked?.Invoke(_item);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    OnItemClicked();
                    break;
                case PointerEventData.InputButton.Right:
                    OnItemRightClicked();
                    break;
            }
        }
    }
}