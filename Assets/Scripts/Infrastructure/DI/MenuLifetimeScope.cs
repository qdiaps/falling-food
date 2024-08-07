using UI;
using VContainer;
using VContainer.Unity;

public class MenuLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterMediator(builder);
    }

    private static void RegisterMediator(IContainerBuilder builder)
    {
        builder
            .RegisterComponentInHierarchy<MenuMediator>();
    }
}
