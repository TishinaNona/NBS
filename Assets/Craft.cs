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
        [SerializeField] private Sprite _refactoring;



        private void Update()
        {
            CraftPotion();
        }

        private void CraftPotion()
        {
            foreach (var receipt in _craftSO.ReceiptsPotions) //�����������
            {
                receipt.isCraft = true;

                foreach (var itemReceipt in receipt.itemsForReceiptstStructs)
                {
                    var dataCell = _itemData.FirstOrDefault(slot => slot.Type == itemReceipt.ItemType && slot.Count >= itemReceipt.Count);

                    if (dataCell == null)
                    {
                        receipt.isCraft = false;
                        break;
                    }
                }

                if (receipt.isCraft)
                {
                    SetProperties(receipt.ItemPotionType, receipt.Count.ToString(), receipt.AvatarItem);
                }
                else
                {
                    SetProperties(ItemTypeEnum.None, " ", _refactoring);
                }
            }
        }

        private void SetProperties(ItemTypeEnum itemTypeEnum, string text, Sprite sprite)
        {
            _craftItem.ItemType = itemTypeEnum;
            _craftItem.CountText.text = text;
            _craftItem.AvatarItem.sprite = sprite;
        }

        //foreach (var potion in _craftSO.ReceiptsPotions) //рефакторинг
        //{
        //    if (potion.itemsForReceiptstStructs[0].Count > 0 && potion.itemsForReceiptstStructs[1].Count > 0)
        //    {
        //        potion.isCraft = true;
        //    }

        //    if (potion.isCraft == true)
        //    {
        //        if (_itemData[0].type == ItemTypeEnum.BluePotion_0 && _itemData[1].type == ItemTypeEnum.RedPotion_0)
        //        {
        //            _craftItem.ItemType = potion.ItemPotionType;
        //            _craftItem.CountText.text = potion.Count.ToString();
        //            _craftItem.AvatarItem.sprite = potion.AvatarItem;

        //        }
        //        if (_itemData[0].type == ItemTypeEnum.None || _itemData[1].type == ItemTypeEnum.None)
        //        {
        //            Debug.Log("2345");
        //            _craftItem.ItemType = ItemTypeEnum.None;
        //            _craftItem.CountText.text = " ";
        //            _craftItem.AvatarItem.sprite = _refactoring;
        //        }

        //    }
        //}
    }
}

