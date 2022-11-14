using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem
{
    public abstract class UIInventorySlot : MonoBehaviour, IPointerClickHandler, InventoryInputs.IUIInventoryActions
    {
        protected InventoryItem Item;
        protected RectTransform RectTransform;
        public InputAction test;
        public InputActionMap testMap;
        
        public virtual void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }

        public virtual void SetInventoryItem(InventoryItem item)
        {
            Item = item;
        }
        
        /// <summary>
        /// Set the X and Y position of this slot in the UI of the Inventory
        /// </summary>
        /// <param name="position">2D vector</param>
        public void SetPosition(Vector2 position)
        {
            RectTransform.anchoredPosition = position;
        }
        
        public abstract void OnPointerClick(PointerEventData eventData);
        public void OnAction(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnDropItem(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnHello(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
    }
}