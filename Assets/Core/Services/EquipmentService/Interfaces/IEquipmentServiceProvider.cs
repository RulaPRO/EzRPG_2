using System;
using System.Collections.Generic;

namespace Core.Services.EquipmentService.Interfaces
{
    public interface IEquipmentServiceProvider
    {
        event Action<IEquipmentItem> OnItemAdded;
        event Action<IEquipmentItem> OnItemRemoved;
        event Action<string> OnItemRarityUpgraded;
        IReadOnlyDictionary<string, IEquipmentItem> AvailableItems { get; }
    }
}