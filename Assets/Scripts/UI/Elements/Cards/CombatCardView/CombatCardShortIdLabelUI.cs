using Core.Services.CombatService.Interfaces;
using TMPro;
using UnityEngine;

namespace UI.Elements.Cards.CombatCardView
{
    public class CombatCardShortIdLabelUI : CombatCardElementUI
    {
        [SerializeField] private TextMeshProUGUI label;
        
        public override void InitializeUI(ICombatCard combatCard)
        {
            label.text = combatCard.Card.ShortObjectId;
        }
    }
}