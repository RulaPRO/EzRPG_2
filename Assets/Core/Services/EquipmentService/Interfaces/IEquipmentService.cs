using System;
using System.Collections.Generic;

namespace Core.Services.EquipmentService.Interfaces
{
    public interface IEquipmentService
    {
        event Action<string> OnItemAdded;
        event Action<string> OnItemRemoved;
        event Action<string> OnItemRarityUpgraded;

        IReadOnlyDictionary<string, IEquipmentItem> AvailableItems { get; }

        void AddItem(IEquipmentItem equipmentItem);
        void RemoveItem(IEquipmentItem equipmentItem);
        bool TryUpgradeItemRarity(string id);
    }
}