using System;
using System.Linq;
using Commands.UpgradeCard;
using Core.CommandRunner.Interfaces;
using Core.Services.CardDeckService.Interfaces;
using Core.Services.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Popups
{
    public class CardInfoPopup : UIPopup
    {
        [SerializeField] private Button buttonClose;
        [SerializeField] private Button buttonBackground;
        [SerializeField] private Button buttonUpgrade;
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI levelValueLabel;
        [SerializeField] private TextMeshProUGUI levelProgressLabel;
        [SerializeField] private TextMeshProUGUI shortId;
        [SerializeField] private TextMeshProUGUI powerLabel;

        private ICommandExecutionService commandExecutionService;
        private ICardDeckService cardDeckService;

        private string cardId;

        private void Start()
        {
            buttonClose.onClick.AddListener(Hide);
            buttonUpgrade.onClick.AddListener(OnUpgradeButtonClick);
        }

        private void OnDestroy()
        {
            cardDeckService.OnCardUpgrade -= UpdateUI;
        }

        [Inject]
        public void Construct(
            ICommandExecutionService commandExecutionService,
            ICardDeckService cardDeckService)
        {
            this.commandExecutionService = commandExecutionService;
            this.cardDeckService = cardDeckService;

            cardDeckService.OnCardUpgrade += UpdateUI;
        }

        public void InitializeUI(string cardId)
        {
            this.cardId = cardId;
            var card = cardDeckService.CardDeck.Cards[cardId];

            icon.sprite = card.Config.Icon;
            shortId.text = card.ShortObjectId;
            levelValueLabel.text = $"LEVEL {card.CurrentLevel}";
            levelProgressLabel.text = $"{card.CurrentLevel}/{card.MaxLevel}";
            powerLabel.text = card.CurrentPower.ToString();
        }
        
        private void UpdateUI(string id)
        {
            if (!cardId.Equals(id))
            {
                return;
            }

            var card = cardDeckService.CardDeck.Cards[cardId];
            levelValueLabel.text = $"LEVEL {card.CurrentLevel}";
            levelProgressLabel.text = $"{card.CurrentLevel}/{card.MaxLevel}";
            powerLabel.text = card.CurrentPower.ToString();
        }

        private void OnUpgradeButtonClick()
        {
            var data = new UpgradeCardData
            {
                CardId = cardId
            };
            commandExecutionService.Execute<TryUpgradeCardLevelCommand, UpgradeCardData>(data);
        }
    }
}