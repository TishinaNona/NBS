using Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class Receipts
    {
        public Sprite AvatarItem;
        public ItemTypeEnum ItemPotionType;
        public bool isCraft;
        public int Count;

        public List<ItemsForReceptStruct> itemsForReceiptstStructs;
    }

}
