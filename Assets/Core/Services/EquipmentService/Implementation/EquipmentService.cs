using System;
using System.Collections.Generic;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.InventoryService.Interfaces;
using Core.Services.UpgradeEquipmentService.Interfaces;
using VContainer;

namespace Core.Services.EquipmentService.Implementation
{
    public class EquipmentService : IEquipmentService
    {
        public event Action<string> OnItemAdded;
        public event Action<string> OnItemRemoved;
        public event Action<string> OnItemRarityUpgraded;
        public IReadOnlyDictionary<string, IEquipmentItem> AvailableItems => availableItems;

        private Dictionary<string, IEquipmentItem> availableItems = new();

        private IUpgradeEquipmentService upgradeEquipmentService;

        [Inject]
        public EquipmentService(IUpgradeEquipmentService upgradeEquipmentService)
        {
            this.upgradeEquipmentService = upgradeEquipmentService;

            AddItem(new EquipmentItem(RarityType.Common));
            AddItem(new EquipmentItem(RarityType.Uncommon));
            AddItem(new EquipmentItem(RarityType.Rare));
            AddItem(new EquipmentItem(RarityType.Epic));
        }

        public void AddItem(IEquipmentItem equipmentItem)
        {
            availableItems.Add(equipmentItem.ObjectId, equipmentItem);

            OnItemAdded?.Invoke(equipmentItem.ObjectId);
        }

        public void RemoveItem(IEquipmentItem equipmentItem)
        {
            availableItems.Remove(equipmentItem.ObjectId);

            OnItemRemoved?.Invoke(equipmentItem.ObjectId);
        }

        public bool TryUpgradeItemRarity(string id)
        {
            var upgradedEquipmentItem = upgradeEquipmentService.UpgradeEquipmentRarity(availableItems[id]);
            availableItems[id] = upgradedEquipmentItem;

            OnItemRarityUpgraded?.Invoke(id);

            return true;
        }
    }
}