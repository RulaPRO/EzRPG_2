using Core.Services.CombatService.Interfaces;
using UnityEngine;

namespace UI.Elements.Cards.CombatCardView
{
    public abstract class CombatCardElementUI : MonoBehaviour
    {
        public abstract void InitializeUI(ICombatCard combatCard);
    }
}