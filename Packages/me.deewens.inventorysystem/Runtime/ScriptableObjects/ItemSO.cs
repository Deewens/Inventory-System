using UnityEngine;

namespace InventorySystem
{
    
    /// <summary>
    /// Standard type of Item that can be used with Standard Inventory
    /// </summary>
    [CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Item/Item", order = 0)]
    public class ItemSO : ScriptableObject
    {
        public int ID => GetInstanceID();
        [field: SerializeField] public string Name { get; set; }

        [field: SerializeField, TextArea] public string Description { get; set; }
        [field: SerializeField] public bool IsStackable { get; set; }

        [field: SerializeField, Tooltip("The icon to be displayed in the UI")]
        public Sprite Icon { get; set; }

        [Tooltip("The prefab linked to this item which represent the actual Item game object in the game")]
        [SerializeField]
        private GameObject prefab;

        public GameObject Prefab => prefab;
    }
}