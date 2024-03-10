using System.Collections.Generic;
using System.Linq;
using Core.Services.CardDeckService.Interfaces;
using Core.Services.CombatService.Implementation;

namespace Core.Services.CardDeckService.Implementation
{
    public class CombatCardDeck
    {
        public Dictionary<string, CombatCard> Cards = new();
        public CombatCard SelectedCard => Cards[SelectedCardId];
        public string SelectedCardId { get; set; }

        public CombatCardDeck(ICardDeck cardDeck)
        {
            foreach (var pair in cardDeck.Cards)
            {
                Cards.Add(pair.Key, new CombatCard(pair.Value));
            }
        }

        public bool IsAnyAgroCardActive()
        {
            return Cards.Values.Any(card => card.Bonuses.ContainsKey(CardBonusType.AGRO));
        }
    }
}