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
        [SerializeField] private Button _load;
        [SerializeField] private Button _test;

        public InventoryCellData CurrentData;

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
            }

            if (firstEmptyCell != null)
            {
                firstEmptyCell.AddNewItem(itemTypeEnum, count, icon);
                Save();
                return;
            }
            //TODO: Если некуда впихнуть что то сделать
        }

        private void Save()
        {
            for (int i = 0; i < _inventoryCells.Count; i++)
            {
                SaveCells(i);
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
