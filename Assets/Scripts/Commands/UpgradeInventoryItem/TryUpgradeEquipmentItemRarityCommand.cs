using Core.CommandRunner.Interfaces.Command;
using Core.Services.EquipmentService.Interfaces;
using VContainer;

namespace Commands.UpgradeInventoryItem
{
    public class TryUpgradeEquipmentItemRarityCommand : ICommandWithData<UpgradeEquipmentItemRarityData>
    {
        private IEquipmentService equipmentService;

        [Inject]
        public void Construct(
            IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        public void Execute(UpgradeEquipmentItemRarityData commandData)
        {
            equipmentService.TryUpgradeItemRarity(commandData.EquipmentItemId);
        }
    }
}