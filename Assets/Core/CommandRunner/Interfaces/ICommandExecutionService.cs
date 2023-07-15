using Core.CommandRunner.Interfaces.Command;

namespace Core.CommandRunner.Interfaces
{
    public interface ICommandExecutionService
    {
        void Execute<T>()
            where T : class, ICommand, new();

        void Execute<TCommand, TCommandData>(TCommandData payload)
            where TCommand : class, ICommandWithData<TCommandData>, new()
            where TCommandData : struct;
    }
}