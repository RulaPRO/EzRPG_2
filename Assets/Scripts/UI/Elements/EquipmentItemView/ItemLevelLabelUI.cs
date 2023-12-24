using Core.Services.EquipmentService.Interfaces;
using TMPro;
using UnityEngine;

namespace UI.Elements.EquipmentItemView
{
    public class ItemLevelLabelUI : EquipmentItemElementUI
    {
        [SerializeField] private TextMeshProUGUI label;

        public override void UpdateUI(IEquipmentItem equipmentItem)
        {
            label.text = $"level {equipmentItem.CurrentLevel}/{equipmentItem.MaxLevel}";
        }
    }
}