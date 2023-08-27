using System;
using System.Collections.Generic;
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
        private IEquipmentService equipmentService;

        private List<SlotUI> slotUiItems = new ();
        
        [Inject]
        public void Construct(
            ICommandExecutionService commandExecutionService,
            IEquipmentService equipmentService)
        {
            this.commandExecutionService = commandExecutionService;
            this.equipmentService = equipmentService;
        }

        private void Start()
        {
            buttonClose.onClick.AddListener(Hide);

            equipmentService.OnEquipmentItemsUpdated += UpdateEquipmentItems;

            UpdateEquipmentItems();
        }

        private void OnDestroy()
        {
            equipmentService.OnEquipmentItemsUpdated -= UpdateEquipmentItems;
        }

        private void UpdateEquipmentItems()
        {
            int index = 0;
            foreach (var equipmentItem in equipmentService.EquipmentItems)
            {
                if (slotUiItems.Count <= index)
                {
                    slotUiItems.Add(Instantiate(prefabSlotUI, contentRoot));
                }

                slotUiItems[index].SetText($"Equip ID:{equipmentItem.BalanceID.ToString()}");
                slotUiItems[index].gameObject.SetActive(true);

                index++;
            }

            while (index < slotUiItems.Count)
            {
                slotUiItems[index].gameObject.SetActive(false);
            }
        }
    }
}