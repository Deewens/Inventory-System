using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item", order = 0)]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private new string name;
        [TextArea]
        [SerializeField] private string description;
        [SerializeField] private bool isStackable;
        
        [Tooltip("The icon to be displayed in the UI")]
        [SerializeField] private Sprite icon;
        
        [Tooltip("The prefab linked to this item which represent the actual Item game object in the game")]
        [SerializeField]
        private GameObject prefab;

        public string Name => name;
        public string Description => description;
        public bool IsStackable => isStackable;
        
        public Sprite Icon => icon;
        public GameObject Prefab => prefab;
    }
}