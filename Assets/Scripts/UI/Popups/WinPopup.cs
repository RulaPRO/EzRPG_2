using System;
using Commands.UI;
using Core.CommandRunner.Interfaces;
using Core.Services.UI;
using UI.Screens;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Popups
{
    public class WinPopup : UIPopup
    {
        [SerializeField] private Button okButton;
        [SerializeField] private Button backgroundButton;

        private ICommandExecutionService commandExecutionService;

        private void Awake()
        {
            okButton.onClick.AddListener(() =>
            {
                Hide();

                commandExecutionService.Execute<ShowScreenCommand<GameplayHUDScreen>>();
            });

            backgroundButton.onClick.AddListener(() =>
            {
                Hide();

                commandExecutionService.Execute<ShowScreenCommand<GameplayHUDScreen>>();
            });
        }

        [Inject]
        public void Construct(ICommandExecutionService commandExecutionService)
        {
            this.commandExecutionService = commandExecutionService;
        }
    }
}