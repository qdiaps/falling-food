using Core.Food;
using Core.LeaderboardSystem;
using Core.Score;
using Infrastructure.Boot;
using Infrastructure.Factory;
using Infrastructure.FiniteStateMachine;
using Infrastructure.Game;
using Infrastructure.Service.Input;
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
        RegisterGeneratorFoods(builder);
        RegisterInput(builder);
        RegisterFsm(builder);
        RegisterMediator(builder);
        RegisterEntryPoint(builder);
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
            .Register<ResourcesFactory>(Lifetime.Singleton);
        builder
            .Register<FoodFactory>(Lifetime.Singleton);
    }

    private void RegisterLeaderboard(IContainerBuilder builder)
    {
        builder
            .Register<Leaderboard>(Lifetime.Singleton);
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
            .RegisterComponentInHierarchy<GameplayMediator>();
    }

    private void RegisterEntryPoint(IContainerBuilder builder)
    {
        builder
            .RegisterEntryPoint<GameplayEntryPoint>();
    }
}
