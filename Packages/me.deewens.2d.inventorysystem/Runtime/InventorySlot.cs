using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class InventorySlot
    {
        [field: SerializeField] public string SlotCategory { get; set; } = "Default";

        [field: SerializeField] public InventoryItem Item { get; set; }
    }
}