using System;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.InventoryService.Interfaces;

namespace Core.Services.EquipmentService.Implementation
{
    public class EquipmentItem : IEquipmentItem
    {
        public string ObjectId { get; }
        public RarityType RarityType { get; }
        public EquipmentType EquipmentType { get; }

        public int CurrentLevel { get; }
        public int MaxLevel => (int)RarityType * 10;
        public bool IsLevelMax => CurrentLevel == MaxLevel;

        public EquipmentItem()
        {
            ObjectId = Guid.NewGuid().ToString();
            EquipmentType = EquipmentType.Weapon;
            RarityType = RarityType.Common;
            CurrentLevel = 1;
        }

        public EquipmentItem(string objectId, EquipmentType equipmentType, RarityType rarityType, int level)
        {
            ObjectId = objectId;
            EquipmentType = equipmentType;
            RarityType = rarityType;
            CurrentLevel = level;
        }
    }
}