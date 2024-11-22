using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCraftDrop : MonoBehaviour
{
    [SerializeField] private InventoryPanel _inventoryPanel;
    [SerializeField] private Craft _craft;
    [SerializeField] private Sprite _itemAvatar;
    public ItemTypeEnum ItemType;
    public TMP_Text CountText;
    public Image AvatarItem;

    public void BTM_TakeItem()
    {
        if (ItemType != ItemTypeEnum.None)
        {
            int Count = int.Parse(CountText.text);
            _inventoryPanel.AddItem(ItemType, Count, AvatarItem.sprite);
            _craft.SetProperties(ItemTypeEnum.None, " ", _itemAvatar);
            
        }
    }

}