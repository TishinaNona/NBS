using Data;
using Data.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private InventoryPanel _inventoryPanel;
        [SerializeField] private InventoryCell _cell;
        public InventoryCellData CurrentData;

        private int _cellIndex;

        public ItemTypeEnum Type { get; private set; }
        public int Count { get; private set; }
        public Sprite Sprite { get; private set; }
        
        
        public void OnDrop(PointerEventData eventData)
        {
            var dropped = eventData.pointerDrag;
            var draggableItem = dropped.GetComponent<DragItem>();
            var FirstitemDroppedCellIndex = dropped.GetComponent<InventoryCell>();
             
            var current = transform.GetChild(0).gameObject;
            var currentDraggable = current.GetComponent<DragItem>();
            var SeconditemDroppedCellIndex = currentDraggable.GetComponent<InventoryCell>();
             
            _cellIndex = FirstitemDroppedCellIndex.CurrentData.CellIndex;
            FirstitemDroppedCellIndex.CurrentData.CellIndex = SeconditemDroppedCellIndex.CurrentData.CellIndex;
            SeconditemDroppedCellIndex.CurrentData.CellIndex = _cellIndex;

            currentDraggable.transform.SetParent(draggableItem.parentAfterDrag);
            draggableItem.parentAfterDrag = transform;


             _inventoryPanel.Save();
            
        }

        private void Update()
        {
            _cell = GetComponentInChildren<InventoryCell>();
            if (_cell != null )
            {
                Count = _cell.CurrentData.Count;
                Type = _cell.CurrentData.Type;
                Sprite = _cell.CurrentData.AvatarItem;
            }  
        }
    } 
}
