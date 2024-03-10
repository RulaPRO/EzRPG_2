using Balance;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.InventoryService.Interfaces;

namespace Core.Services.CardDeckService.Interfaces
{
    public interface ICard : IHaveObjectId, IHaveRarityType, IHaveLevel, IHavePower, IHaveAttackType
    {
        CardConfig Config { get; }
    }
}