using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class StartupWindowFactory : BaseFactory
    {
        private const string LaunchWindow = "UI/LaunchWindow";
        private const string LearnWindow = "UI/LearnWindow";
        
        private readonly Mediator _mediator;

        public StartupWindowFactory(IObjectResolver container, Mediator mediator) : base(container)
        {
            _mediator = mediator;
        }

        public GameObject CreateLaunchWindow() => 
            Create(LaunchWindow);

        public GameObject CreateLearnWindow() => 
            Create(LearnWindow);

        private GameObject Create(string path)
        {
            var window = _container
                .Instantiate(Resources.Load<GameObject>(path));
            window
                .GetComponentInChildren<Button>()
                .onClick
                .AddListener(_mediator.SetPlayMode);
            return window;
        }
    }
}