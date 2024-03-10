namespace Core.Services.CardDeckService.Interfaces
{
    public interface IHavePower
    {
        int BasePower { get; }
        int CurrentPower { get; }
    }
}