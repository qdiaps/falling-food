using Infrastructure.Service.Storage;
using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterStorageService(builder);
    }
    
    private void RegisterStorageService(IContainerBuilder builder)
    {
        builder
            .Register<JsonToFileStorageService>(Lifetime.Singleton)
            .As<IStorageService>();
    }
}
