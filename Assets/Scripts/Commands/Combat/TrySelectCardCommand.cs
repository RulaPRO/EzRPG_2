using Core.CommandRunner.Interfaces.Command;
using Core.Services.CombatService.Interfaces;
using VContainer;

namespace Commands.Combat
{
    public class TrySelectCardCommand : ICommandWithData<SelectCardData>
    {
        [Inject]
        public ICombatService CombatService { get; private set; }

        public void Execute(SelectCardData commandData)
        {
            CombatService.TrySelectCard(commandData.CardId);
        }
    }
}