using Core.Services.InventoryService.Interfaces;

namespace Core.Services.EquipmentService.Interfaces
{
    public interface IEquipmentItem : IInventoryObject, IHaveEquipmentType, IHaveLevel
    {
    }
}