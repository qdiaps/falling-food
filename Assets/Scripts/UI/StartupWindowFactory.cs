using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class StartupWindowFactory : BaseFactory
    {
        private const string LaunchWindow = "UI/LaunchWindow";
        private const string LearnWindow = "UI/LearnWindow";

        public StartupWindowFactory(IObjectResolver container) : base(container) { }

        public GameObject CreateLaunchWindow() => 
            Create(LaunchWindow);

        public GameObject CreateLearnWindow() => 
            Create(LearnWindow);

        private GameObject Create(string path)
        {
            return _container
                .Instantiate(Resources.Load<GameObject>(path));
        }
    }
}