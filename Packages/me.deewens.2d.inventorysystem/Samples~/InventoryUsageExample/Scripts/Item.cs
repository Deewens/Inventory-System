using System.Collections;
using System.Collections.Generic;
using InventorySystem.Interfaces;
using InventorySystem.ScriptableObjects;
using UnityEngine;

public class Item : MonoBehaviour, ICollectableItem
{
    [SerializeField] private ItemSO itemSO;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
            
        if (_spriteRenderer != null)
            _spriteRenderer.sprite = itemSO.Icon;
    }
    
    /// <summary>
    /// Whenever the item is being collected by player. Destroy the GameObject from the world.
    /// </summary>
    /// <param name="inventorySO">The Inventory where to add the item</param>
    public void OnCollectingItem(InventorySO inventorySO)
    {
        inventorySO.AddItem(itemSO);
        Destroy(gameObject);
    }
}
