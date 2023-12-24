using Core.Services.EquipmentService.Interfaces;
using UnityEngine;

namespace UI.Elements.EquipmentItemView
{
    public abstract class EquipmentItemElementUI : MonoBehaviour
    {
        public abstract void UpdateUI(IEquipmentItem equipmentItem);
    }
}