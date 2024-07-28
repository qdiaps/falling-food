using Core.Food;
using Core.Player;
using UI;
using VContainer.Unity;

namespace Infrastructure.Boot
{
    public class Bootstrapper : IInitializable
    {
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
            CreateLaunchWindow();
            CreatePlayer();
            StartGeneratorFoods();
        }

        private void CreateLaunchWindow() => 
            _startupWindowFactory.Create();

        private void CreatePlayer() => 
            _playerFactory.Create();

        private void StartGeneratorFoods() => 
            _generatorFoods.StartGenerator();
    }
}