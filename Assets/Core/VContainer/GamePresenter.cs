using Core.Services.Interfaces;
using UI.Screens;
using UnityEngine;
using VContainer.Unity;

namespace Core.VContainer
{
    public class GamePresenter : IStartable
    {
        private readonly IUIService uiService;

        public GamePresenter(IUIService uiService)
        {
            this.uiService = uiService;
        }

        public void Start()
        {
            uiService.GetScreen<GameplayHUDScreen>();
        }
    }
}