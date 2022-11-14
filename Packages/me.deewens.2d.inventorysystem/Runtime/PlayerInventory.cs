using InventorySystem.Interfaces;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Add this script to any entity in the game that needs an inventory, like the Player
    /// </summary>
    public class PlayerInventory : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        [SerializeField] private UIInventory UIInventory;
        private Inventory _inventory;

        private void Awake()
        {
            // Instantiate an empty inventory when starting the game
            _inventory = new Inventory();
            if (UIInventory != null)
            {
                UIInventory.Inventory = _inventory;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // Every GameObject with component implementing ICollectable interface call the Collect method on trigger
            ICollectable collectable = col.GetComponent<ICollectable>();
            collectable?.Collect(_inventory);
        }
    }
}