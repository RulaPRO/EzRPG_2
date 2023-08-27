using System;
using System.Collections.Generic;
using Core.Services.EquipmentService.Interfaces;
using UnityEngine;

namespace Core.Services.EquipmentService.Implementation
{
    public class EquipmentService : IEquipmentService
    {
        public event Action OnEquipmentItemsUpdated;

        public IReadOnlyList<IEquipmentItem> EquipmentItems => equipmentItems;

        private List<IEquipmentItem> equipmentItems = new();

        public EquipmentService()
        {
            equipmentItems.Add(new EquipmentItem(1));
        }

        public void AddItem(IEquipmentItem equipmentItem)
        {
            equipmentItems.Add(equipmentItem);

            OnEquipmentItemsUpdated?.Invoke();
        }

        public void RemoveItem(IEquipmentItem equipmentItem)
        {
            equipmentItems.Remove(equipmentItem);

            OnEquipmentItemsUpdated?.Invoke();
        }
    }
}