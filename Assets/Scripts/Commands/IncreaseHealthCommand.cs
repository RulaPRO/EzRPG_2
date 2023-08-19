using Core.CommandRunner.Interfaces.Command;
using Core.Services.HealthService.Interfaces;
using VContainer;

namespace Commands
{
    public class IncreaseHealthCommand : ICommandWithData<IncreaseHealthData>
    {
        [Inject]
        public IHealthService HealthService { get; private set; }

        public void Execute(IncreaseHealthData commandData)
        {
            HealthService.IncreaseCurrentHealth(commandData.Value);
        }
    }
}