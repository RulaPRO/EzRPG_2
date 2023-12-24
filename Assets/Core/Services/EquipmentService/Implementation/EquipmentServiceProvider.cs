using System;
using System.Collections.Generic;
using Core.Services.EquipmentService.Interfaces;
using VContainer;

namespace Core.Services.EquipmentService.Implementation
{
    public class EquipmentServiceProvider : IEquipmentServiceProvider, IDisposable
    {
        public event Action<IEquipmentItem> OnItemAdded;
        public event Action<IEquipmentItem> OnItemRemoved;
        public event Action<string> OnItemRarityUpgraded;
        public IReadOnlyDictionary<string, IEquipmentItem> AvailableItems => equipmentService.AvailableItems;

        private readonly IEquipmentService equipmentService;

        [Inject]
        public EquipmentServiceProvider(
            IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;

            equipmentService.OnItemAdded += OnEquipmentItemAdd;
            equipmentService.OnItemRemoved += OnEquipmentItemRemove;
            equipmentService.OnItemUpgraded += OnEquipmentItemUpgrade;
        }

        public void Dispose()
        {
            equipmentService.OnItemAdded -= OnEquipmentItemAdd;
            equipmentService.OnItemRemoved -= OnEquipmentItemRemove;
            equipmentService.OnItemUpgraded -= OnItemRarityUpgraded;
        }

        private void OnEquipmentItemAdd(string id)
        {
            OnItemRarityUpgraded?.Invoke(id);
        }

        private void OnEquipmentItemRemove(string id)
        {
            OnItemRarityUpgraded?.Invoke(id);
        }

        private void OnEquipmentItemUpgrade(string id)
        {
            OnItemRarityUpgraded?.Invoke(id);
        }
    }
}