using Core.Services.UI;
using UnityEngine;

namespace Core.Factories.Interfaces
{
    public interface IUIFactory
    {
        TScreen CreateScreen<TScreen>(Transform parent) where TScreen : UIScreen;
        TPopup CreatePopup<TPopup>(Transform parent) where TPopup : UIPopup;
        TWidget CreateWidget<TWidget>(Transform parent) where TWidget : UIWidget;
    }
}