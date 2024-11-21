using Data.Inventory;
using Inventory;
using Unity.VisualScripting;
using UnityEngine;

public class AddItemInInventorySo : MonoBehaviour
{
    [SerializeField] private ItemConfig _itemConfig;
    [SerializeField] private InventorySoList _inventorySoList;

    [SerializeField] private Sprite a;
    [SerializeField] private Sprite b;

    private void Start()
    {
        R();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           // _inventorySoList.inventoryItems.Add(_itemConfig);
            
            Destroy(gameObject);
        }
        
    }

    private void R()
    {
        var R = Random.Range(0, 1);

        if (R == 0)
        {
            _itemConfig.Name = "a";
            _itemConfig.AvatarItem = a;
            _itemConfig.Count = 1;
            _itemConfig.Type = ItemTypeEnum.Bow;
        }

        if (R == 1)
        {
            _itemConfig.Name = "b";
            _itemConfig.AvatarItem = b;
            _itemConfig.Count = 1;
            _itemConfig.Type = ItemTypeEnum.Apple;
        }
    }

}
