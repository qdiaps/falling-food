using Infrastructure.FiniteStateMachine;
using UI;

namespace Infrastructure.Game
{
    public class Play : State
    {
        private readonly GameplayMediator _gameplayMediator;
        public Play(FSM fsm, GameplayMediator gameplayMediator) : base(fsm)
        {
            _gameplayMediator = gameplayMediator;
        }

        public override void Enter()
        {
            if (_fsm.PastState.GetType() == typeof(GameOver))
                _gameplayMediator.Restart();
        }
    }
}