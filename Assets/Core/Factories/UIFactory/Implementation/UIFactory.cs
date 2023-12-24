using Core.Factories.Interfaces;
using Core.Services.UI;
using UI.Screens;
using UnityEngine;
using VContainer;

namespace Core.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IObjectResolver objectResolver;

        public UIFactory(IObjectResolver objectResolver)
        {
            this.objectResolver = objectResolver;
        }

        public TScreen CreateScreen<TScreen>(Transform parent) where TScreen : UIScreen
        {
            var screenPrefab = Resources.Load<TScreen>($"UI/Screens/{typeof(TScreen).Name}");
            var instance = Object.Instantiate(screenPrefab, parent);
            objectResolver.Inject(instance);

            return instance;
        }

        public TPopup CreatePopup<TPopup>(Transform parent) where TPopup : UIPopup
        {
            var popupPrefab = Resources.Load<TPopup>($"UI/Popups/{typeof(TPopup).Name}");
            var instance = Object.Instantiate(popupPrefab, parent);
            objectResolver.Inject(instance);

            return instance;
        }

        public TWidget CreateWidget<TWidget>(Transform parent) where TWidget : UIWidget
        {
            var widgetPrefab = Resources.Load<TWidget>($"UI/Widgets/{typeof(TWidget).Name}");
            var instance = Object.Instantiate(widgetPrefab, parent);
            objectResolver.Inject(instance);

            return instance;
        }
    }
}