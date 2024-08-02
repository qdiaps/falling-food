using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Factory
{
    public class ResourcesFactory : BaseFactory
    {
        public ResourcesFactory(IObjectResolver container) : base(container) { }

        public GameObject Create(string path) =>
            _container
                .Instantiate(Resources.Load<GameObject>(path));
    }
}