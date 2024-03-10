using System;
using System.Collections.Generic;
using Core.Services.CardDeckService.Implementation;

namespace Core.Services.CombatService.Interfaces
{
    public interface ICombatService
    {
        event Action OnCombatStarted;
        event Action OnCombatEnded;
        event Action<string> OnCardSelected;
        event Action<string> OnCardUnSelected;
        event Action OnTurnEnded;
        event Action<string> OnCardAttacked;
        event Action<string> OnCardDeath;

        CombatCardDeck PlayerCardDeck { get; }
        CombatCardDeck EnemyCardDeck { get; }

        bool TryStartCombat();
        void TrySelectCard(string cardId);
        IEnumerable<string> GetCardsAvailableToAttack(string cardId);
    }
}