using Core.Services;
using Core.Services.Interfaces;
using Core.VContainer;
using UI.Screens;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IUIService, UIService>(Lifetime.Singleton);

        builder.RegisterComponentOnNewGameObject<GameplayHUDScreen>(Lifetime.Scoped);

        builder.RegisterEntryPoint<GamePresenter>();
    }
}
