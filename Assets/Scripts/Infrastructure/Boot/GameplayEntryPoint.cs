using Core.Food;
using Infrastructure.Factory;
using UI;
using UnityEngine.UI;
using VContainer.Unity;

namespace Infrastructure.Boot
{
    public class GameplayEntryPoint : IInitializable
    {
        private const string Player = "Core/Player";
        private const string LaunchWindow = "UI/LaunchWindow";
        
        private readonly ResourcesFactory _resourcesFactory;
        private readonly GameplayMediator _gameplayMediator;
        private readonly IGeneratorFoods _generatorFoods;

        public GameplayEntryPoint(ResourcesFactory resourcesFactory, GameplayMediator gameplayMediator,
            IGeneratorFoods generatorFoods)
        {
            _resourcesFactory = resourcesFactory;
            _gameplayMediator = gameplayMediator;
            _generatorFoods = generatorFoods;
        }

        public void Initialize()
        {
            CreateLaunchWindow();
            CreatePlayer();
            StartGeneratorFoods();
        }

        private void CreateLaunchWindow()
        {
            var window = _resourcesFactory
                .Create(LaunchWindow);
            window
                .GetComponentInChildren<Button>()
                .onClick
                .AddListener(_gameplayMediator.SetPlayMode);
        }

        private void CreatePlayer() =>
            _resourcesFactory.Create(Player);

        private void StartGeneratorFoods() => 
            _generatorFoods.StartGenerator();
    }
}