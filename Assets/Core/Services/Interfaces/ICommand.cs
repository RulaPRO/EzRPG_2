namespace Core.Services.Interfaces
{
    public interface ICommand : ICommandEntity
    {
        void Execute();
    }
}