using System;
using Core.Services.CardDeckService.Interfaces;

namespace Core.Services.CardDeckService.Implementation
{
    public class CardDeckService : ICardDeckService
    {
        public event Action<string> OnCardUpgrade;
        public ICardDeck CardDeck { get; }

        public CardDeckService()
        {
            CardDeck = new CardDeck();

            var card1 = new Card("Card_1");
            CardDeck.AddCard(card1.ObjectId, card1);
            var card2 = new Card("Card_2");
            CardDeck.AddCard(card2.ObjectId, card2);
            var card3 = new Card("Card_1");
            CardDeck.AddCard(card3.ObjectId, card3);
            var card4 = new Card("Card_2");
            CardDeck.AddCard(card4.ObjectId, card4);
            var card5 = new Card("Card_1");
            CardDeck.AddCard(card5.ObjectId, card5);
            var card6 = new Card("Card_2");
            CardDeck.AddCard(card6.ObjectId, card6);
        }

        public void UpgradeCard(string id)
        {
            var oldCard = CardDeck.Cards[id];
            var newCard = new Card(oldCard.ObjectId, oldCard.Config, oldCard.RarityType, oldCard.CurrentLevel + 1);

            CardDeck.RemoveCard(id);
            CardDeck.AddCard(id, newCard);

            OnCardUpgrade?.Invoke(id);
        }
    }
}