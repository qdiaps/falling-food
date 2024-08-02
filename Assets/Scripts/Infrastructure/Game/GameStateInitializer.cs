using Infrastructure.FiniteStateMachine;
using UI;
using VContainer.Unity;

namespace Infrastructure.Game
{
    public class GameStateInitializer : IInitializable
    {
        private readonly FSM _fsm;
        private readonly GameplayMediator _gameplayMediator;

        public GameStateInitializer(FSM fsm, GameplayMediator gameplayMediator)
        {
            _fsm = fsm;
            _gameplayMediator = gameplayMediator;
        }

        public void Initialize()
        {
            _fsm.AddState(new InitPause(_fsm));
            _fsm.AddState(new Pause(_fsm, _gameplayMediator));
            _fsm.AddState(new Play(_fsm, _gameplayMediator));
            _fsm.AddState(new GameOver(_fsm, _gameplayMediator));

            _fsm.SetState<InitPause>();
        }
    }
}