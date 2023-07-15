namespace Core.CommandRunner.Interfaces.Command
{
    public interface ICommandWithData<in TCommandData> : ICommandEntity
        where TCommandData : struct
    {
        void Execute(TCommandData commandData);
    }
}