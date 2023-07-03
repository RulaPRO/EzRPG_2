namespace Core.Services.Interfaces
{
    public interface ICommandExecutionService
    {
        void Execute<T>()
            where T : class, ICommand, new();

        void Execute<TCommand, TPayload>(TPayload payload)
            where TCommand : class, ICommandWithData<TPayload>, new()
            where TPayload : struct;
    }
}