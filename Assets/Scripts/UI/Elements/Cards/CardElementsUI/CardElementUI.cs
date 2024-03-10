using Core.Services.CardDeckService.Interfaces;
using UnityEngine;

namespace UI.Elements.Cards.CardElementsUI
{
    public abstract class CardElementUI : MonoBehaviour
    {
        public abstract void InitializeUI(ICard combatCard);
    }
}