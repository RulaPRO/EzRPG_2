using Core.Services.EquipmentService.Implementation;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.InventoryService.Interfaces;
using Core.Services.UpgradeEquipmentService.Interfaces;

namespace Core.Services.UpgradeEquipmentService.Implementation
{
    public class UpgradeEquipmentService : IUpgradeEquipmentService
    {
        public IEquipmentItem UpgradeEquipmentRarity(IEquipmentItem equipmentItem)
        {
            var nextRarity = (RarityType)((int)equipmentItem.RarityType + 1);
            var upgradedItem = new EquipmentItem(
                equipmentItem.ObjectId,
                equipmentItem.EquipmentType,
                nextRarity,
                1);

            return upgradedItem;
        }

        public IEquipmentItem UpgradeEquipmentLevel(IEquipmentItem equipmentItem)
        {
            var nextLevel = equipmentItem.CurrentLevel + 1;
            var upgradedItem = new EquipmentItem(
                equipmentItem.ObjectId,
                equipmentItem.EquipmentType,
                equipmentItem.RarityType,
                nextLevel);

            return upgradedItem;
        }
    }
}