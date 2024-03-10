using Core.CommandRunner.Implementation;
using Core.CommandRunner.Interfaces;
using Core.Factories;
using Core.Factories.Interfaces;
using Core.Services;
using Core.Services.CardDeckService.Implementation;
using Core.Services.CardDeckService.Interfaces;
using Core.Services.CombatService.Implementation;
using Core.Services.CombatService.Interfaces;
using Core.Services.EquipmentService.Implementation;
using Core.Services.EquipmentService.Interfaces;
using Core.Services.HealthService.Implementation;
using Core.Services.HealthService.Interfaces;
using Core.Services.Interfaces;
using Core.Services.UpgradeEquipmentService.Implementation;
using Core.Services.UpgradeEquipmentService.Interfaces;
using Core.VContainer;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ICommandFactory, CommandFactory>(Lifetime.Singleton);
        builder.Register<ICommandExecutionService, CommandExecutionService>(Lifetime.Singleton);

        builder.Register<IUIFactory, UIFactory>(Lifetime.Singleton);
        builder.Register<IUIService, UIService>(Lifetime.Singleton);

        builder.Register<IHealthService, HealthService>(Lifetime.Singleton);

        builder.Register<IUpgradeEquipmentService, UpgradeEquipmentService>(Lifetime.Singleton);
        builder.Register<IEquipmentService, EquipmentService>(Lifetime.Singleton);
        builder.Register<IEquipmentServiceProvider, EquipmentServiceProvider>(Lifetime.Singleton);
        
        builder.Register<ICardDeckService, CardDeckService>(Lifetime.Singleton);

        builder.Register<ICombatService, CombatService>(Lifetime.Singleton);

        builder.RegisterEntryPoint<GameSessionStarter>();
    }
}