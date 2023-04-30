﻿using Core.Services.UI;

namespace Core.Services.Interfaces
{
    public interface IUIService
    {
        TScreen GetScreen<TScreen>() where TScreen : UIScreen;
        TScreen ShowScreen<TScreen>() where TScreen : UIScreen;
        void HideScreen<TScreen>() where TScreen : UIScreen;

        TPopup ShowPopup<TPopup>() where TPopup : UIPopup;
        void HidePopup<TPopup>() where TPopup : UIPopup;
    }
}