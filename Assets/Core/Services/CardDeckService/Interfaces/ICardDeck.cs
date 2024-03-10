using System.Collections.Generic;

namespace Core.Services.CardDeckService.Interfaces
{
    public interface ICardDeck
    {
        IReadOnlyDictionary<string, ICard> Cards { get; }

        void AddCard(string id, ICard card);
        void RemoveCard(string id);
        void SwapCard(string id, ICard card);
    }
}