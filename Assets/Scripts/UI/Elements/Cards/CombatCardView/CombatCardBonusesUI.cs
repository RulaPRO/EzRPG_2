using System;
using System.Collections.Generic;
using Core.Services.CardDeckService.Interfaces;
using Core.Services.CombatService.Interfaces;
using UnityEngine;

namespace UI.Elements.Cards.CombatCardView
{
    public class CombatCardBonusesUI : CombatCardElementUI, ISerializationCallbackReceiver
    {
        [Serializable]
        private class CardBonusData
        {
            public CardBonusType Type;
            public GameObject IconObject;
        }

        [SerializeField]
        private CardBonusData[] cardBonuses;

        private readonly Dictionary<CardBonusType, GameObject> bonuses = new();

        public override void InitializeUI(ICombatCard combatCard)
        {
            foreach (var iconObject in bonuses.Values)
            {
                iconObject.SetActive(false);
            }

            foreach (var pair in combatCard.Bonuses)
            {
                if (bonuses.ContainsKey(pair.Key))
                {
                    bonuses[pair.Key].SetActive(true);
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            foreach (var pair in cardBonuses)
            {
                bonuses[pair.Type] = pair.IconObject;
            }
        }
    }
}