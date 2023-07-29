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
        [SerializeField] private Button addHealthButton = default;
        [SerializeField] private Button removeHealthButton = default;

        private ICommandExecutionService commandExecutionService;
        private IHealthService healthService;

        private void Start()
        {
            addHealthButton.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<HelloWordCommand>();
            });
        }

        [Inject]
        public void Construct(ICommandExecutionService commandExecutionService, IHealthService healthService)
        {
            this.commandExecutionService = commandExecutionService;
            this.healthService = healthService;
        }
    }
}