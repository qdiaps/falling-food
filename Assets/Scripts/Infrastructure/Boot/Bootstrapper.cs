using Core.Food;
using Core.LeaderboardSystem;
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
        private readonly Leaderboard _leaderboard;

        public Bootstrapper(PlayerFactory playerFactory, StartupWindowFactory startupWindowFactory, 
            IGeneratorFoods generatorFoods, Leaderboard leaderboard)
        {
            _playerFactory = playerFactory;
            _startupWindowFactory = startupWindowFactory;
            _generatorFoods = generatorFoods;
            _leaderboard = leaderboard;
        }

        public void Initialize()
        {
            if (PlayerPrefs.HasKey(IsFirstRunning))
                CreateLaunchWindow();
            else
            {
                CreateLearnWindow();
                PlayerPrefs.SetInt(IsFirstRunning, 0);
                _leaderboard.SaveDefaultLeaderboard();
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