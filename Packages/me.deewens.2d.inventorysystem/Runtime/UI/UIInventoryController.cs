using System;
using InventorySystem.Interfaces;
using InventorySystem.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem.UI
{
    public class UIInventoryController : MonoBehaviour
    {
        [SerializeField] private InventorySO inventory;
        // ReSharper disable once InconsistentNaming
        [SerializeField] private UIInventory UIInventory;
        [SerializeField] private bool isActiveOnStart = true;
        [SerializeField] private InputAction openCloseInventoryAction;
        
        private InventorySO _inventorySO;

        private void Start()
        {
            // Instantiate an empty inventory when starting the game
            if (UIInventory != null)
            {
                UIInventory.Inventory = inventory;
                UIInventory.gameObject.SetActive(isActiveOnStart);
            }

            openCloseInventoryAction.performed += OnOpenInventory;
            UIInventory.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleItemActionRequest(UIInventorySlot obj)
        {
            throw new NotImplementedException();
        }

        private void OnEnable()
        {
            openCloseInventoryAction.Enable();
        }

        private void OnDisable()
        {
            openCloseInventoryAction.Disable();
        }

        private void OnOpenInventory(InputAction.CallbackContext ctx)
        {
            if (UIInventory.gameObject.activeSelf)
            {
                UIInventory.Hide();
            }
            else
            {
                UIInventory.Show();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            ICollectable item = col.GetComponent<ICollectable>();
            item?.Collect(inventory);
        }
    }
}