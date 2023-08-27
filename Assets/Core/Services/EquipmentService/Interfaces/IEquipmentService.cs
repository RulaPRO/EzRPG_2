using System;
using System.Collections.Generic;

namespace Core.Services.EquipmentService.Interfaces
{
    public interface IEquipmentService
    {
        event Action OnEquipmentItemsUpdated;

        IReadOnlyList< IEquipmentItem> EquipmentItems { get; }

        void AddItem(IEquipmentItem equipmentItem);
        void RemoveItem(IEquipmentItem equipmentItem);
    }
}