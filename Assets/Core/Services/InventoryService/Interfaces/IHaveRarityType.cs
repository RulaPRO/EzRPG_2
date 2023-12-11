using System;

namespace Core.Services.InventoryService.Interfaces
{
    public interface IHaveRarityType
    {
        RarityType RarityType { get; }
        event Action OnRarityChanged;
    }

    public enum RarityType
    {
        Unknown = 0,
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5,
        Mythical = 6
    }
}