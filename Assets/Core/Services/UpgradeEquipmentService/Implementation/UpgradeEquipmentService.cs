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
            var upgradedItem = new EquipmentItem(equipmentItem.ObjectId, equipmentItem.EquipmentType, nextRarity);

            return upgradedItem;
        }
    }
}