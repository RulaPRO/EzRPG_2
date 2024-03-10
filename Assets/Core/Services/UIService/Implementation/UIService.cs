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

        private readonly Dictionary<Type, UIPopup> createdPopups = new();
        private readonly Dictionary<Type, UIScreen> createdScreens = new();
        private readonly Dictionary<Type, UIWidget> createdWidgets = new();

        private readonly IUIFactory uiFactory;

        private UIScreen activeScreen;

        public UIService(IUIFactory uiFactory)
        {
            this.uiFactory = uiFactory;

            // Create UIRoot
            var rootCanvasPrefab = Resources.Load<RootCanvas>(ROOT_CANVAS_PREFAB_PATH);
            RootCanvas = Object.Instantiate(rootCanvasPrefab);
            Object.DontDestroyOnLoad(RootCanvas);
        }

        public RootCanvas RootCanvas { get; }

        public void Dispose()
        {
            if (RootCanvas) Object.Destroy(RootCanvas.gameObject);
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
            var screenType = typeof(TScreen);
            if (activeScreen != null && activeScreen.GetType() == screenType)
            {
                return activeScreen as TScreen;
            }

            if (activeScreen != null)
            {
                activeScreen.Hide();
            }

            activeScreen = GetScreen<TScreen>();
            activeScreen.Show();

            return activeScreen as TScreen;
        }

        public void HideScreen<TScreen>() where TScreen : UIScreen
        {
            GetScreen<TScreen>().Hide();
        }

        public TPopup GetPopup<TPopup>() where TPopup : UIPopup
        {
            if (!createdPopups.ContainsKey(typeof(TPopup)))
            {
                createdPopups.Add(typeof(TPopup), uiFactory.CreatePopup<TPopup>(RootCanvas.transform));
            }

            return createdPopups[typeof(TPopup)] as TPopup;
        }

        public TPopup ShowPopup<TPopup>() where TPopup : UIPopup
        {
            var popup = GetPopup<TPopup>();
            popup.Show();

            return popup;
        }

        public void HidePopup<TPopup>() where TPopup : UIPopup
        {
            GetPopup<TPopup>().Hide();
        }

        public TWidget GetWidget<TWidget>() where TWidget : UIWidget
        {
            if (!createdWidgets.ContainsKey(typeof(TWidget)))
            {
                createdWidgets.Add(typeof(TWidget), uiFactory.CreateWidget<TWidget>(RootCanvas.transform));
            }

            return createdWidgets[typeof(TWidget)] as TWidget;
        }

        public TWidget ShowWidget<TWidget>() where TWidget : UIWidget
        {
            var widget = GetWidget<TWidget>();
            widget.Show();

            return widget;
        }

        public void HideWidget<TWidget>() where TWidget : UIWidget
        {
            GetWidget<TWidget>().Hide();
        }
    }
}