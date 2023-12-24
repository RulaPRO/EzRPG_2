using System;
using System.Collections.Generic;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.InventoryService.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements.EquipmentItemView
{
    public class ItemRarityImageColorUi : EquipmentItemElementUI, ISerializationCallbackReceiver
    {
        [Serializable]
        private class RarityColor
        {
            public RarityType RarityType;
            public Color Color;
        }

        [SerializeField]
        private Image targetImage;

        [SerializeField]
        private RarityColor[] rarityColors;

        private readonly Dictionary<RarityType, Color> colors = new();

        public override void UpdateUI(IEquipmentItem equipmentItem)
        {
            targetImage.color = GetColor(equipmentItem.RarityType);
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            foreach (var pair in rarityColors)
            {
                colors[pair.RarityType] = pair.Color;
            }
        }

        private Color GetColor(RarityType rarityType) => colors[rarityType];
    }
}