using Commands.UI.InventoryItemInfoPopup;
using Commands.UpgradeInventoryItem;
using Core.CommandRunner.Interfaces;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.UI;
using UI.Elements.EquipmentItemView;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Popups
{
    public class EquipmentItemPopup : UIPopup
    {
        [SerializeField] private Button buttonClose;
        [SerializeField] private Button buttonUpgrade;

        [SerializeField] private EquipmentItemElementUI[] inventoryItemElementUIs;

        private ICommandExecutionService commandExecutionService;
        private IEquipmentServiceProvider equipmentServiceProvider;

        private string inventoryItemId;

        private void Start()
        {
            buttonClose.onClick.AddListener(Hide);
            buttonUpgrade.onClick.AddListener(OnUpgradeButtonClick);
        }

        private void OnDisable()
        {
            equipmentServiceProvider.OnItemRarityUpgraded -= UpdateUI;
        }

        [Inject]
        public void Construct(
            ICommandExecutionService commandExecutionService,
            IEquipmentServiceProvider equipmentServiceProvider)
        {
            this.commandExecutionService = commandExecutionService;
            this.equipmentServiceProvider = equipmentServiceProvider;
        }

        public void Initialize(ShowInventoryItemPopupData data)
        {
            inventoryItemId = data.InventoryObjectId;

            equipmentServiceProvider.OnItemRarityUpgraded += UpdateUI;

            UpdateUI(inventoryItemId);
        }

        private void UpdateUI(string id)
        {
            if (!inventoryItemId.Equals(id))
            {
                return;
            }

            var inventoryObject = equipmentServiceProvider.AvailableItems[id];
            foreach (var inventoryItemElementUI in inventoryItemElementUIs)
            {
                inventoryItemElementUI.UpdateUI(inventoryObject);
            }
        }

        private void OnUpgradeButtonClick()
        {
            var data = new UpgradeEquipmentItemData
            {
                EquipmentItemId = inventoryItemId
            };
            commandExecutionService.Execute<TryUpgradeEquipmentItemCommand, UpgradeEquipmentItemData>(data);
        }
    }
}