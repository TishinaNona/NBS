using Inventory;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySoList", menuName = "InventorySoList")]
public class InventorySoList : ScriptableObject
{
    public List<ItemConfig> inventoryItems;

}
