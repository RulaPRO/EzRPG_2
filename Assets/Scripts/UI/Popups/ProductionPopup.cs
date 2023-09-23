using Core.CommandRunner.Interfaces;
using Core.Services.ProductionService.Interfaces;
using Core.Services.UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI.Popups
{
    public class ProductionPopup : UIPopup
    {
        [SerializeField] private Button buttonClose;
        
        private ICommandExecutionService commandExecutionService;
        private IProductionService productionService;
        
        [Inject]
        public void Construct(
            ICommandExecutionService commandExecutionService,
            IProductionService productionService)
        {
            this.commandExecutionService = commandExecutionService;
            this.productionService = productionService;
        }
        
        private void Start()
        {
            buttonClose.onClick.AddListener(Hide);
        }
    }
}