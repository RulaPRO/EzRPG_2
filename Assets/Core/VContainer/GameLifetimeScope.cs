using Core.CommandRunner.Implementation;
using Core.CommandRunner.Interfaces;
using Core.Factories;
using Core.Factories.Interfaces;
using Core.Services;
using Core.Services.Interfaces;
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

        builder.RegisterEntryPoint<GameSessionStarter>();
    }
}