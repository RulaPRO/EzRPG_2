using Core.Services.Interfaces;
using Core.Services.UI;
using UI.Popups;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Screens
{
    public class GameplayHUDScreen : UIScreen
    {
        [SerializeField] private Button button;

        private IUIService uiService;

        [Inject]
        public void Construct(IUIService uiService)
        {
            this.uiService = uiService;

            Debug.Log($"GameplayHUDScreen Construct. Inject - {uiService.GetType()}");
        }

        private void Start()
        {
            button.onClick.AddListener(() => uiService.ShowPopup<ConfirmationPopup>());
        }
    }
}