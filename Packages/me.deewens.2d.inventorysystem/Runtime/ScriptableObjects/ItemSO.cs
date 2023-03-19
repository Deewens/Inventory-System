using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Default Item", order = 0)]
    public class ItemSO : ScriptableObject
    {
        [field: SerializeField] 
        public string Name { get; private set; }

        [field: SerializeField, TextArea] 
        public string Description { get; private set; }
        
        [field: SerializeField, Tooltip("If this item can be stacked in a Inventory")]
        public bool IsStackable { get; private set; }
        
        [field: SerializeField, Tooltip("The icon to be displayed in the UI.")]
        public Sprite Icon { get; private set; }

        [field: SerializeField, Tooltip("The prefab linked to this item that can be instantiated in the scene")]
        public GameObject Prefab { get; private set; }
    }
}