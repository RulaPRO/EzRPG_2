using Core.Services.Interfaces;
using Core.Services.UI;
using UI.Screens;
using UnityEngine;

namespace Core.Services
{
    public class UIFactory : IUIFactory
    {
        public TScreen CreateScreen<TScreen>(Transform parent) where TScreen : UIScreen
        {
            const string GAMEPLAY_HUD_SCREEN_PREFAB_KEY = "UI/Screens/GameplayHUDScreen";

            var gameplayHUDScreenPrefab = Resources.Load<GameplayHUDScreen>(GAMEPLAY_HUD_SCREEN_PREFAB_KEY);
            var gameplayHUDScreen = Object.Instantiate(gameplayHUDScreenPrefab, parent);

            return gameplayHUDScreen as TScreen;
        }
    }
}