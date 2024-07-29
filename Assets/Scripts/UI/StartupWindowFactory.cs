using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class StartupWindowFactory : BaseFactory
    {
        private const string LaunchWindow = "UI/LaunchWindow";

        public StartupWindowFactory(IObjectResolver container) : base(container) { }

        public GameObject Create()
        {
            return _container
                .Instantiate(Resources.Load<GameObject>(LaunchWindow));
        }
    }
}