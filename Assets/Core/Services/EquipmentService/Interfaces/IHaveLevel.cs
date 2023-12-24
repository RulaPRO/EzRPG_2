namespace Core.Services.EquipmentService.Interfaces
{
    public interface IHaveLevel
    {
        int CurrentLevel { get; }
        int MaxLevel { get; }
        bool IsLevelMax { get; }
    }
}