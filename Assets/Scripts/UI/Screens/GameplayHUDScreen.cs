using Commands;
using Core.CommandRunner.Interfaces;
using Core.Services.UI;
using UI.Popups;
using UI.Widgets;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Screens
{
    public class GameplayHUDScreen : UIScreen
    {
        [SerializeField] private Button buttonHelloWorld;
        [SerializeField] private Button buttonInventory;
        [SerializeField] private Button buttonProduction;

        private ICommandExecutionService commandExecutionService;

        private void Start()
        {
            buttonHelloWorld.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<ShowPopupCommand<ConfirmationPopup>>();
            });

            buttonInventory.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<ShowPopupCommand<InventoryPopup>>();
            });

            buttonProduction.onClick.AddListener(() =>
            {
                commandExecutionService.Execute<ShowPopupCommand<ProductionPopup>>();
            });
        }

        [Inject]
        public void Construct(ICommandExecutionService commandExecutionService)
        {
            this.commandExecutionService = commandExecutionService;
        }

        public override void Show()
        {
            base.Show();

            commandExecutionService.Execute<ShowWidgetCommand<TopBarWidget>>();
        }

        public override void Hide()
        {
            base.Hide();

            commandExecutionService.Execute<ShowWidgetCommand<TopBarWidget>>();
        }
    }
}