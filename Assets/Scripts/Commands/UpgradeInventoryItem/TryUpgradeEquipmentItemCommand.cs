using Core.CommandRunner.Interfaces.Command;
using Core.Services.EquipmentService.Interfaces;
using VContainer;

namespace Commands.UpgradeInventoryItem
{
    public class TryUpgradeEquipmentItemCommand : ICommandWithData<UpgradeEquipmentItemData>
    {
        private IEquipmentService equipmentService;

        [Inject]
        public void Construct(
            IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        public void Execute(UpgradeEquipmentItemData commandData)
        {
            var equipmentItem = equipmentService.AvailableItems[commandData.EquipmentItemId];

            if (equipmentItem.IsLevelMax)
            {
                equipmentService.TryUpgradeItemRarity(commandData.EquipmentItemId);
            }
            else
            {
                equipmentService.TryUpgradeItemLevel(commandData.EquipmentItemId);
            }
        }
    }
}