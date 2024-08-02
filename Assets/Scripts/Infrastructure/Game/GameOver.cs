using Infrastructure.FiniteStateMachine;
using UI;

namespace Infrastructure.Game
{
    public class GameOver : InitPause
    {
        private readonly GameplayMediator _gameplayMediator;

        public GameOver(FSM fsm, GameplayMediator gameplayMediator) : base(fsm)
        {
            _gameplayMediator = gameplayMediator;
        }

        public override void Enter()
        {
            base.Enter();
            _gameplayMediator.ShowGameOverMenu();
            _gameplayMediator.UpdateScoreResult();
            _gameplayMediator.SaveScore();
        }

        public override void Exit()
        {
            base.Exit();
            _gameplayMediator.HideGameOverMenu();
        }
    }
}