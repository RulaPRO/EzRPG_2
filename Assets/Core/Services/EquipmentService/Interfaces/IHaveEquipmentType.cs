namespace Core.Services.EquipmentService.Interfaces
{
    public interface IHaveEquipmentType
    {
        EquipmentType EquipmentType { get; }
    }

    public enum EquipmentType
    {
        Unknown = 0,
        Weapon = 1,
        Helmet = 2,
        Gloves = 3,
        Torso = 4,
        Pants = 5,
        Boots = 6
    }
}