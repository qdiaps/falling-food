using Core.Food;
using Core.Player;
using Infrastructure.Boot;
using Infrastructure.FiniteStateMachine;
using Infrastructure.Game;
using Infrastructure.Service;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameplayLifetimeScope : LifetimeScope
{
    [Header("Configs")]
    [SerializeField] private FoodConfig _foodConfig;
    [SerializeField] private GeneratorFoodsConfig _generatorFoodsConfig;
    
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterConfigs(builder);
        RegisterFactories(builder);
        RegisterGeneratorFoods(builder);
        RegisterInput(builder);
        RegisterFsm(builder);
        RegisterMediator(builder);
        RegisterGameStateHandler(builder);
        RegisterBootstrapper(builder);
    }

    private void RegisterConfigs(IContainerBuilder builder)
    {
        builder
            .RegisterInstance(_foodConfig);
        builder
            .RegisterInstance(_generatorFoodsConfig);
    }

    private void RegisterFactories(IContainerBuilder builder)
    {
        builder
            .Register<StartupWindowFactory>(Lifetime.Singleton);
        builder
            .Register<PlayerFactory>(Lifetime.Singleton);
        builder
            .Register<FoodFactory>(Lifetime.Singleton);
    }

    private void RegisterGeneratorFoods(IContainerBuilder builder)
    {
        builder
            .RegisterComponentInHierarchy<GeneratorFoods>()
            .AsImplementedInterfaces();
    }

    private void RegisterInput(IContainerBuilder builder)
    {
        if (Application.isEditor)
            builder
                .RegisterEntryPoint<EditorInputService>();
        else
            builder
                .RegisterEntryPoint<MobileInputService>();
    }

    private void RegisterFsm(IContainerBuilder builder)
    {
        builder
            .Register<FSM>(Lifetime.Singleton);
    }

    private static void RegisterMediator(IContainerBuilder builder)
    {
        builder
            .RegisterComponentInHierarchy<Mediator>();
    }

    private void RegisterGameStateHandler(IContainerBuilder builder)
    {
        builder
            .RegisterEntryPoint<GameStateInitializer>();
    }

    private void RegisterBootstrapper(IContainerBuilder builder)
    {
        builder
            .RegisterEntryPoint<Bootstrapper>();
    }
}
