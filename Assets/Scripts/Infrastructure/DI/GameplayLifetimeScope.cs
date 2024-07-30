using Core.Food;
using Core.LeaderboardSystem;
using Core.Player;
using Core.Score;
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
        RegisterScore(builder);
        RegisterConfigs(builder);
        RegisterFactories(builder);
        RegisterLeaderboard(builder);
        RegisterStorageService(builder);
        RegisterGeneratorFoods(builder);
        RegisterInput(builder);
        RegisterFsm(builder);
        RegisterMediator(builder);
        RegisterBootstrapper(builder);
    }

    private static void RegisterScore(IContainerBuilder builder)
    {
        builder
            .RegisterComponentInHierarchy<ScoreView>();
        builder
            .Register<ScoreHandler>(Lifetime.Singleton);
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

    private void RegisterLeaderboard(IContainerBuilder builder)
    {
        builder
            .Register<Leaderboard>(Lifetime.Singleton);
    }

    private void RegisterStorageService(IContainerBuilder builder)
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

    private void RegisterMediator(IContainerBuilder builder)
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
