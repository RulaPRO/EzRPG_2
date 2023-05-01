using Core.Services.Interfaces;
using Core.Services.UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Screens
{
    public class GameplayHUDScreen : UIScreen
    {
        [SerializeField] private Button button;

        [Inject]
        public void Construct(IUIService uiService)
        {
            Debug.Log($"GameplayHUDScreen Construct. Inject - {uiService.GetType()}");
        }

        private void Start()
        {
            button.onClick.AddListener(() => Debug.Log("GameplayHUDScreen Button Click"));
        }
    }
}