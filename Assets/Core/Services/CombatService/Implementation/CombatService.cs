using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.CardDeckService.Implementation;
using Core.Services.CardDeckService.Interfaces;
using Core.Services.CombatService.Interfaces;
using UnityEngine;
using VContainer;

namespace Core.Services.CombatService.Implementation
{
    public class CombatService : ICombatService
    {
        public event Action OnCombatStarted;
        public event Action OnCombatEnded;
        public event Action<string> OnCardSelected;
        public event Action<string> OnCardUnSelected;
        public event Action OnTurnEnded;
        public event Action<string> OnCardAttacked;
        public event Action<string> OnCardDeath;

        public CombatCardDeck PlayerCardDeck { get; private set; }
        public CombatCardDeck EnemyCardDeck { get; private set; }

        private readonly ICardDeckService cardDeckService;

        [Inject]
        public CombatService(
            ICardDeckService cardDeckService)
        {
            this.cardDeckService = cardDeckService;
        }

        public bool TryStartCombat()
        {
            PlayerCardDeck = new CombatCardDeck(cardDeckService.CardDeck);

            var enemyCardDeck = new CardDeck();
            for (var i = 0; i < 6; i++)
            {
                var card = new Card("Card_2");
                enemyCardDeck.AddCard(card.ObjectId, card);
            }

            EnemyCardDeck = new CombatCardDeck(enemyCardDeck);

            return true;
        }

        public void TrySelectCard(string cardId)
        {
            if (PlayerCardDeck.Cards.ContainsKey(cardId))
            {
                // player unselect
                if (cardId.Equals(PlayerCardDeck.SelectedCardId))
                {
                    UnSelectCard();
                    return;
                }

                //player select
                PlayerCardDeck.SelectedCardId = cardId;
                OnCardSelected?.Invoke(cardId);
                return;
            }

            if (EnemyCardDeck.Cards.ContainsKey(cardId))
            {
                if (!string.IsNullOrEmpty(PlayerCardDeck.SelectedCardId))
                {
                    AttackCard(cardId);
                    return;
                }
            }
        }

        private void UnSelectCard()
        {
            OnCardUnSelected?.Invoke(PlayerCardDeck.SelectedCardId);
            PlayerCardDeck.SelectedCardId = string.Empty;
        }

        private void AttackCard(string cardId)
        {
            Debug.LogError($"AttackCard ID {cardId}");

            var attackerPower = PlayerCardDeck.SelectedCard.CurrentCardPower;
            var targetPower =  PlayerCardDeck.SelectedCard.Card.AttackType != AttackType.Range
                ? EnemyCardDeck.Cards[cardId].CurrentCardPower
                : 0;

            EnemyCardDeck.Cards[cardId].ApplyDamage(attackerPower);
            PlayerCardDeck.SelectedCard.ApplyDamage(targetPower);

            OnCardAttacked?.Invoke(cardId);

            var deathCardKeys = (from pair in EnemyCardDeck.Cards where pair.Value.IsDeath select pair.Key).ToList();
            foreach (var key in deathCardKeys)
            {
                OnCardDeath?.Invoke(key);
                EnemyCardDeck.Cards.Remove(key);
            }

            UnSelectCard();

            OnTurnEnded?.Invoke();

            if (EnemyCardDeck.Cards.Count == 0)
            {
                OnCombatEnded?.Invoke();
            }
        }

        public IEnumerable<string> GetCardsAvailableToAttack(string cardId)
        {
            Debug.LogError($"GetCardsAvailableToAttack {cardId}");

            if (PlayerCardDeck.SelectedCard.Bonuses.ContainsKey(CardBonusType.FOCUSING))
            {
                return EnemyCardDeck.Cards.Keys.ToList();
            }

            if (!EnemyCardDeck.IsAnyAgroCardActive())
            {
                return EnemyCardDeck.Cards.Keys.ToList();
            }

            return from pair in EnemyCardDeck.Cards
                where pair.Value.Bonuses.ContainsKey(CardBonusType.AGRO)
                select pair.Key;
        }
    }
}