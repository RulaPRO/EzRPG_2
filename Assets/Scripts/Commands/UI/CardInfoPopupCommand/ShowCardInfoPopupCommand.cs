using UI.Popups;

namespace Commands.UI.CardInfoPopupCommand
{
    public class ShowCardInfoPopupCommand : ShowPopupCommandWithData<CardInfoPopup, ShowCardInfoPopupData>
    {
        protected override void InitializePopup(CardInfoPopup popup, ShowCardInfoPopupData data)
        {
            popup.InitializeUI(data.CardId);
        }
    }
}