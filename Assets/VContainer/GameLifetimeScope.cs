using VContainer;
using VContainer.GameServices;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<HelloWorldService>(Lifetime.Singleton);
    }
}
