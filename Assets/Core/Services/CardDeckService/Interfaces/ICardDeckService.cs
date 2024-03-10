using System;

namespace Core.Services.CardDeckService.Interfaces
{
    public interface ICardDeckService
    {
        event Action<string> OnCardUpgrade;
        ICardDeck CardDeck { get; }
        void UpgradeCard(string id);
    }
}