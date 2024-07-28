using Core.Food;
using Core.Player;
using Infrastructure.Boot;
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
        RegisterBootstrapper(builder);
    }

    private void RegisterConfigs(IContainerBuilder builder)
    {
        builder
            .RegisterInstance(_foodConfig);
        builder
            .RegisterInstance(_generatorFoodsConfig);
    }

    private static void RegisterFactories(IContainerBuilder builder)
    {
        builder
            .Register<StartupWindowFactory>(Lifetime.Singleton);
        builder
            .Register<PlayerFactory>(Lifetime.Singleton);
        builder
            .Register<FoodFactory>(Lifetime.Singleton);
    }

    private static void RegisterGeneratorFoods(IContainerBuilder builder)
    {
        builder
            .RegisterComponentInHierarchy<GeneratorFoods>()
            .AsImplementedInterfaces();
    }

    private void RegisterInput(IContainerBuilder builder)
    {
        if (Application.isEditor)
            builder
                .RegisterComponentOnNewGameObject<EditorInputService>(Lifetime.Singleton, "EditorInputService")
                .AsImplementedInterfaces();
        else
            builder
                .RegisterComponentOnNewGameObject<MobileInputService>(Lifetime.Singleton, "MobileInputService")
                .AsImplementedInterfaces();
    }

    private static void RegisterBootstrapper(IContainerBuilder builder)
    {
        builder
            .RegisterEntryPoint<Bootstrapper>();
    }
}
