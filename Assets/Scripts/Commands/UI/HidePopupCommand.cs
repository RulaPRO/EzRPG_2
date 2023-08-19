using Core.CommandRunner.Interfaces.Command;
using Core.Services.Interfaces;
using Core.Services.UI;
using VContainer;

namespace Commands
{
    public class HidePopupCommand<TPopup> : ICommand
        where TPopup : UIPopup
    {
        private IUIService uiService;

        [Inject]
        public void Construct(IUIService uiService)
        {
            this.uiService = uiService;
        }

        public void Execute()
        {
            uiService.HidePopup<TPopup>();
        }
    }
}