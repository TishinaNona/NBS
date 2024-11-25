using Data;
using Data.Inventory;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
    public class Craft : MonoBehaviour
    {
        [SerializeField] private CraftSO _craftSO;
        [SerializeField] private InventoryPanel _inventoryPanel;
        [SerializeField] private List<InventorySlot> _itemData;
        [SerializeField] private ItemCraftDrop _craftItem;
         

        private void Update()
        {
            CraftPotion();
        }

        private void CraftPotion()
        {
            
            foreach (var receipt in _craftSO.ReceiptsPotions) 
            {
                receipt.isCraft = false;

                foreach (var itemReceipt in receipt.itemsForReceiptstStructs)
                {
                    var dataCell = _itemData.FirstOrDefault(slot => slot.Type == itemReceipt.ItemType && slot.Count >= itemReceipt.Count);
                    if (dataCell == null)
                    {
                        receipt.isCraft = false;

                        break;
                    } 
                    
                    if (receipt.isCraft == true && dataCell != null)
                    {
                        SetProperties(receipt.ItemPotionType, receipt.Count.ToString(), receipt.AvatarItem);
                        _inventoryPanel.RemoveItem(itemReceipt.ItemType, itemReceipt.Count);
                        Debug.Log(itemReceipt.ItemType);
                        Debug.Log(itemReceipt.Count); 
                    }

                    receipt.isCraft = true;
                }
            }
        }

        public void SetProperties(ItemTypeEnum itemTypeEnum, string text, Sprite sprite)
        {
            _craftItem.ItemType = itemTypeEnum;
            _craftItem.CountText.text = text;
            _craftItem.AvatarItem.sprite = sprite;
        }
    }
}

