using System;

namespace Core.Services.HealthService.Interfaces
{
    public interface IHealthService
    {
        int CurrentValue { get; }
        int MaxValue { get; }
        event Action OnValueChanged;

        void IncreaseCurrentHealth(int value);
        void DecreaseCurrentHealth(int value);
        void IncreaseMaxHealth(int value);
        void DecreaseMaxHealth(int value);
    }
}