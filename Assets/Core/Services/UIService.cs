using System;
using System.Collections.Generic;
using Core.Factories.Interfaces;
using Core.Services.Interfaces;
using Core.Services.UI;
using UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Services
{
    public class UIService : IUIService, IDisposable
    {
        private const string ROOT_CANVAS_PREFAB_PATH = "UI/RootCanvas";

        private readonly Dictionary<Type, UIScreen> createdScreens = new();
        private readonly Dictionary<Type, UIPopup> createdPopups = new();

        private readonly IUIFactory uiFactory;

        public RootCanvas RootCanvas { get; }

        public UIService(IUIFactory uiFactory)
        {
            this.uiFactory = uiFactory;

            // Create UIRoot
            var rootCanvasPrefab = Resources.Load<RootCanvas>(ROOT_CANVAS_PREFAB_PATH);
            RootCanvas = Object.Instantiate(rootCanvasPrefab);
            Object.DontDestroyOnLoad(RootCanvas);
        }

        public TScreen GetScreen<TScreen>() where TScreen : UIScreen
        {
            if (!createdScreens.ContainsKey(typeof(TScreen)))
            {
                createdScreens.Add(typeof(TScreen), uiFactory.CreateScreen<TScreen>(RootCanvas.transform));
            }

            return createdScreens[typeof(TScreen)] as TScreen;
        }

        public TScreen ShowScreen<TScreen>() where TScreen : UIScreen
        {
            var uiScreen = GetScreen<TScreen>();
            uiScreen.Show();

            return uiScreen;
        }

        public void HideScreen<TScreen>() where TScreen : UIScreen
        {
            GetScreen<TScreen>().Hide();
        }

        public TPopup ShowPopup<TPopup>() where TPopup : UIPopup
        {
            return null;
        }

        public void HidePopup<TPopup>() where TPopup : UIPopup
        {
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