using Commands;
using Core.CommandRunner.Interfaces;
using Core.Services.HealthService.Interfaces;
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

        private ICommandExecutionService commandExecutionService;

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
        }

        [Inject]
        public void Construct(ICommandExecutionService commandExecutionService)
        {
            this.commandExecutionService = commandExecutionService;
        }
    }
}