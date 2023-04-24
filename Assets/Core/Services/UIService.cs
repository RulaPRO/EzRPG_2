using System.Collections.Generic;
using Core.Services.UI;
using UnityEngine;

namespace Core.Services
{
    public class UIService
    {
        private const string UI_ROOT = "UIRoot";

        private readonly IUIFactory uiFactory;
        private readonly Dictionary<Type, UIScreen> createdScreens = new();
        private readonly Dictionary<Type, UIPopup> createdPopups = new();
        private readonly Dictionary<Type, UIPopup> activePopups = new();
        private readonly FloatingPanelPool floatingPanelPool;
        private UIScreen activeScreen;

        public UIRoot UIRoot { get; private set; }

        public UIService(IUIFactory uiFactory)
        {
            floatingPanelPool = new FloatingPanelPool(uiFactory);

            this.uiFactory = uiFactory;
            CreateUIRoot();
        }

        public async TScreen ShowScreenAsync<TScreen>() where TScreen : UIScreen
        {
            var screenType = typeof(TScreen);
            var isScreenActive = activeScreen != null && activeScreen.GetType() == screenType;
            if (isScreenActive)
            {
                return activeScreen as TScreen;
            }

            var isScreenCreated = createdScreens.TryGetValue(screenType, out var screenToShow);
            if (!isScreenCreated)
            {
                screenToShow = await uiFactory.CreateScreenAsync<TScreen>(UIRoot.ScreensRoot);
                createdScreens.Add(screenType, screenToShow);
            }

            if (activeScreen != null)
            {
                activeScreen.Hide();
            }

            activeScreen = screenToShow;
            activeScreen.Show();

            return activeScreen as TScreen;
        }

        public UniTask HideScreenAsync<TScreen>() where TScreen : UIScreen
        {
            var screenType = typeof(TScreen);
            var isScreenActive = activeScreen != null && activeScreen.GetType() == screenType;
            if (isScreenActive)
            {
                activeScreen.Hide();
                activeScreen = null;
            }

            return UniTask.CompletedTask;
        }

        public async UniTask<TPopup> ShowPopupAsync<TPopup>() where TPopup : UIPopup
        {
            var popupType = typeof(TPopup);
            var isPopupActive = activePopups.ContainsKey(popupType);
            if (isPopupActive)
            {
                return activePopups[popupType] as TPopup;
            }

            var isPopupCreated = createdPopups.TryGetValue(popupType, out var popupToShow);
            if (!isPopupCreated)
            {
                popupToShow = await uiFactory.CreatePopupAsync<TPopup>(UIRoot.ScreensRoot);
                createdPopups.Add(popupType, popupToShow);
            }

            popupToShow.Show();
            activePopups.Add(popupType, popupToShow);

            return popupToShow as TPopup;
        }

        public UniTask HidePopupAsync<TPopup>() where TPopup : UIPopup
        {
            var popupType = typeof(TPopup);
            var isPopupActive = activePopups.TryGetValue(popupType, out var popupToHide);
            if (isPopupActive)
            {
                popupToHide.Hide();
                activePopups.Remove(popupType);
            }

            return UniTask.CompletedTask;
        }

        public TPanel ShowFloatingPanelAsync<TPanel, TData>(
            object panelKey,
            TData data,
            Transform anchor,
            Transform parent = null)
            where TPanel : FloatingPanel<TData>
        {
            var panel = floatingPanelPool.GetFloatingPanel<TPanel, TData>(panelKey);
            if (!panel)
            {
                return panel;
            }

            var panelTransform = panel.transform;
            panelTransform.SetParent(parent ? parent : UIRoot.FloatingPanelsRoot);
            panelTransform.localScale = Vector3.one;
            panel.Show(data, anchor, UIRoot.Resolution);
            return panel;
        }

        public void HideFloatingPanel<TPanel, TData>(object panelKey)
            where TPanel : FloatingPanel<TData>
        {
            if (floatingPanelPool.FindExistedPanel<TPanel, TData>(panelKey, out var panel))
            {
                panel.Hide();
            }
        }

        public T GetScreen<T>() where T : UIScreen => createdScreens[typeof(T)] as T;

        public void Dispose()
        {
            if (UIRoot)
            {
                Object.Destroy(UIRoot.gameObject);
            }
        }

        private void CreateUIRoot()
        {
            var uiRootGameObject = Addressables.InstantiateAsync(UI_ROOT).WaitForCompletion();
            Object.DontDestroyOnLoad(uiRootGameObject);
            UIRoot = uiRootGameObject.GetComponent<UIRoot>();
        }
    }
}