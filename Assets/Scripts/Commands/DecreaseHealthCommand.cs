using Core.CommandRunner.Interfaces.Command;
using Core.Services.HealthService.Interfaces;
using VContainer;

namespace Commands
{
    public class DecreaseHealthCommand : ICommandWithData<DecreaseHealthData>
    {
        [Inject]
        public IHealthService HealthService { get; private set; }

        public void Execute(DecreaseHealthData commandData)
        {
            HealthService.DecreaseCurrentHealth(commandData.Value);
        }
    }
}