using Core.Services.CombatService.Interfaces;
using TMPro;
using UnityEngine;

namespace UI.Elements.Cards.CombatCardView
{
    public class CombatCardPowerLabelUI : CombatCardElementUI
    {
        [SerializeField] private TextMeshProUGUI label;

        private ICombatCard combatCard;

        private void OnDestroy()
        {
            combatCard.OnCurrentPowerChange -= UpdateUI;
        }

        public override void InitializeUI(ICombatCard combatCard)
        {
            this.combatCard = combatCard;
            combatCard.OnCurrentPowerChange += UpdateUI;

            UpdateUI();
        }
        
        private void UpdateUI()
        {
            label.text = combatCard.CurrentCardPower.ToString();
        }
    }
}