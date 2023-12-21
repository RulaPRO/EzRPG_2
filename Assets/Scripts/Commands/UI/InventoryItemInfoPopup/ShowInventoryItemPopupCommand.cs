using UI.Popups;

namespace Commands.UI.InventoryItemInfoPopup
{
    public class ShowInventoryItemPopupCommand : ShowPopupCommandWithData<InventoryItemPopup, ShowInventoryItemPopupData>
    {
        protected override void InitializePopup(InventoryItemPopup popup, ShowInventoryItemPopupData data)
        {
            popup.Initialize(data);
        }
    }
}