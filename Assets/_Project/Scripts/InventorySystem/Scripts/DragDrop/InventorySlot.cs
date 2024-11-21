using Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private InventoryCell cell;
        private int a;

        public ItemTypeEnum Type; //{ get; private set; }
        public int Count; //{ get; private set; }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject dropped = eventData.pointerDrag;
            DragItem draggableItem = dropped.GetComponent<DragItem>();
            InventoryCell f = dropped.GetComponent<InventoryCell>();

            GameObject current = transform.GetChild(0).gameObject;
            DragItem currentDraggable = current.GetComponent<DragItem>();
            InventoryCell ff = currentDraggable.GetComponent<InventoryCell>();
            a = f.CurrentData.CellIndex;
            f.CurrentData.CellIndex = ff.CurrentData.CellIndex;
            ff.CurrentData.CellIndex = a;
            currentDraggable.transform.SetParent(draggableItem.parentAfterDrag);
            draggableItem.parentAfterDrag = transform;
        }

        private void Update()
        {
            cell = GetComponentInChildren<InventoryCell>();
            if (cell != null)
            {
                Count = cell.CurrentData.Count;
                Type = cell.CurrentData.Type;
            }
           
            
        }
    }
}
