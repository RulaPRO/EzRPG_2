using System;
using Core.Services.CardDeckService.Interfaces;
using UI.Elements.Cards.CardElementsUI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements.Cards
{
    public class CardUI : MonoBehaviour
    {
        public Action OnClickAction;

        [SerializeField] private Button button;
        [SerializeField] private CardElementUI[] cardElementsUI;

        private void Awake()
        {
            button.onClick.AddListener(() => OnClickAction?.Invoke());
        }

        public void InitializeUI(ICard combatCard)
        {
            foreach (var cardElementUI in cardElementsUI)
            {
                cardElementUI.InitializeUI(combatCard);
            }
        }
    }
}