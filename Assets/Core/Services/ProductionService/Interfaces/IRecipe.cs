using System.Collections.Generic;

namespace Core.Services.ProductionService.Interfaces
{
    public interface IRecipe
    {
        int BalanceId { get; }
        List<int> Ingredients { get; }
    }
}