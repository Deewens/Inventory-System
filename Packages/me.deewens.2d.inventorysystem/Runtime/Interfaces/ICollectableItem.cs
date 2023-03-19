using InventorySystem.ScriptableObjects;

namespace InventorySystem.Interfaces
{
    /// <summary>
    /// Items can implement this interface to have a common API for Item collection
    /// </summary>
    public interface ICollectableItem
    {
        /// <summary>
        /// Do something when Item is being collected by something in the game (player, ...)
        /// </summary>
        /// <param name="inventorySO">The inventory to add Item to</param>
        void OnCollectingItem(InventorySO inventorySO);
    }
}