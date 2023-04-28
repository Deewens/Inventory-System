using InventorySystem;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private bool createInventoryAtRuntime = false;
    [field: SerializeField] public InventorySO Inventory { get; set; }

    private void Awake()
    {
        if (createInventoryAtRuntime)
        {
            Debug.Log("An Inventory has been created at runtime.");
            Inventory = ScriptableObject.CreateInstance<InventorySO>();
        }
            
        Inventory.InventoryChanged += OnInventoryChanged;
        Inventory.ItemAdded += OnItemAdded;
        Inventory.ItemRemoved += OnItemRemoved;
    }

    private void OnItemRemoved(ItemSO removedItem)
    {
        Debug.Log($"Item has been added {removedItem.Name}");
    }

    private void OnInventoryChanged()
    {
        Debug.Log("Inventory has been changed. New content:");
        foreach (var item in Inventory.Items)
        {
            Debug.Log($"| {item.ItemData.Name} | {item.Quantity} |");
        }
        Debug.Log("------------------");
    }

    private void OnItemAdded(ItemSO addedItem)
    {
        Debug.Log($"Item has been added {addedItem.Name}");
    }

    public void AddItem(ItemSO item)
    {
        Inventory.AddItem(item);
    }

    public void SaveInventory()
    {
        Inventory.Save();
    }

    public void LoadInventory()
    {
    }
}
