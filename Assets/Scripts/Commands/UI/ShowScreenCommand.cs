using Core.CommandRunner.Interfaces.Command;
using Core.Services.Interfaces;
using Core.Services.UI;
using VContainer;

namespace Commands.UI
{
    public class ShowScreenCommand<TScreen> : ICommand
        where TScreen : UIScreen
    {
        private IUIService uiService;

        [Inject]
        public void Construct(IUIService uiService)
        {
            this.uiService = uiService;
        }

        public void Execute()
        {
            uiService.ShowScreen<TScreen>();
        }
    }
}