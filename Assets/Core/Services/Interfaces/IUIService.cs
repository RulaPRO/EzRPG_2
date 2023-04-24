using Core.Services.UI;

namespace Core.Services.Interfaces
{
    public interface IUIService
    {
        TScreen ShowScreenAsync<TScreen>()
            where TScreen : UIScreen;

        void HideScreenAsync<TScreen>()
            where TScreen : UIScreen;

        TPopup ShowPopupAsync<TPopup>()
            where TPopup : UIPopup;

        void HidePopupAsync<TPopup>()
            where TPopup : UIPopup;

        T GetScreen<T>()
            where T : UIScreen;
    }
}