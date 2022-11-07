using InventorySystem.Interfaces;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Add this script to any entity in the game that needs an inventory, like the Player
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            // Instantiate an empty inventory when starting the game
            _inventory = new Inventory();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log(gameObject.name);
            // Every GameObject with component implementing ICollectable interface call the Collect method on trigger
            ICollectable collectable = col.GetComponent<ICollectable>();
            collectable?.Collect(_inventory);
        }
    }
}