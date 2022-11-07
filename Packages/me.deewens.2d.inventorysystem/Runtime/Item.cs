using InventorySystem.Interfaces;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem
{
    public class Item : MonoBehaviour, ICollectable
    {
        [SerializeField] private ItemSO itemData;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            if (_spriteRenderer != null)
                _spriteRenderer.sprite = itemData.Icon;
        }

        public void Collect(Inventory inventory)
        {
            inventory.AddItem(itemData);
            Destroy(gameObject);
        }
    }
}