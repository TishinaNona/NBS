using Data;
using Data.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private List<InventoryCell> _inventoryCells = new();

        public Sprite Sprite;

       // public InventoryCell _inventoryCell;
        private void Awake()
        {
            InitInventoryCell();
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

                if (inventoryCell.CurrentData.Type == itemTypeEnum)
                {
                    inventoryCell.AddCountItem(count);
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
                if (inventoryCell.CurrentData.Type == itemTypeEnum)
                { 
                    if (inventoryCell.CurrentData.Count == count)
                    {
                        inventoryCell.CurrentData.Type = ItemTypeEnum.None;
                        inventoryCell.CurrentData.Count = 0;
                        inventoryCell.CurrentData.AvatarItem = Sprite; 
                        Save(); 
                        return;
                    }

                    if (inventoryCell.CurrentData.Count > count)
                    {
                        inventoryCell.RemoveCountItem(count);
                        Save(); 
                    }

                    if (inventoryCell.CurrentData.Count <= count)
                    {
                        Debug.Log("Не успешно");
                        return;
                    }
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
            DataCentralService.Instance.LoadStates();
        }

        public void SaveCells(int id)
        {
            var data = _inventoryCells[id].CurrentData;
            data.Count = _inventoryCells[id].CurrentData.Count;
            data.Type = _inventoryCells[id].CurrentData.Type;
            data.AvatarItem = _inventoryCells[id].CurrentData.AvatarItem;
            DataCentralService.Instance.InventoryStates.UpdateCellData(data);
        }

        public void OnLoad()
        {
            foreach (InventoryCell inventoryCell in _inventoryCells)
            {
                inventoryCell.Load();
            }
        }
    }
}
