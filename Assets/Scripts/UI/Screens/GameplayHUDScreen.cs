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

        public Button Button => button;

        [Inject]
        public void Construct(IUIService uiService)
        {
            Debug.LogError("HUDScreen Construct");
        }
    }
}