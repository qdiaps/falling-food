using Infrastructure.FiniteStateMachine;
using UI;

namespace Infrastructure.Game
{
    public class Pause : InitPause
    {
        private readonly GameplayMediator _gameplayMediator;

        public Pause(FSM fsm, GameplayMediator gameplayMediator) : base(fsm)
        {
            _gameplayMediator = gameplayMediator;
        }

        public override void Enter()
        {
            base.Enter();
            _gameplayMediator.ShowPauseMenu();
        }

        public override void Exit()
        {
            base.Exit();
            _gameplayMediator.HidePauseMenu();
        }
    }
}