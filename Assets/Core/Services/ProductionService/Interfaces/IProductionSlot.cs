using System;

namespace Core.Services.ProductionService.Interfaces
{
    public interface IProductionSlot
    {
        IRecipe CurrentRecipe { get; }
        DateTime EndTime { get; }
        bool InProgress { get; }
        bool CanStartCycle { get; }
        bool TryStartCycle(int recipeId);
        void CancelCycle();
    }
}