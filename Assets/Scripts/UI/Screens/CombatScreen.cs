using System.Collections.Generic;
using System.Linq;
using Commands;
using Commands.Combat;
using Core.CommandRunner.Interfaces;
using Core.Services.CombatService.Interfaces;
using Core.Services.UI;
using UI.Elements.Cards;
using UI.Popups;
using UnityEngine;
using VContainer;

namespace UI.Screens
{
    public class CombatScreen : UIScreen
    {
        [SerializeField] private CombatCardUI[] enemyCards;
        [SerializeField] private CombatCardUI[] playerCards;

        private Dictionary<string, CombatCardUI> enemyCardsUI = new();
        private Dictionary<string, CombatCardUI> playerCardsUI = new();

        private ICombatService combatService;
        private ICommandExecutionService commandExecutionService;
        
        [Inject]
        public void Construct(
            ICombatService combatService,
            ICommandExecutionService commandExecutionService)
        {
            this.combatService = combatService;
            this.commandExecutionService = commandExecutionService;
            
            var counter = 0;
            foreach (var pair in combatService.EnemyCardDeck.Cards)
            {
                enemyCards[counter].InitializeUI(pair.Value);
                enemyCards[counter].OnDefaultClickAction = () => OnCardDefaultClick(pair.Value.Card.ObjectId);
                enemyCards[counter].OnLongPressAction = () => OnCardLongClick(pair.Value.Card.ObjectId);
                enemyCardsUI.Add(pair.Key, enemyCards[counter]);
                counter++;
            }

            counter = 0;
            foreach (var pair in combatService.PlayerCardDeck.Cards)
            {
                playerCards[counter].InitializeUI(pair.Value);
                playerCards[counter].OnDefaultClickAction = () => OnCardDefaultClick(pair.Value.Card.ObjectId);
                playerCards[counter].OnLongPressAction = () => OnCardLongClick(pair.Value.Card.ObjectId);
                playerCardsUI.Add(pair.Key, playerCards[counter]);
                counter++;
            }

            this.combatService.OnCardSelected += OnCardSelect;
            this.combatService.OnCardUnSelected += UnSelectCard;
            this.combatService.OnCardDeath += OnCardDeath;
            this.combatService.OnTurnEnded += OnTurnEnd;
            this.combatService.OnCombatEnded += OnCombatEnd;
        }

        private void OnCardSelect(string cardId)
        {
            // enemy deck
            var cardsAvailableToAttack = combatService.GetCardsAvailableToAttack(cardId);
            foreach (var pair in enemyCardsUI)
            {
                pair.Value.SetInteractableStateActive(cardsAvailableToAttack.Contains(pair.Key));
            }
            
            // player deck
            foreach (var pair in playerCardsUI)
            {
                pair.Value.SetInteractableStateActive(pair.Key.Equals(cardId));
            }
        }

        private void UnSelectCard(string cardId)
        {
            // enemy deck
            foreach (var cardUI in enemyCardsUI.Values)
            {
                cardUI.SetInteractableStateActive(true);
            }
            
            // player deck
            foreach (var cardUI in playerCardsUI.Values)
            {
                cardUI.SetInteractableStateActive(true);
            }
        }

        private void OnCardDeath(string cardId)
        {
            enemyCardsUI[cardId].gameObject.SetActive(false);

            enemyCardsUI.Remove(cardId);
        }

        private void OnTurnEnd()
        {
            
        }

        private void OnCombatEnd()
        {
            commandExecutionService.Execute<ShowPopupCommand<WinPopup>>();
        }

        private void OnCardDefaultClick(string cardId)
        {
            var selectCardData = new SelectCardData
            {
                CardId = cardId
            };
            commandExecutionService.Execute<TrySelectCardCommand, SelectCardData>(selectCardData);
        }

        private void OnCardLongClick(string cardObjectId)
        {
            commandExecutionService.Execute<ShowPopupCommand<CombatCardInfoPopup>>();
        }
    }
}