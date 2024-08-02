using VContainer;

namespace Infrastructure.Factory
{
    public abstract class BaseFactory
    {
        protected readonly IObjectResolver _container;

        protected BaseFactory(IObjectResolver container) => 
            _container = container;
    }
}
