using Core.Services.CardDeckService.Interfaces;
using TMPro;
using UnityEngine;

namespace UI.Elements.Cards.CardElementsUI
{
    public class CardPowerLabelUI : CardElementUI
    {
        [SerializeField] private TextMeshProUGUI label;

        public override void InitializeUI(ICard card)
        {
            label.text = card.CurrentPower.ToString();
        }
    }
}