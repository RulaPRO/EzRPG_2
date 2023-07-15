using Core.CommandRunner.Interfaces.Command;

namespace Core.CommandRunner.Interfaces
{
    public interface ICommandFactory
    {
        T GetCommand<T>()
            where T : class, ICommandEntity, new();
    }
}