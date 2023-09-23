using System.Collections.Generic;

namespace Core.Services.ProductionService.Interfaces
{
    public interface IProduction
    {
        List<IRecipe> Recipes { get; }
        Dictionary<string, IProductionSlot> Slots { get; }

        bool TryStartCycle(string slotId, IRecipe recipe);
        void CancelCycle(string slotId);
    }
}