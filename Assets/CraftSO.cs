using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{ 
    [CreateAssetMenu(fileName = "ReceptPotions", menuName = "ReceptPotions")]


    public class CraftSO : ScriptableObject
    {
        public List<Receipts> ReceiptsPotions;

    }
}
