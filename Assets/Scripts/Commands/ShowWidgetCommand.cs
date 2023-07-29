using Core.CommandRunner.Interfaces.Command;
using Core.Services.Interfaces;
using Core.Services.UI;
using VContainer;

namespace Commands
{
    public class ShowWidgetCommand<TWidget> : ICommand
        where TWidget : UIWidget
    {
        private IUIService uiService;

        [Inject]
        public void Construct(IUIService uiService)
        {
            this.uiService = uiService;
        }

        public void Execute()
        {
            uiService.ShowWidget<TWidget>();
        }
    }
}