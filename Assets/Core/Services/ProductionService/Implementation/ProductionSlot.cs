using System;
using Core.Services.ProductionService.Interfaces;
using UnityEngine;

namespace Core.Services.ProductionService.Implementation
{
    public class ProductionSlot : IProductionSlot
    {
        public IRecipe CurrentRecipe { get; }
        public DateTime EndTime { get; }
        public bool InProgress { get; }
        public bool CanStartCycle { get; }
        public bool TryStartCycle(int recipeId)
        {
            Debug.LogError($"[ProductionSlot] try start production cycle");

            return true;
        }

        public void CancelCycle()
        {
            throw new NotImplementedException();
        }
    }
}