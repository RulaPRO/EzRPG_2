using Core.Services.EquipmentService.Interfaces;

namespace Core.Services.EquipmentService.Implementation
{
    public class EquipmentItem : IEquipmentItem
    {
        public int BalanceID { get; }

        public EquipmentItem(int balanceID)
        {
            BalanceID = balanceID;
        }
    }
}