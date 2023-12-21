using Core.Services.EquipmentService.Interfaces;

namespace Core.Services.UpgradeEquipmentService.Interfaces
{
    public interface IUpgradeEquipmentService
    {
        IEquipmentItem UpgradeEquipmentRarity(IEquipmentItem equipmentItem);
    }
}