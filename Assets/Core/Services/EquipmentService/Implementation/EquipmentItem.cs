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

        public int Level { get; }
        public bool IsLevelMax => Level < 10;

        public EquipmentItem()
        {
            ObjectId = Guid.NewGuid().ToString();
            EquipmentType = EquipmentType.Weapon;
            RarityType = RarityType.Common;
            Level = 1;
        }

        public EquipmentItem(RarityType rarityType)
        {
            ObjectId = Guid.NewGuid().ToString();
            EquipmentType = EquipmentType.Weapon;
            RarityType = rarityType;
            Level = 1;
        }

        public EquipmentItem(string objectId)
        {
            ObjectId = objectId;
            EquipmentType = EquipmentType.Weapon;
            RarityType = RarityType.Common;
            Level = 1;
        }

        public EquipmentItem(string objectId, RarityType rarityType)
        {
            ObjectId = objectId;
            EquipmentType = EquipmentType.Weapon;
            RarityType = rarityType;
            Level = 1;
        }

        public EquipmentItem(string objectId, EquipmentType equipmentType, RarityType rarityType)
        {
            ObjectId = objectId;
            EquipmentType = equipmentType;
            RarityType = rarityType;
            Level = 1;
        }
    }
}