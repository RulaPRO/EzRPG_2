using System;
using System.Collections.Generic;

namespace Core.Services.EquipmentService.Interfaces
{
    public interface IEquipmentService
    {
        event Action<string> OnItemAdded;
        event Action<string> OnItemRemoved;
        event Action<string> OnItemUpgraded;

        IReadOnlyDictionary<string, IEquipmentItem> AvailableItems { get; }

        void AddItem(IEquipmentItem equipmentItem);
        void RemoveItem(IEquipmentItem equipmentItem);
        bool TryUpgradeItemLevel(string id);
        bool TryUpgradeItemRarity(string id);
    }
}