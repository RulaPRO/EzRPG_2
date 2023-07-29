using System;
using Commands;
using Core.CommandRunner.Interfaces;
using Core.Services.HealthService.Interfaces;
using Core.Services.Interfaces;
using Core.Services.UI;
using TMPro;
using UI.Popups;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Widgets
{
    public class TopBarWidget : UIWidget
    {
        [SerializeField] private Button TEST_MODE;
        [SerializeField] private TextMeshProUGUI healthLabel;

        private ICommandExecutionService commandExecutionService;
        private IHealthService healthService;
        private IUIService uiService;

        private void Start()
        {
            healthService.OnValueChanged += UpdateHealth;

            TEST_MODE.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<ShowPopupCommand<TestModePopup>>();
            });
        }

        private void OnDestroy()
        {
            healthService.OnValueChanged -= UpdateHealth;
        }

        [Inject]
        public void Construct(ICommandExecutionService commandExecutionService, IHealthService healthService, IUIService uiService)
        {
            this.commandExecutionService = commandExecutionService;
            this.healthService = healthService;
            this.uiService = uiService;

            UpdateHealth();
        }

        private void UpdateHealth()
        {
            healthLabel.text = $"{healthService.CurrentValue}/{healthService.MaxValue}";
        }
    }
}