using Data;
using Data.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryCell : MonoBehaviour
    {
       // [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private Image _icon;
        private int Index;
        public InventoryCellData CurrentData;


      
        public void InitIndex(int index)
        {
            Index = index;
        }

        public void Load()
        {
            CurrentData = DataCentralService.Instance.InventoryStates.GetCellData(Index);
            ReDraw();
        }

        public void AddNewItem(ItemTypeEnum itemTypeEnum, int count, Sprite icon)
        {
            CurrentData.Type = itemTypeEnum;
            CurrentData.Count = count;
            CurrentData.AvatarItem = icon;
             
            DataCentralService.Instance.InventoryStates.UpdateCellData(CurrentData);
            ReDraw();
        }
        
        public void AddCountItem(int count)
        {
            CurrentData.Count += count;
            DataCentralService.Instance.InventoryStates.UpdateCellData(CurrentData);
            ReDraw();
        }
        public void RemoveCountItem(int count)
        {
            CurrentData.Count -= count;
            DataCentralService.Instance.InventoryStates.UpdateCellData(CurrentData);
            ReDraw();
        }

        public void ReDraw()
        {
            if (CurrentData.Type == ItemTypeEnum.None)
            {
                //_name.text = "";
                _count.text = " "; 
            }
            else
            {
               // _name.text = CurrentData.Type.ToString();
                _count.text = CurrentData.Count.ToString();
                _icon.sprite = CurrentData.AvatarItem;
            }
            
        }
    }
}