using System;
using System.Collections.Generic;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.InventoryService.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements.EquipmentItemView
{
    public class ItemRarityImageUI : EquipmentItemElementUI, ISerializationCallbackReceiver
    {
        [Serializable]
        private class RaritySprite
        {
            public RarityType rarityType;
            public Sprite sprite;
        }

        [SerializeField]
        private Image targetImage;

        [SerializeField]
        private RaritySprite[] raritySprites;

        private readonly Dictionary<RarityType, Sprite> sprites = new();

        public override void UpdateUI(IEquipmentItem equipmentItem)
        {
            targetImage.sprite = GetSprite(equipmentItem.RarityType);
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            foreach (var pair in raritySprites)
            {
                sprites[pair.rarityType] = pair.sprite;
            }
        }

        private Sprite GetSprite(RarityType rarityType) => sprites[rarityType];
    }
}