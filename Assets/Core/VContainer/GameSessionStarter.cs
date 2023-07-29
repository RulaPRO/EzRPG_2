using Core.Services.Interfaces;
using UI.Screens;
using VContainer.Unity;

namespace Core.VContainer
{
    public class GameSessionStarter : IStartable
    {
        private readonly IUIService uiService;

        public GameSessionStarter(IUIService uiService)
        {
            this.uiService = uiService;
        }

        public void Start()
        {
            uiService.ShowScreen<GameplayHUDScreen>();
        }
    }
}