namespace Core.Services.CardDeckService.Interfaces
{
    public interface ICardBonus
    {
        CardBonusType Type { get; }
        int Value { get; }
    }

    public enum CardBonusType
    {
        UNKNOWN = 0,
        DAMAGE_BASE,
        DAMAGE_EQUIPMENT,
        AGRO,
        INVISIBLE,

        FOCUSING,
    }
}