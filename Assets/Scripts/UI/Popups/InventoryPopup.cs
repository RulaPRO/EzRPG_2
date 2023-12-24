using System.Collections.Generic;
using Commands.UI.InventoryItemInfoPopup;
using Core.CommandRunner.Interfaces;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.UI;
using UI.Elements.Slots;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Popups
{
    public class InventoryPopup : UIPopup
    {
        [SerializeField] private SlotUI prefabSlotUI;
        [SerializeField] private Button buttonClose;
        [SerializeField] private RectTransform contentRoot;

        private ICommandExecutionService commandExecutionService;
        private IEquipmentServiceProvider equipmentServiceProvider;

        private readonly Dictionary<string, SlotUI> slots = new();

        private void Start()
        {
            buttonClose.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            equipmentServiceProvider.OnItemAdded -= AddSlotUI;
            equipmentServiceProvider.OnItemRemoved -= RemoveSlotUI;
            equipmentServiceProvider.OnItemRarityUpgraded -= UpdateSlotUI;
        }

        [Inject]
        public void Construct(
            ICommandExecutionService commandExecutionService,
            IEquipmentServiceProvider equipmentServiceProvider)
        {
            this.commandExecutionService = commandExecutionService;
            this.equipmentServiceProvider = equipmentServiceProvider;
            
            equipmentServiceProvider.OnItemAdded += AddSlotUI;
            equipmentServiceProvider.OnItemRemoved += RemoveSlotUI;
            equipmentServiceProvider.OnItemRarityUpgraded += UpdateSlotUI;

            InitializeUI();
        }

        private void InitializeUI()
        {
            foreach (var equipmentItem in equipmentServiceProvider.AvailableItems.Values)
            {
                CreateSlotUI(equipmentItem);
            }
        }

        private void CreateSlotUI(IEquipmentItem equipmentItem)
        {
            var slotUI = Instantiate(prefabSlotUI, contentRoot);
            slotUI.UpdateUI(equipmentItem);
            slotUI.SetListener(() => OnSlotClicked(equipmentItem.ObjectId));
            slots.Add(equipmentItem.ObjectId, slotUI);
        }

        private void OnSlotClicked(string id)
        {
            var payload = new ShowInventoryItemPopupData
            {
                InventoryObjectId = id,
            };
            commandExecutionService.Execute<ShowInventoryItemPopupCommand, ShowInventoryItemPopupData>(payload);
        }

        private void AddSlotUI(IEquipmentItem equipmentItem)
        {
            CreateSlotUI(equipmentItem);
        }

        private void RemoveSlotUI(IEquipmentItem equipmentItem)
        {
            slots.Remove(equipmentItem.ObjectId);
        }

        private void UpdateSlotUI(string id)
        {
            var equipmentItem = equipmentServiceProvider.AvailableItems[id];
            slots[id].UpdateUI(equipmentItem);
        }
    }
}