using System;
using InventorySystem.Interfaces;
using InventorySystem.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem.UI
{
    /// <summary>
    /// Instantiate and manage the Inventory attached to a GameObject that needs an inventory with a UI (player, chest, ...)
    /// </summary>
    public class UIInventoryController : MonoBehaviour
    {
        // TODO: Create a base InventoryController class that can be attached to GameObject that does not need any UI

        // ReSharper disable once InconsistentNaming
        [SerializeField] protected UIInventory UIInventory;
        [SerializeField] private bool isActiveOnStart = true;
        [SerializeField] private InputAction openCloseInventoryAction;

        [field: SerializeField] public InventorySO InventorySO { get; private set; }

        private void Start()
        {
            // Instantiate an empty inventory when starting the game
            if (UIInventory != null)
            {
                UIInventory.Inventory = InventorySO;
                UIInventory.gameObject.SetActive(isActiveOnStart);
                UIInventory.ItemClicked += item =>
                {
                    UIInventory.Inventory.RemoveItem(item.ItemData);
                    Vector3 itemPos = transform.position + transform.up * 1;
                    Instantiate(item.ItemData.Prefab, itemPos, Quaternion.identity);
                };
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