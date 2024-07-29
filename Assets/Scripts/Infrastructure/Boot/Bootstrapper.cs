using Core.Food;
using Core.Player;
using UI;
using UnityEngine;
using VContainer.Unity;

namespace Infrastructure.Boot
{
    public class Bootstrapper : IInitializable
    {
        private const string IsFirstRunning = "IsFirstRunning";
        
        private readonly PlayerFactory _playerFactory;
        private readonly StartupWindowFactory _startupWindowFactory;
        private readonly IGeneratorFoods _generatorFoods;

        public Bootstrapper(PlayerFactory playerFactory, StartupWindowFactory startupWindowFactory, 
            IGeneratorFoods generatorFoods)
        {
            _playerFactory = playerFactory;
            _startupWindowFactory = startupWindowFactory;
            _generatorFoods = generatorFoods;
        }

        public void Initialize()
        {
            if (PlayerPrefs.HasKey(IsFirstRunning))
                CreateLaunchWindow();
            else
            {
                PlayerPrefs.SetInt(IsFirstRunning, 0);
                CreateLearnWindow();
            }
            CreatePlayer();
            StartGeneratorFoods();
        }

        private void CreateLaunchWindow() => 
            _startupWindowFactory.CreateLaunchWindow();

        private void CreateLearnWindow() =>
            _startupWindowFactory.CreateLearnWindow();

        private void CreatePlayer() => 
            _playerFactory.Create();

        private void StartGeneratorFoods() => 
            _generatorFoods.StartGenerator();
    }
}