using System;
using System.Collections.Generic;
using Core.Services.CardDeckService.Interfaces;
using Core.Services.CombatService.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Services.CombatService.Implementation
{
    public class CombatCard : ICombatCard
    {
        public event Action OnCurrentPowerChange;

        public int CurrentCardPower => currentCardPower;
        private int currentCardPower;

        public bool IsDeath => currentCardPower == 0;

        public Dictionary<CardBonusType, int> Bonuses { get; }

        public ICard Card { get; }
        
        public CombatCard(ICard card)
        {
            Card = card;
            currentCardPower = card.CurrentPower;

            Bonuses = new Dictionary<CardBonusType, int>
            {
                {CardBonusType.DAMAGE_BASE, 10},
                {CardBonusType.DAMAGE_EQUIPMENT, 10 + (int)(Card.CurrentLevel * 0.5)},
            };

            if (Random.Range(0, 2) > 0)
            {
                Bonuses.Add(CardBonusType.AGRO, 1);
            }

            if (Random.Range(0, 2) > 0)
            {
                Bonuses.Add(CardBonusType.FOCUSING, 1);
            }
        }

        public void ApplyDamage(int value)
        {
            currentCardPower = Mathf.Max(currentCardPower - value, 0);
            
            OnCurrentPowerChange?.Invoke();
        }
    }
}