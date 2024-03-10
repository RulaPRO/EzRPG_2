using Core.Services.CombatService.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements.Cards.CombatCardView
{
    public class CombatCardCharacterIconImageUI : CombatCardElementUI
    {
        [SerializeField] private Image targetImage;
        
        public override void InitializeUI(ICombatCard combatCard)
        {
            targetImage.sprite = combatCard.Card.Config.Icon;
        }
    }
}