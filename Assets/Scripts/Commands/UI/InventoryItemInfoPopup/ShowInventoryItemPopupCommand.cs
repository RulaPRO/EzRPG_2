using UI.Popups;

namespace Commands.UI.InventoryItemInfoPopup
{
    public class ShowInventoryItemPopupCommand : ShowPopupCommandWithData<EquipmentItemPopup, ShowInventoryItemPopupData>
    {
        protected override void InitializePopup(EquipmentItemPopup popup, ShowInventoryItemPopupData data)
        {
            popup.Initialize(data);
        }
    }
}