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
                    Debug.Log(dataCell);
                    if (dataCell == null)
                    {
                        receipt.isCraft = false;

                        break;
                    } 
                    
                    if (receipt.isCraft == true && dataCell != null)
                    {
                        SetProperties(receipt.ItemPotionType, receipt.Count.ToString(), receipt.AvatarItem);

                        if (_craftItem.isBTM_Active == true)
                        {
                            _inventoryPanel.RemoveItem(dataCell.Type, dataCell.Count);
                            _inventoryPanel.RemoveItem(dataCell.Type, dataCell.Count); 
                            _craftItem.isBTM_Active = false;
                        }
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

