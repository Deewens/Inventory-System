using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "NewSlottableItem", menuName = "Inventory System/Item/Slottable Item", order = 0)]
    public class ItemSlottableSO : ItemSO
    {
        [field: SerializeField] public string Category { get; set; } 
    }
}