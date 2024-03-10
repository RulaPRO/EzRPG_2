using Core.CommandRunner.Interfaces.Command;
using Core.Services.CardDeckService.Interfaces;
using VContainer;

namespace Commands.UpgradeCard
{
    public class TryUpgradeCardLevelCommand : ICommandWithData<UpgradeCardData>
    {
        private ICardDeckService cardDeckService;

        [Inject]
        public void Construct(
            ICardDeckService cardDeckService)
        {
            this.cardDeckService = cardDeckService;
        }

        public void Execute(UpgradeCardData commandData)
        {
            cardDeckService.UpgradeCard(commandData.CardId);
        }
    }
}