using Core.Services.EquipmentService.Interfaces;

namespace Core.Services.UpgradeEquipmentService.Interfaces
{
    public interface IUpgradeEquipmentService
    {
        IEquipmentItem UpgradeEquipmentLevel(IEquipmentItem equipmentItem);
        IEquipmentItem UpgradeEquipmentRarity(IEquipmentItem equipmentItem);
    }
}