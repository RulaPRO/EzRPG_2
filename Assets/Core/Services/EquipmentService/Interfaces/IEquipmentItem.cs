using Core.Services.InventoryService.Interfaces;

namespace Core.Services.EquipmentService.Interfaces
{
    public interface IEquipmentItem :
        IHaveObjectId,
        IHaveEquipmentType,
        IHaveRarityType,
        IHaveLevel
    {
    }
}