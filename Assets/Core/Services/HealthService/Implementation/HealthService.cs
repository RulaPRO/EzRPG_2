using System;
using Core.Services.HealthService.Interfaces;
using UnityEngine;

namespace Core.Services.HealthService.Implementation
{
    public class HealthService : IHealthService
    {
        public event Action OnValueChanged;

        public int CurrentValue => currentValue;
        public int MaxValue { get; private set; }

        private int currentValue;

        public void IncreaseCurrentHealth(int value)
        {
            if (value <= 0)
            {
                return;
            }
            
            currentValue = Mathf.Clamp(currentValue + value, 0, MaxValue);
            
            OnValueChanged?.Invoke();
        }

        public void DecreaseCurrentHealth(int value)
        {
            if (value <= 0)
            {
                return;
            }
            
            currentValue = Mathf.Clamp(currentValue - value, 0, MaxValue);
            
            OnValueChanged?.Invoke();
        }

        public void IncreaseMaxHealth(int value)
        {
            throw new NotImplementedException();
        }

        public void DecreaseMaxHealth(int value)
        {
            throw new NotImplementedException();
        }
    }
}