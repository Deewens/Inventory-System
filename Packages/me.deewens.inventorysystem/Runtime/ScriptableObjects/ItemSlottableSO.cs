using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Special type of item that can be used with the Slotted Inventory
    /// </summary>
    [CreateAssetMenu(fileName = "NewSlottableItem", menuName = "Inventory System/Item/Slottable Item", order = 0)]
    public class ItemSlottableSO : ItemSO
    {
        [field: SerializeField] public string Category { get; set; } 
    }
}