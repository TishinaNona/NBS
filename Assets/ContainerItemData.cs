using UnityEngine;

public class ContainerItemData : MonoBehaviour
{
    [SerializeField] private GameObject[] _itemsData;
    [SerializeField] private GameObject[] _slotIstem;
    [SerializeField] private GameObject _ContainerPrefab; 
    [SerializeField] private GameObject _Panel;
        
    private void Update()
    {
        BTM_ActiveInventoryPanel(); 
    }
    public void BTM_ActiveInventoryPanel()
    {
        if (Input.GetKey(KeyCode.E))
        {  
            GiveItesmInSlotInventory();
        } 
    }

    //public void BTM_CloseInventoryPanel() //  а нужно ли возвращать?
    //{
    //    if (Input.GetKey(KeyCode.L))
    //    { 
    //        TakeItemsInContainer();
    //    } 
        
    //} 

    public void GiveItesmInSlotInventory()
    { 
        for (int i = 0; i < _itemsData.Length; i++)
        {
            _itemsData[i].transform.SetParent(_slotIstem[i].transform);
            _itemsData[i].transform.localScale = Vector3.one;  
        }
    }

    //public void TakeItemsInContainer()
    //{
    //    for (int i = 0; i < _itemsData.Length; i++)
    //    {
    //        _itemsData[i].transform.SetParent(_ContainerPrefab.transform);
    //    }
    //}
}
