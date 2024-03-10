namespace Core.Services.CardDeckService.Interfaces
{
    public interface IHaveAttackType
    {
        AttackType AttackType { get; }
    }

    public enum AttackType
    {
        Unknown = 0,
        Melee = 1,
        Range = 2
    }
}