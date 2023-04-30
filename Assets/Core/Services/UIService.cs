using System;
using System.Collections.Generic;
using Core.Services.Interfaces;
using Core.Services.UI;
using UI;
using UI.Screens;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Services
{
    public class UIService : IUIService
    {
        private const string ROOT_CANVAS_PREFAB_PATH = "UI/RootCanvas";

        private readonly Dictionary<Type, UIScreen> createdScreens = new();
        private readonly Dictionary<Type, UIPopup> createdPopups = new();

        public RootCanvas RootCanvas { get; private set; }

        public UIService()
        {
            Debug.LogError("UIService Create");

            CreateUIRoot();
        }

        public TScreen GetScreen<TScreen>() where TScreen : UIScreen
        {
            if (!createdScreens.ContainsKey(typeof(TScreen)))
            {
                createdScreens.Add(typeof(TScreen), CreateScreen<TScreen>());
            }

            return createdScreens[typeof(TScreen)] as TScreen;
        }

        public TScreen ShowScreen<TScreen>() where TScreen : UIScreen
        {
            return null;
        }

        public void HideScreen<TScreen>() where TScreen : UIScreen
        {
        }

        public TPopup ShowPopup<TPopup>() where TPopup : UIPopup
        {
            return null;
        }

        public void HidePopup<TPopup>() where TPopup : UIPopup
        {
        }

        private void CreateUIRoot()
        {
            var rootCanvasPrefab = Resources.Load<RootCanvas>(ROOT_CANVAS_PREFAB_PATH);
            RootCanvas = Object.Instantiate(rootCanvasPrefab);
            Object.DontDestroyOnLoad(RootCanvas);
        }

        private TScreen CreateScreen<TScreen>() where TScreen : UIScreen
        {
            const string GAMEPLAY_HUD_SCREEN_PREFAB_KEY = "UI/Screens/GameplayHUDScreen";

            var gameplayHUDScreenPrefab = Resources.Load<GameplayHUDScreen>(GAMEPLAY_HUD_SCREEN_PREFAB_KEY);
            var gameplayHUDScreen = Object.Instantiate(gameplayHUDScreenPrefab, RootCanvas.transform);

            return gameplayHUDScreen as TScreen;

        }

        public void Dispose()
        {
            if (RootCanvas)
            {
                Object.Destroy(RootCanvas.gameObject);
            }
        }
    }
}