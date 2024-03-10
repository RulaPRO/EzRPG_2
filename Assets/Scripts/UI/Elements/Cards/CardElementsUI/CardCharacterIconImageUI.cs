using Core.Services.CardDeckService.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements.Cards.CardElementsUI
{
    public class CardCharacterIconImageUI : CardElementUI
    {
        [SerializeField] private Image targetImage;

        public override void InitializeUI(ICard card)
        {
            targetImage.sprite = card.Config.Icon;
        }
    }
}