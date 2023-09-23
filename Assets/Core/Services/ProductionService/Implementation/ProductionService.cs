using System.Collections.Generic;
using Core.Services.ProductionService.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Core.Services.ProductionService.Implementation
{
    public class ProductionService : IProductionService, ITickable
    {
        List<IRecipe> Recipes { get; }
        Dictionary<string, IProductionSlot> Slots { get; }

        public ProductionService()
        {
            Slots = new Dictionary<string, IProductionSlot>()
            {
                {"test", new ProductionSlot()}
            };
        }

        public bool TryStartCycle(string slotId, int recipeId)
        {
            if (!Slots.TryGetValue(slotId, out var productionSlot))
            {
                Debug.LogError($"[ProductionService] production slot not fount. slotId: {slotId}");

                return false;
            }

            productionSlot.TryStartCycle(recipeId);

            return true;
        }

        public void CancelCycle(string slotId)
        {
        }

        public void Tick()
        {
        }
    }
}