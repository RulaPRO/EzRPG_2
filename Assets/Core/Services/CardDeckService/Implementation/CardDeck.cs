using System.Collections.Generic;
using Core.Services.CardDeckService.Interfaces;

namespace Core.Services.CardDeckService.Implementation
{
    public class CardDeck : ICardDeck
    {
        public IReadOnlyDictionary<string, ICard> Cards => cards;
        private Dictionary<string, ICard> cards = new();
        public string SelectedCardId { get; set; }

        public void AddCard(string id, ICard card)
        {
            cards.Add(id, card);
        }

        public void RemoveCard(string id)
        {
            cards.Remove(id);
        }

        public void SwapCard(string id, ICard card)
        {
            throw new System.NotImplementedException();
        }
    }
}