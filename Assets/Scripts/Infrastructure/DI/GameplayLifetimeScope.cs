using Core.Food;
using Core.Player;
using Infrastructure.Boot;
using Infrastructure.FiniteStateMachine;
using Infrastructure.Game;
using Infrastructure.Service.Input;
using Infrastructure.Service.Storage;
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
        RegisterStorageService(builder);
        RegisterGeneratorFoods(builder);
        RegisterInput(builder);
        RegisterFsm(builder);
        RegisterMediator(builder);
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

    private static void RegisterStorageService(IContainerBuilder builder)
    {
        builder
            .Register<JsonToFileStorageService>(Lifetime.Singleton)
            .As<IStorageService>();
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
        builder
            .RegisterEntryPoint<GameStateInitializer>();
    }

    private static void RegisterMediator(IContainerBuilder builder)
    {
        builder
            .RegisterComponentInHierarchy<Mediator>();
    }

    private void RegisterBootstrapper(IContainerBuilder builder)
    {
        builder
            .RegisterEntryPoint<Bootstrapper>();
    }
}
