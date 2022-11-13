using UnityEngine;
using System;

namespace Script
{
    public class InventoryEventArgs : EventArgs
    {
        public InventoryEventArgs(InventoryItemBase item)
        {
            Item = item;
        }

        public InventoryItemBase Item;
    }
}