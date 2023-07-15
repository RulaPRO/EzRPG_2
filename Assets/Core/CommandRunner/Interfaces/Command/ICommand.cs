namespace Core.CommandRunner.Interfaces.Command
{
    public interface ICommand : ICommandEntity
    {
        void Execute();
    }
}