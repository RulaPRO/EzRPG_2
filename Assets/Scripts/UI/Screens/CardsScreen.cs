using System;
using System.Collections.Generic;
using Commands;
using Commands.UI;
using Commands.UI.CardInfoPopupCommand;
using Core.CommandRunner.Interfaces;
using Core.Services.CardDeckService.Interfaces;
using Core.Services.UI;
using UI.Elements.Cards;
using UI.Popups;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Screens
{
    public class CardsScreen : UIScreen
    {
        [SerializeField] private Button buttonClose;
        [SerializeField] private CardUI[] playerCards;

        private Dictionary<string, CardUI> playerCardsUI = new();
        
        private ICardDeckService cardDeckService;
        private ICommandExecutionService commandExecutionService;

        private void Start()
        {
            buttonClose.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<ShowScreenCommand<GameplayHUDScreen>>();
            });
        }

        private void OnDestroy()
        {
            cardDeckService.OnCardUpgrade -= OnCardUpgrade;
        }

        [Inject]
        public void Construct(
            ICardDeckService cardDeckService,
            ICommandExecutionService commandExecutionService)
        {
            this.cardDeckService = cardDeckService;
            this.commandExecutionService = commandExecutionService;

            var counter = 0;
            foreach (var pair in cardDeckService.CardDeck.Cards)
            {
                playerCards[counter].InitializeUI(pair.Value);
                playerCards[counter].OnClickAction = () => OnCardClick(pair.Value.ObjectId);
                playerCardsUI.Add(pair.Key, playerCards[counter]);
                counter++;
            }

            cardDeckService.OnCardUpgrade += OnCardUpgrade;
        }
        
        private void OnCardClick(string cardId)
        {
            Debug.LogError($"Card click {cardId}");
            var commandData = new ShowCardInfoPopupData
            {
                CardId = cardId
            };
            
            commandExecutionService.Execute<ShowCardInfoPopupCommand, ShowCardInfoPopupData>(commandData);
        }
        
        private void OnCardUpgrade(string cardId)
        {
            var card = cardDeckService.CardDeck.Cards[cardId];
            playerCardsUI[cardId].InitializeUI(card);
        }
    }
}