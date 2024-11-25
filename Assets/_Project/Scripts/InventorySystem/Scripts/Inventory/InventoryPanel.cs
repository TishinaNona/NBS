using Data;
using Data.Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private List<InventoryCell> _inventoryCells = new();
        [SerializeField] private Button _testLoad;
        [SerializeField] private Button _testSave;
        private InventoryCellData CurrentData;

        

        private void Awake()
        {
            InitInventoryCell();
        }

        public void BTM_Save()
        {
            Save();
        }

        public void BTM_Load()
        {
            OnLoad();
        }

        public void InitInventoryCell()
        {
            for (int i = 0; i < _inventoryCells.Count; i++)
            {
                _inventoryCells[i].InitIndex(i);
            }
        }

        private void Start()
        {
            OnLoad();
            Save();
        }

        public void AddItem(ItemTypeEnum itemTypeEnum, int count, Sprite icon)
        {
            InventoryCell firstEmptyCell = null;

            foreach (var inventoryCell in _inventoryCells)
            {
                if (inventoryCell.CurrentData.Type == itemTypeEnum)
                {
                    inventoryCell.AddCountItem(count);
                    Save();
                    return;
                }

                if (firstEmptyCell == null && inventoryCell.CurrentData.Type == ItemTypeEnum.None)
                {
                    firstEmptyCell = inventoryCell;
                    Save();
                }

                if (firstEmptyCell != null)
                {
                    firstEmptyCell.AddNewItem(itemTypeEnum, count, icon);
                    Save();
                    return;
                }
            }
             
            //TODO: Если некуда впихнуть что то сделать
        }

        public void RemoveItem(ItemTypeEnum itemTypeEnum, int count)
        {
            foreach (var inventoryCell in _inventoryCells)
            {
                if (inventoryCell.CurrentData.Type == itemTypeEnum && inventoryCell.CurrentData.Count > count)
                { 
                    inventoryCell.RemoveCountItem(count);
                    Debug.Log("Успех, минус");
                    Save();
                    return;
                }
                if (inventoryCell.CurrentData.Type == itemTypeEnum && inventoryCell.CurrentData.Count <= count)
                {
                    Debug.Log("Мало");
                    return;
                }
                if (inventoryCell.CurrentData.Type == itemTypeEnum && inventoryCell.CurrentData.Count == count)
                {
                    inventoryCell.CurrentData.Type = ItemTypeEnum.None;
                    inventoryCell.CurrentData.Count = 0;
                    inventoryCell.CurrentData.AvatarItem = null;    
                }
            }
        }

        public void Save()
        {
            if (_inventoryCells != null)
            {
                for (int i = 0; i < _inventoryCells.Count; i++)
                {
                    SaveCells(i);
                }

               
            }
            DataCentralService.Instance.SaveStates();
        }

        public void SaveCells(int id)
        {
            var data = _inventoryCells[id].CurrentData;
            data.Count = _inventoryCells[id].CurrentData.Count;
            data.Type = _inventoryCells[id].CurrentData.Type;
            data.AvatarItem = _inventoryCells[id].CurrentData.AvatarItem;
            DataCentralService.Instance.InventoryStates.UpdateCellData(data);
        }

        private void OnLoad()
        {
            foreach (InventoryCell inventoryCell in _inventoryCells)
            {
                inventoryCell.Load();
            }
        }
    }
}
