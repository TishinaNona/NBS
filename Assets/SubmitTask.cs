using Inventory;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SubmitTask : MonoBehaviour
{
    [SerializeField] private TakeTask _takeTask; 
    [SerializeField] private List<InventorySlot> _itemSlotData;
    [SerializeField] private List<UITaskData> _uiTasks;
    [SerializeField] private ListTaskSo _listTaskSo;

    private void Update()
    {
        CheckInventory();
    }
    public bool isÑanBeÑompleted = false;
    public bool isActiveButton = false;

    public void CheckInventory()
    {
        foreach (var task in _uiTasks)
        {
            foreach (var item in _itemSlotData)
            {
                int _countPotionInt = int.Parse(task._countPotion.text);
                var dataCell = _itemSlotData.FirstOrDefault(slot => slot.Type == task._itemType && slot.Count == _countPotionInt || slot.Count <= _countPotionInt); //
                
                if (dataCell != null)
                {
                    isÑanBeÑompleted = true;
                    if (isÑanBeÑompleted == true)
                    {
                        isActiveButton = true;
                    }
                }

                if (dataCell == null)
                {
                    break;
                }

            }
        }


    }

    public void BTM_Complete()
    {
        if (isActiveButton) 
        {
            isÑanBeÑompleted = false;
            isActiveButton = false;
            if (_listTaskSo.listTasks.Count ==  _takeTask._saveIndexCurrentTask)
            {
                Debug.Log("1");
                return;
            }
            else
            {
                _takeTask.PlusIndexList(1);
            }
            
        }
        
    }
}
