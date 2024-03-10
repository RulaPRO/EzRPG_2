using System;
using System.Collections.Generic;
using Core.Services.CardDeckService.Interfaces;

namespace Core.Services.CombatService.Interfaces
{
    public interface ICombatCard
    {
        event Action OnCurrentPowerChange;

        ICard Card { get; }
        int CurrentCardPower { get; }
        Dictionary<CardBonusType, int> Bonuses { get; }

        void ApplyDamage(int value);
    }
}