using Core.CommandRunner.Interfaces.Command;
using Core.Services.Interfaces;
using Core.Services.UI;
using VContainer;

namespace Commands.UI
{
    public abstract class ShowPopupCommandWithData<TPopup, TData> : ICommandWithData<TData>
    where TPopup : UIPopup
    where TData : struct
    {
        private IUIService uiService;

        [Inject]
        public void Construct(IUIService uiService)
        {
            this.uiService = uiService;
        }

        public virtual void Execute(TData commandData)
        {
            var popup = uiService.ShowPopup<TPopup>();
            InitializePopup(popup, commandData);
        }

        protected abstract void InitializePopup(TPopup popup, TData data);
    }
}