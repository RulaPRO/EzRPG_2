using Commands.UI;
using Core.CommandRunner.Interfaces;
using Core.CommandRunner.Interfaces.Command;
using Core.Services.CombatService.Interfaces;
using UI.Screens;
using VContainer;

namespace Core.Services.CombatService.Commands
{
    public class TryStartCombatCommand : ICommand
    {
        private ICombatService combatService;
        private ICommandExecutionService commandExecutionService;

        [Inject]
        public void Construct(
            ICombatService combatService,
            ICommandExecutionService commandExecutionService)
        {
            this.combatService = combatService;
            this.commandExecutionService = commandExecutionService;
        }

        public void Execute()
        {
            if (combatService.TryStartCombat())
            {
                commandExecutionService.Execute<ShowScreenCommand<CombatScreen>>();
            }
            else
            {
                OnCombatStartFailed();
            }
        }

        private void OnCombatStartFailed()
        {
            // ads popup
        }
    }
}