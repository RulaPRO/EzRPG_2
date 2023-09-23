namespace Core.Services.ProductionService.Interfaces
{
    public interface IProductionService
    {
        bool TryStartCycle(string slotId, int recipeId);
        void CancelCycle(string slotId);
    }
}