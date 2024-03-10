using System;
using Balance;
using Core.Services.CardDeckService.Interfaces;
using Core.Services.InventoryService.Interfaces;
using UnityEngine;

namespace Core.Services.CardDeckService.Implementation
{
    public class Card : ICard
    {
        public string ObjectId { get; }
        public RarityType RarityType { get; }
        public int CurrentLevel { get; }
        public int MaxLevel => (int)RarityType * 10;
        public bool IsLevelMax { get; }

        public int BasePower => Config.Power;
        public int CurrentPower => BasePower + (int)(CurrentLevel * 0.5);

        public AttackType AttackType => (AttackType)Config.AttackType;

        public CardConfig Config { get; }
        
        public Card(string configId)
        {
            ObjectId = Guid.NewGuid().ToString();
            Config = Resources.Load<CardConfig>($"Cards/{configId}");
            RarityType = RarityType.Common;
            CurrentLevel = 1;
        }

        public Card(
            string objectId,
            CardConfig config,
            RarityType rarityType,
            int currentLevel)
        {
            ObjectId = objectId;
            Config = config;
            RarityType = rarityType;
            CurrentLevel = currentLevel;
        }
    }
}