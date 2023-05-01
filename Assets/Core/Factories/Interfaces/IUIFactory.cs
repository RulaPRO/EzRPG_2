using Core.Services.UI;
using UnityEngine;

namespace Core.Services.Interfaces
{
    public interface IUIFactory
    {
        TScreen CreateScreen<TScreen>(Transform parent) where TScreen : UIScreen;
    }
}