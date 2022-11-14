using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem.UI
{
    public class UIInventoryController : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        [SerializeField] private UIInventory UIInventory;
        [SerializeField] private InputAction openCloseInventoryAction;
        
        private Inventory _inventory;

        private void Awake()
        {
            // Instantiate an empty inventory when starting the game
            _inventory = new Inventory();
            if (UIInventory != null)
            {
                UIInventory.Inventory = _inventory;
            }

            openCloseInventoryAction.performed += OnOpenInventory;
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
    }
}