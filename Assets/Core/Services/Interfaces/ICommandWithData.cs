namespace Core.Services.Interfaces
{
    public interface ICommandWithData<in TData> : ICommandEntity where TData : struct
    {
        void Execute(TData data);
    }
}