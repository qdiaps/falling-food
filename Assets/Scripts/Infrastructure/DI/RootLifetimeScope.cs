using Infrastructure.Service.Leaderboard;
using Infrastructure.Service.Storage;
using Infrastructure.Setting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    [Header("Configs")]
    [SerializeField] private SettingsConfig _editorSettingsConfig;
    [SerializeField] private SettingsConfig _mobileSettingsConfig;
 
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterLeaderboard(builder);
        RegisterStorageService(builder);
        RegisterSettings(builder);
    }

    private static void RegisterLeaderboard(IContainerBuilder builder)
    {
        builder
            .Register<LeaderboardService>(Lifetime.Singleton);
    }

    private void RegisterStorageService(IContainerBuilder builder)
    {
        builder
            .Register<JsonToFileStorageService>(Lifetime.Singleton)
            .As<IStorageService>();
    }
    
    private void RegisterSettings(IContainerBuilder builder)
    {
        builder
            .RegisterInstance(Application.isEditor ? _editorSettingsConfig : _mobileSettingsConfig);
        builder
            .Register<Settings>(Lifetime.Singleton);
    }
}
