using Commands;
using Core.CommandRunner.Interfaces;
using Core.Services.Interfaces;
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
        [SerializeField] private Button button;

        private ICommandExecutionService commandExecutionService;
        private IUIService uiService;

        private void Start()
        {
            button.onClick.AddListener(() => uiService.ShowPopup<ConfirmationPopup>());
        }

        [Inject]
        public void Construct(ICommandExecutionService commandExecutionService, IUIService uiService)
        {
            this.commandExecutionService = commandExecutionService;
            this.uiService = uiService;

            Debug.Log($"GameplayHUDScreen Construct. Inject - {uiService.GetType()}");
        }

        public override void Show()
        {
            commandExecutionService.Execute<HelloWordCommand>();
            
            base.Show();

            uiService.ShowWidget<TopBarWidget>();
        }

        public override void Hide()
        {
            base.Hide();

            uiService.HideWidget<TopBarWidget>();
        }
    }
}