using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem.UI
{
    public abstract class UIInventorySlot : MonoBehaviour, IPointerClickHandler
    {
        protected InventoryItem Item;
        public event Action<UIInventorySlot> OnItemSlotClicked, OnItemSlotRightClicked;

        public virtual void SetInventoryItem(InventoryItem item)
        {
            Item = item;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnItemSlotClicked?.Invoke(this);
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnItemSlotRightClicked?.Invoke(this);
            }
        }
    }
}