using Core.Services;
using VContainer.Unity;

namespace Core.VContainer.GameServices
{
    public class SaveLoadService : IStartable, ITickable
    {
        private readonly UIService _uiService;
        private readonly HUDScreen hudScreen;

        public string Kek = "KEK";

        public SaveLoadService(UIService uiService, HUDScreen hudScreen)
        {
            this._uiService = uiService;
            this.hudScreen = hudScreen;
        }

        public void Start()
        {
            hudScreen.Button.onClick.AddListener(() => _uiService.Hello());
        }

        public void Tick()
        {
            //helloWorldService.Hello();
        }
    }
}