using Commands;
using Core.CommandRunner.Interfaces;
using Core.Services.EquipmentService.Implementation;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.HealthService.Interfaces;
using Core.Services.ProductionService.Interfaces;
using Core.Services.UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Popups
{
    public class TestModePopup : UIPopup
    {
        [SerializeField] private Button closeButton = default;
        [SerializeField] private Button addHealthButton = default;
        [SerializeField] private Button removeHealthButton = default;
        [SerializeField] private Button startProductionButton = default;
        [SerializeField] private Button addEquipmentItemId1Button;

        private ICommandExecutionService commandExecutionService;
        private IEquipmentService equipmentService;
        private IProductionService productionService;

        private void Start()
        {
            closeButton.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<HidePopupCommand<TestModePopup>>();
            });

            addHealthButton.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<IncreaseHealthCommand, IncreaseHealthData>(new IncreaseHealthData {Value = 10});
            });

            removeHealthButton.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<DecreaseHealthCommand, DecreaseHealthData>(new DecreaseHealthData {Value = 10});
            });

            startProductionButton.onClick.AddListener(() =>
            {
                productionService.TryStartCycle("test", 1);
            });

            addEquipmentItemId1Button.onClick.AddListener(() =>
            {
                equipmentService.AddItem(new EquipmentItem(1));
            });
        }

        [Inject]
        public void Construct(
            ICommandExecutionService commandExecutionService,
            IEquipmentService equipmentService,
            IProductionService productionService)
        {
            this.commandExecutionService = commandExecutionService;
            this.equipmentService = equipmentService;
            this.productionService = productionService;
        }
    }
}